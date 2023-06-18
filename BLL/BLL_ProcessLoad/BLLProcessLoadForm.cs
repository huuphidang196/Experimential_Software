using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.DAO.DAO_LoadData;
using Experimential_Software.DTO;

namespace Experimential_Software.BLL.BLL_ProcessLoad
{
    public class BLLProcessLoadForm
    {
        private static BLLProcessLoadForm _instance;

        public static BLLProcessLoadForm Instance
        {
            get { if (_instance == null) _instance = new BLLProcessLoadForm(); return BLLProcessLoadForm._instance; }
            private set { _instance = value; }
        }

        private BLLProcessLoadForm() { }

        #region Text_Box
        public virtual void EventTextDataInputIsNotNumber(object sender, EventArgs e)
        {
            //Get text box is Changging
            TextBox txtDataChanged = sender as TextBox;

            // bool isAllValid = txtDataChanged.Text.Replace(".", "").Replace("-", "").All(c => char.IsDigit(c));
            bool isAllValid = double.TryParse(txtDataChanged.Text, out double result);
            if (!isAllValid)
            {
                MessageBox.Show(txtDataChanged.Text + " Invalid decimal number detected!", "Request To Re-Enter Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDataChanged.BackColor = Color.Yellow;
                txtDataChanged.Focus();
                return;
            }
            txtDataChanged.BackColor = Color.White;
        }

        #endregion Text_Box

        #region OK_Event
        public virtual  void EventOKLoad_Click(frmDataLoad frmDataLoad, DTOLoadEPower _dtoLoadRecord)
        {
            string LoadID = frmDataLoad.txtLoadID.Text;

            var Digits = LoadID.Where(c => Char.IsDigit(c));
            string result = string.Concat(Digits);

            //Set Object ID by nuumber Load ID
            int objNumber = 100 * ((int)ObjectType.Load) + int.Parse(result);

            //In Service
            bool isChecked = frmDataLoad.chkInService.Checked;

            //PLoad
            double PLoad = double.Parse(frmDataLoad.txtPLoad.Text);
            //QLoad 
            double QLoad = double.Parse(frmDataLoad.txtQLoad.Text);

            DAOGeneLoadRecord.Instance.EventOKLoad_Click(_dtoLoadRecord, LoadID, objNumber, isChecked, PLoad, QLoad);

        }
        #endregion OK_Event
    }
}
