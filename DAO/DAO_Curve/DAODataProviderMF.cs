using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Experimential_Software.DTO;
using System.Windows.Forms;
using System.Data;

namespace Experimential_Software.DAO.DAO_Curve
{
    public class DAODataProviderMF
    {
        protected static DAODataProviderMF _instance;
        public static DAODataProviderMF Instance
        {
            get { if (_instance == null) _instance = new DAODataProviderMF(); return _instance; }
            private set { }
        }

        private DAODataProviderMF() { }

        public virtual void ExecuteQuery(ConnectableE geneEPower)
        {
            //Get DTO Bú
            DTOGeneEPower dtoGenesEPower = this.GetDTOGeneConsider(geneEPower);
            int ObjectNumber = dtoGenesEPower.ObjectNumber;

            // Câu lệnh truy vấn SQL
            string query = "SELECT * from DTOGeneEPower WHERE ObjectNumber = @Param";

            DataTable dataTable = DAODataProvider.Instance.ExecuteQuery(query, ObjectNumber);

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Chưa co Cơ sở dữ liệu cho MF ");
                return;
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[0];

                int ObjNum = (int)dataRow["ObjectNumber"];
                // int coulumn = sqlReader.FieldCount;
                dtoGenesEPower.ObjectName = dataRow["ObjectName"].ToString();
                dtoGenesEPower.PowerMachineMF.Pgen_MW = double.Parse(dataRow["Pgen_MW"].ToString());
                dtoGenesEPower.PowerMachineMF.Pmax_MW = double.Parse(dataRow["Pmax_MW"].ToString());
                dtoGenesEPower.PowerMachineMF.Pmin_MW = double.Parse(dataRow["Pmin_MW"].ToString());
                dtoGenesEPower.PowerMachineMF.Qgen_Mvar = double.Parse(dataRow["Qgen_Mvar"].ToString());
                dtoGenesEPower.PowerMachineMF.Qmax_Mvar = double.Parse(dataRow["Qmax_Mvar"].ToString());
                dtoGenesEPower.PowerMachineMF.Qmin_Mvar = double.Parse(dataRow["Qmin_Mvar"].ToString());
                dtoGenesEPower.PowerMachineMF.MBase = double.Parse(dataRow["MBase"].ToString());
                dtoGenesEPower.PowerMachineMF.RSource_pu = double.Parse(dataRow["RSource_pu"].ToString());
                dtoGenesEPower.PowerMachineMF.XSource_pu = double.Parse(dataRow["XSource_pu"].ToString());
            }

        }
        public virtual DTOGeneEPower GetDTOGeneConsider(ConnectableE busEPower)
        {
            DTOGeneEPower dtoGeneEPower = busEPower.DatabaseE.DataRecordE.DTOGeneEPower;
            return dtoGeneEPower;
        }
    }
}
