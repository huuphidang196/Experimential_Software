using Experimential_Software.DAO.DAO_GeneratorData;
using Experimential_Software.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software.BLL.BLL_ProcessGenerator
{
    public class BLLProcessGeneratorForm
    {
        private static BLLProcessGeneratorForm _instance;

        public static BLLProcessGeneratorForm Instance
        {
            get { if (_instance == null) _instance = new BLLProcessGeneratorForm(); return BLLProcessGeneratorForm._instance; }
            private set { _instance = value; }
        }

        private BLLProcessGeneratorForm() { }

        #region Event_TextBox_Leave
        public virtual void CheckNumberValidTextBoxEventLeave(object sender)
        {
            //Get text box is Changging
            TextBox txtDataChanged = sender as TextBox;

            // bool isAllValid = txtDataChanged.Text.Replace(".", "").Replace("-", "").All(c => char.IsDigit(c));
            bool isAllValid = double.TryParse(txtDataChanged.Text, out double result);
            if (!isAllValid)
            {
                MessageBox.Show(txtDataChanged.Text + " Invalid decimal number detected!!", "Request To Re-Enter Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDataChanged.BackColor = Color.Yellow;
                txtDataChanged.Focus();
                return;
            }
            txtDataChanged.BackColor = Color.White;
        }

        #endregion Event_TextBox_Leave

        #region Ok_Set_Data
        public virtual void OK_Event_Click(frmDataGenerator frmDataGenerator, DTOGeneEPower _dtoMFRecord)
        {
            //***********Basic Data And Machine***********
            //Bus Connected is set when lineconnected Success
            DAOGeneMFRecord.Instance.UpdateBasicAndMachineDataForDatabaseMF(frmDataGenerator, _dtoMFRecord);

            //***********Transformer Data************
            DAOGeneMFRecord.Instance.UpdateTranDataForDatabaseMF(frmDataGenerator, _dtoMFRecord);

            //***********Wind Data And PlantData***********
            DAOGeneMFRecord.Instance.UpdateWindAndPlantDataForDatabaseMF(frmDataGenerator, _dtoMFRecord);
        }
        #endregion Ok_Set_Data

    }
}
