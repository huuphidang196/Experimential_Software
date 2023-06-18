using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.BLL.BLL_ProcessFixedTapChanger;
using Experimential_Software.DTO;

namespace Experimential_Software
{
    public partial class frmFixedTapChanger : Form
    {
        //DTO Tap Ranger Prim or Sec
        protected DTOTransTwoTapRanger _dtoTapRanger;
        public DTOTransTwoTapRanger DTOTapRanger { get => _dtoTapRanger; set => _dtoTapRanger = value; }

        //Generate specified variable => changed immidiatly when user complete data text
        protected UnitTapMode _unitModeRange = UnitTapMode.Percent;
        public UnitTapMode UnitModeRange => _unitModeRange;

        protected double _minRanger_Per = 0;
        public double MinRanger_Per { get => _minRanger_Per; set => _minRanger_Per = value; }

        protected double _maxRanger_Per = 0;
        public double MaxRanger_Per { get => _maxRanger_Per; set => _maxRanger_Per = value; }

        protected int _countTC = 0;
        public int CountTC { get => _countTC; set => _countTC = value; }

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
        public virtual void ShowDataTapRangerEndsOnForm()
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
            this._unitModeRange = (this._unitModeRange == UnitTapMode.Percent) ? UnitTapMode.KV_Number : UnitTapMode.Percent;

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
            BLLProcessFixedTapChangerForm.Instance.CheckKeyPressIsNumber(sender, e, this);
        }

        private void TextLeaveEvent(object sender, EventArgs e)
        {
            BLLProcessFixedTapChangerForm.Instance.TextLeaveEvent(sender, e, this);
        }
        #endregion Check_TextBox_Controls
    }
}
