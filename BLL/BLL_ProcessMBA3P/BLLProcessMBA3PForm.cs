using Experimential_Software.DAO.DAO_MBA3Data;
using Experimential_Software.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software.BLL.BLL_ProcessMBA3P
{
    public class BLLProcessMBA3PForm
    {
        private static BLLProcessMBA3PForm _instance;

        public static BLLProcessMBA3PForm Instance
        {
            get { if (_instance == null) _instance = new BLLProcessMBA3PForm(); return BLLProcessMBA3PForm._instance; }
            private set { _instance = value; }
        }

        private BLLProcessMBA3PForm() { }

        #region Leave_TextBox
        //OVerall for Impedance, objectMBA3P, Volatage
        public virtual void TextBoxLeaveValidNumber(object sender)
        {
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
        //Voltage Rated
        public virtual void TextBoxRatedLeave(object sender, frmDataMBA3 frmDataMBA3)
        {
            //Check Valid number
            this.TextBoxLeaveValidNumber(sender);

            //Show Again Fixed Zone when voltage rated changed
            this.ProcessEventVoltageFixedChange(frmDataMBA3);
        }

        //Apply for VoltageFixed
        public virtual void TextBoxVolFixed_Leave(object sender, frmDataMBA3 frmDataMBA3)
        {
            //Check Valid number
            this.TextBoxLeaveValidNumber(sender);

            // Valid => Show Again Voltage Fixed
            this.ProcessEventVoltageFixedChange(frmDataMBA3);

        }

        protected virtual void ProcessEventVoltageFixedChange(frmDataMBA3 frmDataMBA3)
        {
            this.SetPercentTemp(frmDataMBA3);

            this.SetVoltageFixed(frmDataMBA3);
        }


        protected virtual void SetVoltageFixed(frmDataMBA3 frmDataMBA3)
        {
            //Show Again Fixed Zone when voltage rated changed
            VoltageEnds3P voltageRated3P = DAOGeneMBA3Record.Instance.GenerateVoltageEndsByText(frmDataMBA3.txtRatedkV_Prim.Text, frmDataMBA3.txtRatedkV_Ter.Text, frmDataMBA3.txtRatedkV_Sec.Text);
            VoltageEnds3P voltageFixed3P = DAOGeneMBA3Record.Instance.GenerateVoltageEndsFixedByUnitMode(frmDataMBA3.PerFixedPrimTemp_100, frmDataMBA3.PerFixedTerTemp_100, frmDataMBA3.PerFixedSecTemp_100, voltageRated3P);
            frmDataMBA3.ShowFixedVolatgeKVBySpecVoltage(voltageFixed3P);

        }

        protected virtual void SetPercentTemp(frmDataMBA3 frmDataMBA3)
        {
            //Set Per temp in order to Show VoltageFixed Use
            frmDataMBA3.PerFixedPrimTemp_100 = DAOGeneMBA3Record.Instance.GetPercentVoltageFixedDisplayOneHundredPercent(frmDataMBA3.txtVolFixedPrim.Text, frmDataMBA3.txtRatedkV_Prim.Text, frmDataMBA3.UnitModeMain);
            frmDataMBA3.PerFixedTerTemp_100 = DAOGeneMBA3Record.Instance.GetPercentVoltageFixedDisplayOneHundredPercent(frmDataMBA3.txtVolFixedTer.Text, frmDataMBA3.txtRatedkV_Ter.Text, frmDataMBA3.UnitModeMain);
            frmDataMBA3.PerFixedSecTemp_100 = DAOGeneMBA3Record.Instance.GetPercentVoltageFixedDisplayOneHundredPercent(frmDataMBA3.txtVolFixedSec.Text, frmDataMBA3.txtRatedkV_Sec.Text, frmDataMBA3.UnitModeMain);
        }

        #endregion Leave_TextBox

        public virtual void EventTransUnit_Click(frmDataMBA3 frmDataMBA3)
        {
            frmDataMBA3.UnitModeMain = (frmDataMBA3.UnitModeMain == UnitTapMode.Percent) ? UnitTapMode.KV_Number : UnitTapMode.Percent;

            this.SetVoltageFixed(frmDataMBA3);
        }

        #region OK_Event_Set_Data
        public virtual void EventOK_Click(frmDataMBA3 frmDataMBA3)
        {
            //Set Zone Basic Data
            this.SetZoneBasicData(frmDataMBA3);
            //Transformer Impedance Data
            this.SetZoneImpedanceData(frmDataMBA3);
            //Set Zone Transformer Data
            this.SetZoneTransformerData(frmDataMBA3);
            //SetZone Fixed Tap
            this.SetZoneFixedTap(frmDataMBA3);
            //Descreiption
            frmDataMBA3.DTOMBA3P.Description = frmDataMBA3.rtbDescription.Text;
        }


        protected virtual void SetZoneBasicData(frmDataMBA3 frmDataMBA3)
        {
            //this MBA3P
            DTOTransThreeEPower dtoMBA3P = frmDataMBA3.DTOMBA3P;
            //Object Number
            int ObjectNumber = int.Parse(frmDataMBA3.txtTrans3PNumber.Text);
            //Object Name
            string ObjectName = frmDataMBA3.txtTrans3PName.Text;
            //Set index  InService
            int index_InService = frmDataMBA3.cboInService.SelectedIndex;

            DAOUpdateImpendanceMBA3WhenChangeTap.Instance.SetZoneBasicData(dtoMBA3P, ObjectNumber, ObjectName, index_InService);
        }

        protected virtual void SetZoneImpedanceData(frmDataMBA3 frmDataMBA3)
        {
            DTOTransThreeEPower dtoMBA3P = frmDataMBA3.DTOMBA3P;

            //SpecRX Prim
            double SpecR_Prim = double.Parse(frmDataMBA3.txtSpecR_Prim.Text);
            double SpecX_Prim = double.Parse(frmDataMBA3.txtSpecX_Prim.Text);

            //SpecRX Tertiary
            double SpecR_Ter = double.Parse(frmDataMBA3.txtSpecR_Ter.Text);
            double SpecX_Ter = double.Parse(frmDataMBA3.txtSpecX_Ter.Text);

            //SpecRX Sec
            double SpecR_Sec = double.Parse(frmDataMBA3.txtSpecR_Sec.Text);
            double SpecX_Sec = double.Parse(frmDataMBA3.txtSpecX_Sec.Text);

            //Mag G,B
            double MagG = double.Parse(frmDataMBA3.txtMagG.Text);
            double MagB = double.Parse(frmDataMBA3.txtMagB.Text);

            DAOUpdateImpendanceMBA3WhenChangeTap.Instance.SetZoneImpedanceData(dtoMBA3P, SpecR_Prim, SpecX_Prim, SpecR_Ter, SpecX_Ter, SpecR_Sec, SpecX_Sec, MagG, MagB);

        }

        protected virtual void SetZoneTransformerData(frmDataMBA3 frmDataMBA3)
        {
            DTOTransThreeEPower dtoMBA3P = frmDataMBA3.DTOMBA3P;

            //MVA base Prim
            double BaseMVA_Prim = double.Parse(frmDataMBA3.txtBaseMVA_Prim.Text);
            //MVA base Ter
            double BaseMVA_Ter = double.Parse(frmDataMBA3.txtBaseMVA_Ter.Text);
            //MVA base Sec 
            double BaseMVA_Sec = double.Parse(frmDataMBA3.txtBaseMVA_Sec.Text);

            //Volatage Rated
            double vol_ratedPrim = double.Parse(frmDataMBA3.txtRatedkV_Prim.Text);
            double vol_ratedTer = double.Parse(frmDataMBA3.txtRatedkV_Ter.Text);
            double vol_ratedSec = double.Parse(frmDataMBA3.txtRatedkV_Sec.Text);

            DAOUpdateImpendanceMBA3WhenChangeTap.Instance.SetZoneTransformerData(dtoMBA3P, BaseMVA_Prim, BaseMVA_Ter, BaseMVA_Sec, vol_ratedPrim, vol_ratedTer, vol_ratedSec);
        }

        protected virtual void SetZoneFixedTap(frmDataMBA3 frmDataMBA3)
        {
            DTOTransThreeEPower dtoMBA3P = frmDataMBA3.DTOMBA3P;

            dtoMBA3P.UnitTap_Main = frmDataMBA3.UnitModeMain;
            double Percent_PrimFixed = 1;
            double Percent_TerFixed = 1;
            double Percent_SecFixed = 1;
            //Only Save Per for Fixed Tap
            Percent_PrimFixed = (frmDataMBA3.UnitModeMain == UnitTapMode.Percent) ? (1 + double.Parse(frmDataMBA3.txtVolFixedPrim.Text) / 100) : (1 + frmDataMBA3.PerFixedPrimTemp_100 / 100);
            Percent_TerFixed = (frmDataMBA3.UnitModeMain == UnitTapMode.Percent) ? (1 + double.Parse(frmDataMBA3.txtVolFixedTer.Text) / 100) : (1 + frmDataMBA3.PerFixedTerTemp_100 / 100);
            Percent_SecFixed = (frmDataMBA3.UnitModeMain == UnitTapMode.Percent) ? (1 + double.Parse(frmDataMBA3.txtVolFixedSec.Text) / 100) : (1 + frmDataMBA3.PerFixedSecTemp_100 / 100);


            DAOUpdateImpendanceMBA3WhenChangeTap.Instance.SetZoneFixedTap(dtoMBA3P, Percent_PrimFixed, Percent_TerFixed, Percent_SecFixed);
        }


        #endregion OK_Event_Set_Data

    }
}
