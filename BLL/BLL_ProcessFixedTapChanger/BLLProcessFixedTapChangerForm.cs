using Experimential_Software.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software.BLL.BLL_ProcessFixedTapChanger
{
    public class BLLProcessFixedTapChangerForm
    {

        private static BLLProcessFixedTapChangerForm _instance;

        public static BLLProcessFixedTapChangerForm Instance
        {
            get { if (_instance == null) _instance = new BLLProcessFixedTapChangerForm(); return BLLProcessFixedTapChangerForm._instance; }
            private set { _instance = value; }
        }

        private BLLProcessFixedTapChangerForm() { }


        #region Check_TextBox_Controls
        public virtual void CheckKeyPressIsNumber(object sender, KeyPressEventArgs e, frmFixedTapChanger frmFixedTapChanger)
        {
            TextBox txtDataChanged = sender as TextBox;
            if (txtDataChanged == frmFixedTapChanger.txtCountTap)
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

        public void TextLeaveEvent(object sender, EventArgs e, frmFixedTapChanger frmFixedTapChanger)
        {
            TextBox txtDataChanger = sender as TextBox;
            //Count number Tap Changer
            frmFixedTapChanger.CountTC = int.Parse(frmFixedTapChanger.txtCountTap.Text);
            if (txtDataChanger.Text == "" || txtDataChanger.Text == "-")
            {
                MessageBox.Show("Field cannot be empty!", "Warning Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDataChanger.BackColor = Color.Yellow;
                txtDataChanger.Focus();
                return;
            }

            if (frmFixedTapChanger.UnitModeRange == UnitTapMode.Percent)
            {
                //Min Volatage . if Percent => directly set
                frmFixedTapChanger.MinRanger_Per = 1 + (double.Parse(frmFixedTapChanger.txtMinEnds.Text) / 100);
                //max Voltage
                frmFixedTapChanger.MaxRanger_Per = 1 + (double.Parse(frmFixedTapChanger.txtMaxEnds.Text) / 100);

                //Show Again
                frmFixedTapChanger.ShowDataTapRangerEndsOnForm();
                return;
            }

            //=> kV Mode
            //Min Volatage . Both Round 3 digit beacause kv => 3 digit
            double Vol_Min_kV = Math.Round(double.Parse(frmFixedTapChanger.txtMinEnds.Text), 3);
            //Round 3 digit text kv unit
            frmFixedTapChanger.txtMinEnds.Text = Vol_Min_kV + "";
            frmFixedTapChanger.MinRanger_Per = Vol_Min_kV / frmFixedTapChanger.DTOTapRanger.Voltage_TapZero_ByRated;

            //max Voltage
            double Vol_Max_kV = double.Parse(frmFixedTapChanger.txtMaxEnds.Text);
            //Round 3 digit text kv unit
            frmFixedTapChanger.txtMaxEnds.Text = Vol_Max_kV + "";
            frmFixedTapChanger.MaxRanger_Per = Vol_Max_kV / frmFixedTapChanger.DTOTapRanger.Voltage_TapZero_ByRated;

            txtDataChanger.BackColor = Color.WhiteSmoke;
            //Show Again
            frmFixedTapChanger.ShowDataTapRangerEndsOnForm();
        }
        #endregion Check_TextBox_Controls
    }
}
