
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.BLL.BLL_Curve.BLL_Calculate;
using Experimential_Software.BLL.BLL_Curve.BLL_IsovalForm;

namespace Experimential_Software
{
    public partial class frmSystemIsoval : Form
    {
        protected List<ConnectableE> _allEPowers;
        public List<ConnectableE> AllEPowers { get => _allEPowers; set => _allEPowers = value; }

        // Bus Examinate connect with Load
        protected ConnectableE _busLoadExamined;
        public ConnectableE BusLoadExamnined { get => _busLoadExamined; set => _busLoadExamined = value; }

        protected List<ConnectableE> _allMF;

        protected Complex[,] YState;

        protected Complex[,] YBus;


        public frmSystemIsoval()
        {
            InitializeComponent();
        }

        private void frmSystemIsoval_Load(object sender, EventArgs e)
        {
            if (this._busLoadExamined != null)
            {
                this.CalculateData();
                this.ShowDataOnForm();
            }
        }

        protected virtual void CalculateData()
        {
            //get All MF
            this._allMF = BLLGenerateListPoints.Instance.GetAllMF(this._allEPowers);

            //Send Data for Instance of Cal Step one
            BLLGenerateListPoints.Instance.SendDataBeforeCalculate(this._allEPowers, this._busLoadExamined);
            //Get Ystae from StepOne
            this.YState = BLLCalculateQLJStepOne.Instance.YState;
            this.YBus = BLLCalculateQLJStepOne.Instance.YBusIsoval;
            //this.YBus = DAOCalculateQLJStepOne.Instance.ZBusIsoval;
        }

        protected virtual void ShowDataOnForm()
        {
            //Title Panel YStae
            this.ShoưZoneYState();

            //Zone Y Bus
            this.ShowZoneYBus();
        }

        protected virtual void ShoưZoneYState()
        {
            //Total MF
            this.lblTotalMF.Text = this._allMF.Count + "";
            //Toltal Bus
            this.lblTotalBus.Text = BLLGenerateListPoints.Instance.GetAllBus(this._allEPowers).Count + "";

            //Show Ystate on label
            BLLGetTextSysemIsoval.Instance.ShowYStateShowOnDataGridViewForm(this.YState, this.dgvMatrixYState);
        }


        protected virtual void ShowZoneYBus()
        {
            //Object all mF
            this.lblAllNumMF.Text = BLLGetTextSysemIsoval.Instance.GetObjectNumberAllMF(this._allMF);

            //Bus Load Consider
            this.lblBusExamined.Text = this._busLoadExamined.DatabaseE.DataRecordE.DTOBusEPower.ObjectNumber.ToString();

            //label Y Bus Isoval
            BLLGetTextSysemIsoval.Instance.ShowYBusShowOnDataGridViewForm(this._busLoadExamined, this.YBus, this.dgvMatrixYSBus);
        }
    }
}
