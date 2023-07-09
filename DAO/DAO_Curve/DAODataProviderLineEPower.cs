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
    public class DAODataProviderLineEPower
    {
        protected static DAODataProviderLineEPower _instance;
        public static DAODataProviderLineEPower Instance
        {
            get { if (_instance == null) _instance = new DAODataProviderLineEPower(); return _instance; }
            private set { }
        }

        private DAODataProviderLineEPower() { }

        public virtual void ExecuteQuery(ConnectableE lineEPower)
        {
            //Get DTO Line
            DTOLineEPower dtoLineEPower = this.GetDTOLineEPowerConsider(lineEPower);
            int ObjectNumber = dtoLineEPower.ObjectNumber;

            // Câu lệnh truy vấn SQL
            string query = "SELECT * from DTOLineEPower WHERE ObjectNumber = @Param";

            DataTable dataTable = DAODataProvider.Instance.ExecuteQuery(query, ObjectNumber);

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Chưa co Cơ sở dữ liệu cho Đường dây ");
                return;
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[0];

                int ObjNum = (int)dataRow["ObjectNumber"];
                // int coulumn = sqlReader.FieldCount;
                dtoLineEPower.ObjectName = dataRow["ObjectName"].ToString();
                dtoLineEPower.ImpedanceLineE.LineR_Pu = double.Parse(dataRow["LineR_Pu"].ToString());
                dtoLineEPower.ImpedanceLineE.LineX_Pu = double.Parse(dataRow["LineX_Pu"].ToString());
                dtoLineEPower.ImpedanceLineE.ChargingB_Pu = double.Parse(dataRow["ChargingB_Pu"].ToString());

                dtoLineEPower.ImpedanceLineE.LineGFrom_Pu = double.Parse(dataRow["LineGFrom_Pu"].ToString());
                dtoLineEPower.ImpedanceLineE.LineBFrom_Pu = double.Parse(dataRow["LineBFrom_Pu"].ToString());

                dtoLineEPower.ImpedanceLineE.LineGTo_Pu = double.Parse(dataRow["LineGTo_Pu"].ToString());
                dtoLineEPower.ImpedanceLineE.LineBTo_Pu = double.Parse(dataRow["LineBTo_Pu"].ToString());
                
                dtoLineEPower.ImpedanceLineE.LengthBr_KM = double.Parse(dataRow["LengthBr_KM"].ToString());

            }

        }
        public virtual DTOLineEPower GetDTOLineEPowerConsider(ConnectableE lineEPower)
        {
            DTOLineEPower dtoLineEPower = lineEPower.DatabaseE.DataRecordE.DTOLineEPower;
            return dtoLineEPower;
        }
    }
}
