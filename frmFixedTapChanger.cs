using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.Class_Database;

namespace Experimential_Software
{
    public partial class frmFixedTapChanger : Form
    {
        //DTO Tap Ranger Prim or Sec
        protected DTOTransTwoTapRanger _dtoTapRanger;
        public DTOTransTwoTapRanger DTOTapRanger { get => _dtoTapRanger; set => _dtoTapRanger = value; }

        //Generate specified variable => changed immidiatly when user complete data text
        protected UnitTapMode _unitModeRange = UnitTapMode.Percent;
        protected double _minRanger_Per = 0;
        protected double _maxRanger_Per = 0;
        protected int _countTC = 0;
        public frmFixedTapChanger()
        {
            InitializeComponent();
        }

        private void frmFixedTapChanger_Load(object sender, EventArgs e)
        {
            this.txtMaxEnds.MaxLength = 8;
            this.txtMinEnds.MaxLength = 8;
            this.txtCountTap.MaxLength = 2;

            if (this._dtoTapRanger != null)
            {
                //Show Data On form by unit Mode
                this._unitModeRange = this._dtoTapRanger.UnitTap_Ranger;

                //Update Variable Origin text Min
                this._minRanger_Per = this._dtoTapRanger.MinRanger_Per;
                this._maxRanger_Per = this._dtoTapRanger.MaxRanger_Per;
                this._countTC = this._dtoTapRanger.CountTapChanger;

                this.ShowDataTapRangerEndsOnForm();
            }
        }
        protected virtual void ShowDataTapRangerEndsOnForm()
        {
            double vol_TapZero_ByRated = this._dtoTapRanger.Voltage_TapZero_ByRated;

            //Count Tap Ranger
            this.txtCountTap.Text = this._countTC + "";

            //unit Mode =? Percent %
            //Set Text button Unit => % Tap
            this.btnTCUnitRanger.Text = (this._unitModeRange == UnitTapMode.Percent) ? "% Tap" : "kV Tap";

            //txt Min
            this.txtMinEnds.Text = (this._unitModeRange == UnitTapMode.Percent) ? Math.Round((this._minRanger_Per * 100 - 100), 4) + "" : Math.Round(this._minRanger_Per * vol_TapZero_ByRated, 3) + "";
            //txt Max
            this.txtMaxEnds.Text = (this._unitModeRange == UnitTapMode.Percent) ? Math.Round((this._maxRanger_Per * 100 - 100), 4) + "" : Math.Round(this._maxRanger_Per * vol_TapZero_ByRated, 3) + "";

            //Step = (max - min)/count Tap . Ignore percen or kV same equation
            double step = (this._maxRanger_Per - this._minRanger_Per) / (this._countTC - 1);//=> double < 1
            this.lblStepTC.Text = (this._unitModeRange == UnitTapMode.Percent) ? Math.Round((100 * step), 4) + "" : Math.Round(step * vol_TapZero_ByRated, 3) + "";

            //*******Show data TransColumn => kV********
            this.lblTransUnitRanger.Text = (this._unitModeRange == UnitTapMode.Percent) ? "kV Tap" : "% Tap";
            //lbl TransMin
            this.lblTapTransMin.Text = (this._unitModeRange == UnitTapMode.Percent) ? Math.Round(this._minRanger_Per * vol_TapZero_ByRated, 3) + "" : Math.Round((this._minRanger_Per * 100 - 100), 4) + "";
            //lblTransMax
            this.lblTapTransMax.Text = (this._unitModeRange == UnitTapMode.Percent) ? Math.Round(this._maxRanger_Per * vol_TapZero_ByRated, 3) + "" : Math.Round((this._maxRanger_Per * 100 - 100), 4) + "";
            //label lbl Step
            this.lblTapTransStep.Text = (this._unitModeRange == UnitTapMode.Percent) ? Math.Round(step * vol_TapZero_ByRated, 3) + "" : Math.Round((100 * step), 4) + "";
        }

