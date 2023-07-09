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
    public class DAODataProviderLoad
    {
        protected static DAODataProviderLoad _instance;
        public static DAODataProviderLoad Instance
        {
            get { if (_instance == null) _instance = new DAODataProviderLoad(); return _instance; }
            private set { }
        }

        private DAODataProviderLoad() { }

        public virtual void ExecuteQuery(ConnectableE lineEPower)
        {
            //Get DTO Load
            DTOLoadEPower dtoLoad = this.GetDTOLoadConsider(lineEPower);
            int ObjectNumber = dtoLoad.ObjectNumber;

            // Câu lệnh truy vấn SQL
            string query = "SELECT * from DTOLoadEPower WHERE ObjectNumber = @Param";

            DataTable dataTable = DAODataProvider.Instance.ExecuteQuery(query, ObjectNumber);

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Chưa co Cơ sở dữ liệu cho phụ tải ");
                return;
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[0];

                int ObjNum = (int)dataRow["ObjectNumber"];
                // int coulumn = sqlReader.FieldCount;
                dtoLoad.ObjectName = dataRow["ObjectName"].ToString();
                dtoLoad.PLoad = double.Parse(dataRow["PLoad"].ToString());
                dtoLoad.QLoad = double.Parse(dataRow["QLoad"].ToString());
                dtoLoad.SBase = double.Parse(dataRow["SBase"].ToString());

            }

        }
        public virtual DTOLoadEPower GetDTOLoadConsider(ConnectableE busEPower)
        {
            DTOLoadEPower dtoLoad = busEPower.DatabaseE.DataRecordE.DTOLoadEPower;
            return dtoLoad;
        }
    }
}
