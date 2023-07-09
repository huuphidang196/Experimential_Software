using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Experimential_Software.DAO.DAO_Curve
{
    public class DAODataProvider
    {
        protected static DAODataProvider _instance;
        public static DAODataProvider Instance
        {
            get { if (_instance == null) _instance = new DAODataProvider(); return _instance; }
            private set { }
        }

        private DAODataProvider() { }

        private string _sqlConnection = "Server=DANGHUUPHI\\MSSQLSERVER01;Database=CSDL_DATAHTD;user=huuphidang2804;pwd=19062001Phi@";

        public DataTable ExecuteQuery(string query, int ObjectNumber)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(_sqlConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                // Thêm tham số cho câu lệnh truy vấn
                command.Parameters.AddWithValue("@Param", ObjectNumber);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

                connection.Close();
            }
            return dataTable;
        }
    }
}
