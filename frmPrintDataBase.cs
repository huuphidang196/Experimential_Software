using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.DAO.DAO_PrintData;
using Microsoft.Reporting.WinForms;

namespace Experimential_Software
{
    public partial class frmPrintDataBase : Form
    {
        protected List<ConnectableE> _allEPowers;
        public List<ConnectableE> AllEPowers { set => _allEPowers = value; }

        public frmPrintDataBase()
        {
            InitializeComponent();
        }

        private void frmPrintDataBase_Load(object sender, EventArgs e)
        {
            if (this._allEPowers.Count > 0)
            {
                this.ProcessGenerateReportViewerNode();
                this.ProcessGenerateReportViewerBranch();
            }
        }

        //Mode
        protected virtual void ProcessGenerateReportViewerNode()
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Experimential_Software.ReportIEEESystem.rdlc";

            ReportDataSource rds = DAOProcessPrintSystem.Instance.GetReportDataSourceNode(this._allEPowers);
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }

        //Branch
        protected virtual void ProcessGenerateReportViewerBranch()
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Experimential_Software.ReportIEEESystem.rdlc";

            ReportDataSource rds = DAOProcessPrintSystem.Instance.GetReportDataSourceBranch(this._allEPowers);
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }

    }
}
