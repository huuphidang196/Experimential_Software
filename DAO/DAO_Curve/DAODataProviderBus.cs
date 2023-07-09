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
    public class DAODataProviderBus
    {
        protected static DAODataProviderBus _instance;
        public static DAODataProviderBus Instance
        {
            get { if (_instance == null) _instance = new DAODataProviderBus(); return _instance; }
            private set { }
        }

        private DAODataProviderBus() { }

        public virtual void ExecuteQuery(ConnectableE busEPower)
        {
            //Get DTO Bú
            DTOBusEPower dtoBusEPower = this.GetDTOBusConsider(busEPower);
            int ObjectNumber = dtoBusEPower.ObjectNumber;

            // Câu lệnh truy vấn SQL
            string query = "SELECT * from DTOBusEPower WHERE ObjectNumber = @Param";

            DataTable dataTable = DAODataProvider.Instance.ExecuteQuery(query, ObjectNumber);

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Chưa co Cơ sở dữ liệu cho Bus ");
                return;
            } 
                
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[0];

                int ObjNum = (int)dataRow["ObjectNumber"];
                // int coulumn = sqlReader.FieldCount;
                dtoBusEPower.ObjectName = dataRow["ObjectName"].ToString();
                dtoBusEPower.TypeCodeBus = (TypeCodeBus)dataRow["TypeCodeBus"];
                dtoBusEPower.BasekV = double.Parse(dataRow["BasekV"].ToString());
                dtoBusEPower.Voltage_pu = double.Parse(dataRow["Voltage_pu"].ToString());
                dtoBusEPower.Angle_rad = double.Parse(dataRow["Angle_rad"].ToString());
                dtoBusEPower.Normal_Vmax_pu = double.Parse(dataRow["Normal_Vmax_pu"].ToString());
                dtoBusEPower.Normal_Vmin_pu = double.Parse(dataRow["Normal_Vmin_pu"].ToString());
                dtoBusEPower.Emer_Vmax_pu = double.Parse(dataRow["Emer_Vmax_pu"].ToString());
                dtoBusEPower.Emer_Vmin_pu = double.Parse(dataRow["Emer_Vmin_pu"].ToString());
            }
          
        }
        public virtual DTOBusEPower GetDTOBusConsider(ConnectableE busEPower)
        {
            DTOBusEPower dtoBusEPower = busEPower.DatabaseE.DataRecordE.DTOBusEPower;
            return dtoBusEPower;
        }
    }
}
