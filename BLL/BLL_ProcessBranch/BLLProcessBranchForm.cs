using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.DAO.DAO_LineData;
using Experimential_Software.DTO;

namespace Experimential_Software.BLL.BLL_ProcessBranch
{
    public class BLLProcessBranchForm
    {
        private static BLLProcessBranchForm _instance;

        public static BLLProcessBranchForm Instance
        {
            get { if (_instance == null) _instance = new BLLProcessBranchForm(); return BLLProcessBranchForm._instance; }
            private set { _instance = value; }
        }

        private BLLProcessBranchForm() { }

        public virtual void ProcessOkEvent(frmDataBranch frmDataBranch, DTOLineEPower dtoLineEPowerRecord)
        {
            DAOGeneLineRecord.Instance.SetBranchRecordInDataBase(frmDataBranch, dtoLineEPowerRecord);
        }
        public virtual void EventDataIputIsNotNumber(object sender, frmDataBranch frmDataBranch)
        {
            //Get text box is Changging
            TextBox txtDataChanged = sender as TextBox;

            bool isAllValid = double.TryParse(txtDataChanged.Text, out double result);
            if (!isAllValid)
            {
                MessageBox.Show(txtDataChanged.Text + "Invalid decimal number detected!", "Request To Re-Enter Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDataChanged.BackColor = Color.Yellow;
                txtDataChanged.Focus();
                return;
            }
            txtDataChanged.BackColor = Color.White;

            if (txtDataChanged == frmDataBranch.txtChargingBPu)
            {
                double chargingBpu = double.Parse(frmDataBranch.txtChargingBPu.Text);
                if (chargingBpu == 0) return;
                frmDataBranch.txtLineBFromPu.Text = chargingBpu / 2 + "";
                frmDataBranch.txtLineBToPu.Text = chargingBpu / 2 + "";
            }
        }
    }
}
