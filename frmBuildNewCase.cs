using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.DTO;

namespace Experimential_Software
{
    public partial class frmBuildNewCase : Form
    {
        protected DTODataPowerSystem _dtoPowerSystem;
        public DTODataPowerSystem DTPPowerSystem { set => _dtoPowerSystem = value; }

        public frmBuildNewCase()
        {
            InitializeComponent();
        }

        private void frmBuildNewCase_Load(object sender, EventArgs e)
        {
            if (this._dtoPowerSystem != null)
            {
                this.ShowDataOnForm();
            }  
        }

        protected virtual void ShowDataOnForm()
        {
            //txt Base MVA
            this.txtBaseMVA.Text = this._dtoPowerSystem.PowreBase_S_MVA + "";
            //txt Frequency
            this.txtFrequency.Text = this._dtoPowerSystem.Frequency_System_Hz + "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //set Base MVA
            this._dtoPowerSystem.PowreBase_S_MVA = double.Parse(this.txtBaseMVA.Text);
            //Set Frequency
            this._dtoPowerSystem.Frequency_System_Hz = double.Parse(this.txtFrequency.Text);

            DialogResult = DialogResult.OK;
        }

        private void EventLeaceTextBox(object sender, EventArgs e)
        {
            TextBox txtDataChanged = sender as TextBox;
            bool isNumber = double.TryParse(txtDataChanged.Text, out double result);
            if (!isNumber)
            {
                MessageBox.Show(txtDataChanged.Text + " is inValid", "Warning Eror!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDataChanged.BackColor = Color.Yellow;
                txtDataChanged.Focus();
            }
            txtDataChanged.BackColor = Color.White;
        }
    }
}
