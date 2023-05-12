using Experimential_Software.DAO.DAO_Curve.DAO_Calculate;
using Experimential_Software.DAO.DAO_Curve.DAO_IsovalForm;
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
            this._allMF = DAOGenerateListPoints.Instance.GetAllMF(this._allEPowers);

            //Send Data for Instance of Cal Step one
            DAOGenerateListPoints.Instance.SendDataBeforeCalculate(this._allEPowers, this._busLoadExamined);
            //Get Ystae from StepOne
            this.YState = DAOCalculateQLJStepOne.Instance.YState;
            this.YBus = DAOCalculateQLJStepOne.Instance.YBusIsoval;
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
            this.lblTotalBus.Text = DAOGenerateListPoints.Instance.GetAllBus(this._allEPowers).Count + "";

            //Show Ystate on label
            lblYStateBelow.Text = DAOGetTextSysemIsoval.Instance.GetTextYStateShowForm(this.YState);
        }


        protected virtual void ShowZoneYBus()
        {
            //Object all mF
            this.lblAllNumMF.Text = DAOGetTextSysemIsoval.Instance.GetObjectNumberAllMF(this._allMF);

            //Bus Load Consider
            this.lblBusExamined.Text = this._busLoadExamined.DatabaseE.DataRecordE.DTOBusEPower.ObjectNumber.ToString();

            //label Y Bus Isoval
            this.lblYBusBelow.Text = DAOGetTextSysemIsoval.Instance.GetTextYBusShowFrom(this._busLoadExamined, this.YBus);
        }

    }
}
