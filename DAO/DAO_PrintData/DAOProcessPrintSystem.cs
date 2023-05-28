using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.DAO.DAO_PrintData
{
    public class DAOProcessPrintSystem
    {
        private static DAOProcessPrintSystem _instance;
        public static DAOProcessPrintSystem Instance
        {
            get { if (_instance == null) _instance = new DAOProcessPrintSystem(); return _instance; }
            private set {; }
        }

        private DAOProcessPrintSystem() {; }

        public virtual ReportDataSource GetReportDataSourceNode(List<ConnectableE> allEPowers)
        {
            DataSet dataSet = new DataSet();

            List<DataNodeSystem> ListDataNode = DAOGenerateListDataForPrint.Instance.GetListDataNodeSystem(allEPowers);

            DataTable dataTable = new DataTable("NodeSystem");
            dataSet.Tables.Add(dataTable);

            foreach (var propertyInfo in typeof(DataNodeSystem).GetProperties())
            {
                dataTable.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType);
            }

            foreach (DataNodeSystem item in ListDataNode)
            {
                DataRow row = dataTable.NewRow();
                foreach (var propertyInfo in typeof(DataNodeSystem).GetProperties())
                {
                    row[propertyInfo.Name] = propertyInfo.GetValue(item);
                }
                dataTable.Rows.Add(row);
            }

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataLoadMF";
            rds.Value = dataSet.Tables[0];

            return rds;

        }

        //Branch
        public virtual ReportDataSource GetReportDataSourceBranch(List<ConnectableE> allEPowers)
        {
            DataSet dataSet = new DataSet();

            List<DataBranchSystem> ListDataBranch = DAOGenerateListDataForPrint.Instance.GetListDataBranchSystem(allEPowers);

            DataTable dataTable = new DataTable("BranchSystem");
            dataSet.Tables.Add(dataTable);

            foreach (var propertyInfo in typeof(DataBranchSystem).GetProperties())
            {
                dataTable.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType);
            }

            foreach (DataBranchSystem item in ListDataBranch)
            {
                DataRow row = dataTable.NewRow();
                foreach (var propertyInfo in typeof(DataBranchSystem).GetProperties())
                {
                    row[propertyInfo.Name] = propertyInfo.GetValue(item);
                }
                dataTable.Rows.Add(row);
            }

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataLineMBA2P";
            rds.Value = dataSet.Tables[0];

            return rds;

        }
    }
}