        #region Event_Button_On_Form
        private void btnTCUnitRanger_MouseDown(object sender, MouseEventArgs e)
        {
            if (this._unitModeRange == UnitTapMode.Percent) this._unitModeRange = UnitTapMode.KV_Number;
            else this._unitModeRange = UnitTapMode.Percent;

            //Show Again 
            this.ShowDataTapRangerEndsOnForm();
        }

        private void btnOkTapRanger_Click(object sender, EventArgs e)
        {
            //Set Number Cunt Tap Ranger
            this._dtoTapRanger.CountTapChanger = this._countTC;

            //Set Voltage Min => Percent
            this._dtoTapRanger.MinRanger_Per = this._minRanger_Per;
            //Set Volatage Max => percent
            this._dtoTapRanger.MaxRanger_Per = this._maxRanger_Per;

            DialogResult = DialogResult.OK;
        }


        private void btnCanceltapRanger_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Event_Button_On_Form


        #region Check_TextBox_Controls
        private void CheckKeyPressIsNumber(object sender, KeyPressEventArgs e)
        {
            TextBox txtDataChanged = sender as TextBox;
            if (txtDataChanged == this.txtCountTap)
            {
                //txt Count is not negative and is not double type
                if (e.KeyChar == '.' || e.KeyChar == '-') e.Handled = true;

                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b') e.Handled = true;
                return;
            }

            // Kiểm tra xem ký tự vừa nhập vào có phải là số hoặc dấu chấm hay không
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b' && e.KeyChar != '-')
            {
                e.Handled = true; // Không cho phép nhập ký tự này
            }

            // Chỉ cho phép nhập một dấu chấm
            if (e.KeyChar == '.' && txtDataChanged.Text.IndexOf('.') > -1 || e.KeyChar == '-' && txtDataChanged.Text.IndexOf('-') > -1)
            {
                e.Handled = true; // Không cho phép nhập ký tự này
            }
        }

        private void TextLeaveEvent(object sender, EventArgs e)
        {
            TextBox txtDataChanger = sender as TextBox;
            //Count number Tap Changer
            this._countTC = int.Parse(this.txtCountTap.Text);
            if (txtDataChanger.Text == "" || txtDataChanger.Text == "-")
            {
                MessageBox.Show("Field cannot be empty!", "Warning Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDataChanger.BackColor = Color.Yellow;
                txtDataChanger.Focus();
                return;
            }

            if (this._unitModeRange == UnitTapMode.Percent)
            {
                //Min Volatage . if Percent => directly set
                this._minRanger_Per = 1 + (double.Parse(this.txtMinEnds.Text) / 100);
                //max Voltage
                this._maxRanger_Per = 1 + (double.Parse(this.txtMaxEnds.Text) / 100);

                //Show Again
                this.ShowDataTapRangerEndsOnForm();
                return;
            }

            //=> kV Mode
            //Min Volatage . Both Round 3 digit beacause kv => 3 digit
            double Vol_Min_kV = Math.Round(double.Parse(this.txtMinEnds.Text), 3);
            //Round 3 digit text kv unit
            this.txtMinEnds.Text = Vol_Min_kV + "";
            this._minRanger_Per = Vol_Min_kV / this._dtoTapRanger.Voltage_TapZero_ByRated;

            //max Voltage
            double Vol_Max_kV = double.Parse(this.txtMaxEnds.Text);
            //Round 3 digit text kv unit
            this.txtMaxEnds.Text = Vol_Max_kV + "";
            this._maxRanger_Per = Vol_Max_kV / this._dtoTapRanger.Voltage_TapZero_ByRated;

            txtDataChanger.BackColor = Color.WhiteSmoke;
            //Show Again
            this.ShowDataTapRangerEndsOnForm();
        }
        #endregion Check_TextBox_Controls
    }
}
