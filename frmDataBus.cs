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
    public partial class frmDataBus : Form
    {
        // Require have before Initialize
        protected ConnectableE _ePowerFixed;
        public ConnectableE EPowerFixed { set => _ePowerFixed = value; }

        protected DatabaseEPower _databaseEPower;

        public frmDataBus()
        {
            InitializeComponent();
       
        }

        private void frmDataBus_Load(object sender, EventArgs e)
        {

            if (this._ePowerFixed != null) this._databaseEPower = this._ePowerFixed.DatabaseE;
            this.SetDataFormEPowerOrigin();

        }

        #region Show_Data_Origin
        protected virtual void SetDataFormEPowerOrigin()
        {
            this.lblObjNum.Text = this._databaseEPower.ObjectNumber + "";
        }

        #endregion Show_Data_Origin

        #region Update_DataBase

        private void btnOKSet_Click(object sender, EventArgs e)
        {
            //set Object name
            this.SetObjectNameInDataBase();

            this.DialogResult = DialogResult.OK;
        }

        protected virtual void SetObjectNameInDataBase()
        {
            string nameObj = this.txtObjName.Text;
            //Set object name in database
            this._databaseEPower.ObjectName = nameObj;
        }

        #endregion Update_DataBase
    }
}
