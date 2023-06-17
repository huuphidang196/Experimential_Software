
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.CustomControl;
using Experimential_Software.DAO.DAO_BusData;
using Experimential_Software.DTO;

namespace Experimential_Software.BLL.BLL_ProcessBus
{
    public class BLLProcessBusForm
    {
        private static BLLProcessBusForm _instance;

        public static BLLProcessBusForm Instance
        {
            get { if (_instance == null) _instance = new BLLProcessBusForm(); return BLLProcessBusForm._instance; }
            private set { _instance = value; }
        }

        private BLLProcessBusForm() { }


        public virtual void AddItemForComboboxCBOTypeBus(ComboBox cboTypeBus)
        {
            //loadCBo typeBus
            foreach (TypeCodeBus type in Enum.GetValues(typeof(TypeCodeBus)))
            {
                string typeBus = type.ToString();
                int numberType = (int)type + 1;
                cboTypeBus.Items.Add(numberType + " -" + typeBus);
            }
        }
        #region Text_Box
        public void EventInputTextDataIsNotNumber(object sender, EventArgs e, frmDataBus frmDataBus)
        {
            //Get text box is Changging
            TextBox txtDataChanged = sender as TextBox;

            bool isAllValid = double.TryParse(txtDataChanged.Text, out double result);
            if (!isAllValid)
            {
                MessageBox.Show(txtDataChanged.Text + " Invalid decimal number detected!", "Request To Re-Enter Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDataChanged.BackColor = Color.Yellow;
                txtDataChanged.Focus();
                return;
            }
            this.EventLeaveTextBoxLimitDataZone(frmDataBus);
            txtDataChanged.BackColor = Color.White;
        }

        protected virtual bool EventLeaveTextBoxLimitDataZone(frmDataBus frmDataBus)
        {
            //txtNormal_Vmax
            double Normal_Vmax_pu = double.Parse(frmDataBus.txtNorVmax.Text);
            //txtEmer Max
            double Emer_Vmax_pu = double.Parse(frmDataBus.txtEmerVmax.Text);

            if (Emer_Vmax_pu < Normal_Vmax_pu)
            {
                MessageBox.Show("NormalVmax(pu) must be less EmerVmax(pu)!", "Request To Re-Enter Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmDataBus.txtNorVmax.BackColor = frmDataBus.txtEmerVmax.BackColor = Color.Yellow;
                return false;
            }

            frmDataBus.txtNorVmax.BackColor = frmDataBus.txtEmerVmax.BackColor = Color.WhiteSmoke;

            //txtNormal_Vmin
            double Normal_Vmin_pu = double.Parse(frmDataBus.txtNorVmin.Text);
            //txtEmer Min
            double Emer_Vmin_pu = double.Parse(frmDataBus.txtEmerVmin.Text);

            if (Emer_Vmin_pu > Normal_Vmin_pu)
            {
                MessageBox.Show("NormalVmin(pu) must be Greater EmerVmin(pu)!", "Request To Re-Enter Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmDataBus.txtNorVmin.BackColor = frmDataBus.txtEmerVmin.BackColor = Color.Yellow;
                return false;
            }
            frmDataBus.txtNorVmin.BackColor = frmDataBus.txtEmerVmin.BackColor = Color.WhiteSmoke;
            return true;
        }

        #endregion Text_Box

        #region OK_Event
        public virtual void OK_ClickEvent(frmDataBus frmDataBus, DTOBusEPower _dtoBusRecord)
        {
            DAOGeneBusRecord.Instance.SetObjectRecordInDataBase(frmDataBus, _dtoBusRecord);
            this.ProcessUpdateNameBusForLineConnected(frmDataBus.BusEPowerFixed);
        }    
        public virtual void ProcessUpdateNameBusForLineConnected(ConnectableE busConsidered)
        {
            List<LineConnect> listLineDrawn = busConsidered.ListBranch_Drawn;

            if (listLineDrawn.Count == 0) return;

            DAOGeneBusRecord.Instance.AddEPowerOnList(ObjectType.LineEPower, listLineDrawn);
        }

     


        #endregion OK_Event
    }
}
