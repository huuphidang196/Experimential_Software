using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Experimential_Software.DTO;
using System.Windows.Forms;
using System.Data;
using Experimential_Software.DAO.DAO_MBA2Data;

namespace Experimential_Software.DAO.DAO_Curve
{
    public class DAODataProviderMBA2P
    {
        protected static DAODataProviderMBA2P _instance;
        public static DAODataProviderMBA2P Instance
        {
            get { if (_instance == null) _instance = new DAODataProviderMBA2P(); return _instance; }
            private set { }
        }

        private DAODataProviderMBA2P() { }

        public virtual void ExecuteQuery(ConnectableE mb2PEPower)
        {
            //Get DTO MBA2P
            DTOTransTwoEPower dtoMBA2P = this.GetDTOMBA2PConsider(mb2PEPower);
            int ObjectNumber = dtoMBA2P.ObjectNumber;

            // Câu lệnh truy vấn SQL
            string query = "SELECT * from DTOTransTwoEPower WHERE ObjectNumber = @Param";

            DataTable dataTable = DAODataProvider.Instance.ExecuteQuery(query, ObjectNumber);

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Chưa co Cơ sở dữ liệu cho MBA2P ");
                return;
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[0];

                int ObjNum = (int)dataRow["ObjectNumber"];
                // int coulumn = sqlReader.FieldCount;
                dtoMBA2P.ObjectName = dataRow["ObjectName"].ToString();
                dtoMBA2P.PowerRated_MVA = double.Parse(dataRow["PowerRated_MVA"].ToString());
                dtoMBA2P.Impendance_MBA2.SpecR_pu = double.Parse(dataRow["SpecR_pu"].ToString());
                dtoMBA2P.Impendance_MBA2.SpecX_pu = double.Parse(dataRow["SpecX_pu"].ToString());
                dtoMBA2P.Impendance_MBA2.MagG_pu = double.Parse(dataRow["MagG_pu"].ToString());
                dtoMBA2P.Impendance_MBA2.MagB_pu = double.Parse(dataRow["MagB_pu"].ToString());

                double Vol_Rated_Prim = double.Parse(dataRow["VoltageEnds_kV_Rated_Prim"].ToString());
                double Vol_Rated_Sec = double.Parse(dataRow["VoltageEnds_kV_Rated_Sec"].ToString());
                dtoMBA2P.VoltageEnds_kV_Rated = DAOGeneMBA2Record.Instance.GenerateVoltageEnds(Vol_Rated_Prim, Vol_Rated_Sec);

                dtoMBA2P.NumberTapFixed_Prim = int.Parse(dataRow["NumberTapFixed_Prim"].ToString());
                dtoMBA2P.NumberTapFixed_Sec = int.Parse(dataRow["NumberTapFixed_Sec"].ToString());

                dtoMBA2P.UnitTap_Main = (UnitTapMode)int.Parse(dataRow["UnitTap_Main"].ToString());

                dtoMBA2P.Percent_PrimFixed = double.Parse(dataRow["Percent_PrimFixed"].ToString());
                dtoMBA2P.Percent_SecFixed = double.Parse(dataRow["Percent_SecFixed"].ToString());

            }

        }
        public virtual DTOTransTwoEPower GetDTOMBA2PConsider(ConnectableE busEPower)
        {
            DTOTransTwoEPower dtoMBA2P = busEPower.DatabaseE.DataRecordE.DTOTransTwoEPower;
            return dtoMBA2P;
        }
    }
}
