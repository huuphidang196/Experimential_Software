using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.DAO.DAO_Curve.DAO_Calculate;

namespace Experimential_Software.Class_Database
{
    [Serializable]
    public class PowerSystem
    {
        public double P_ActivePower { get; set; }
        public double Q_ReactivePower { get; set; }

        public PowerSystem(double P_ActivePower, double Q_ReactivePower)
        {
            this.P_ActivePower = P_ActivePower;
            this.Q_ReactivePower = Q_ReactivePower;
        }
    }

    [Serializable]
    public class DTOMFComparer : IComparer<DTOGeneEPower>
    {
        public int Compare(DTOGeneEPower x, DTOGeneEPower y)
        {
            return x.ObjectNumber.CompareTo(y.ObjectNumber);
        }
    }
    [Serializable]

    public class DTOBusConnectMFComparer : IComparer<DTOBusEPower>
    {
        public int Compare(DTOBusEPower x, DTOBusEPower y)
        {
            return x.ObjectNumber.CompareTo(y.ObjectNumber);
        }
    }

    public class DTODataInputPowerSystem
    {
        protected List<double> _e_AllMF = new List<double>();
        public List<double> E_AllMF => _e_AllMF;

        protected List<double> _rad_ThetaK_All = new List<double>();
        public List<double> Rad_ThetaK_All => _rad_ThetaK_All;

        protected List<ReactPowerQLimit> _q_GK_Limits = new List<ReactPowerQLimit>();
        public List<ReactPowerQLimit> Q_GK_Limits => _q_GK_Limits;

        public DTODataInputPowerSystem(List<ConnectableE> allMF)
        {
            List<DTOBusEPower> List_DTO_Bus = this.GetListDTOBusConnectWithMF(allMF);
            this._e_AllMF = List_DTO_Bus.Select(e => e.Voltage_pu).ToList();
           
            this._rad_ThetaK_All = List_DTO_Bus.Select(rad => rad.Angle_rad).ToList();
            this._q_GK_Limits = this.GetListReactPowerLimit(allMF);

        }

        //get listDTObus Connect with MF
        protected virtual List<DTOBusEPower> GetListDTOBusConnectWithMF(List<ConnectableE> allMF)
        {
            List<DTOBusEPower> List_DTO_Bus = allMF.Select(dtoMF => dtoMF.DatabaseE.DataRecordE.DTOGeneEPower.DTOBusConnected).ToList();
            //Sort List
            List_DTO_Bus.Sort(new DTOBusConnectMFComparer());
            return List_DTO_Bus;
        }

        //get List Q min , Qmax
        protected virtual List<ReactPowerQLimit> GetListReactPowerLimit(List<ConnectableE> allMF)
        {
            //Input are all MF EPower not use BusMF 
            List<DTOGeneEPower> List_DTO_MF = allMF.Select(x => x.DatabaseE.DataRecordE.DTOGeneEPower).ToList();
            //Sort by ObjNumber 
            List_DTO_MF.Sort(new DTOMFComparer());

            return List_DTO_MF.Select(qGK => new ReactPowerQLimit(qGK.PowerMachineMF.Qmin_Mvar, qGK.PowerMachineMF.Qmax_Mvar)).ToList();
        }
     
    }

    public class ReactPowerQLimit
    {
        public double Q_Gk_Min { get; set; }
        public double Q_Gk_Max { get; set; }

        public ReactPowerQLimit(double Q_Gk_Min, double Q_Gk_Max)
        {
            this.Q_Gk_Min = Q_Gk_Min;
            this.Q_Gk_Max = Q_Gk_Max;
        }
    }
}
