using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Database;

namespace Experimential_Software.DAO.DAO_GeneratorData
{
    public class DAOGeneMFRecord
    {
        private static DAOGeneMFRecord _instance;
        public static DAOGeneMFRecord Instance
        {
            get { if (_instance == null) _instance = new DAOGeneMFRecord(); return _instance; }
            private set { }
        }

        private DAOGeneMFRecord() { }

        public virtual DTOGeneEPower GenerateDTOMFEPowerDefault(int ExistOrderMF)
        {
            //*************Basic Data*******************   
            DTOGeneEPower dtoMF = new DTOGeneEPower();
            //set null for Bus Connect
            dtoMF.DTOBusConnected = null;

            //Set ObjetName => Machine ID
            dtoMF.ObjectName = "";

            //Set ObjNunber => is hidden
            int numberObjectType = (int)ObjectType.MF * 100;
            dtoMF.ObjectNumber = (ExistOrderMF < 100) ? numberObjectType + 1 : ExistOrderMF + 1;

            //Set Inservice
            dtoMF.IsInService = true;

            //**************Machine Data******************
            //Set Pgen
            dtoMF.Pgen_MW = 0;
            //setPmax
            dtoMF.Pmax_MW = 9999;
            //set Pmin
            dtoMF.Pmin_MW = -9999;

            //Set Qgen
            dtoMF.Qgen_MW = 0;
            //set Qmax 
            dtoMF.Qmax_MW = 9999;
            //set Qmin 
            dtoMF.Qmin_MW = -9999;
            //set Mbase => CSDM
            dtoMF.MBase = 100;

            //*******Transformer Data => Can have or maybe not **********
            //R Tran
            dtoMF.RTran_pu = 0;
            //X Tran
            dtoMF.XTran_pu = 0;
            //Gentap
            dtoMF.Gentap = 1;

            //**********Wind Data  => Can have or maybe not***************
            //Control Mode
            dtoMF.WindCtrlMode = WindMFControlMode.Not_a_Wind_Machine;
            //Power Factor
            dtoMF.PowerFactor = 1;

            //*********Plant Data=> Can have or maybe not***************
            //Set Sched Voltage
            dtoMF.SchedVoltage = 1;
            //Set Remote Bus
            dtoMF.Remote_Bus = 0;

            return dtoMF;
        }

    }
}
