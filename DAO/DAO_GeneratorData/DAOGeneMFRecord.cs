using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.DTO;

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
            dtoMF.PowerMachineMF = new PowerMachineDataMF();

            //*******Transformer Data => Can have or maybe not **********
            dtoMF.ImpedanceMF = new ImpedanceMBAConnected();

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

        #region Ok_Set_Data
     
        public virtual void UpdateBasicAndMachineDataForDatabaseMF(frmDataGenerator frmDataGenerator, DTOGeneEPower _dtoMFRecord)
        {
            //Set Machine ID => Object name. DataBusConnect Set when Connect success in order to generate Line =? Peocess Mouse
            _dtoMFRecord.ObjectNumber = int.Parse(frmDataGenerator.txtMachineID.Text);

            //Set Object Name
            _dtoMFRecord.ObjectName = frmDataGenerator.txtMachineName.Text;

            // Machine Data

            //Pgen
            _dtoMFRecord.PowerMachineMF.Pgen_MW = double.Parse(frmDataGenerator.txtPgen_MW.Text);
            //Pmax
           _dtoMFRecord.PowerMachineMF.Pmax_MW = double.Parse(frmDataGenerator.txtPmax_MW.Text);
            //Pmin
           _dtoMFRecord.PowerMachineMF.Pmin_MW = double.Parse(frmDataGenerator.txtPmin_MW.Text);

            //Qgen
            _dtoMFRecord.PowerMachineMF.Qgen_Mvar = double.Parse(frmDataGenerator.txtQgen_Mvar.Text);
            //Qmax
           _dtoMFRecord.PowerMachineMF.Qmax_Mvar = double.Parse(frmDataGenerator.txtQmax_Mvar.Text);
            //Qmin
            _dtoMFRecord.PowerMachineMF.Qmin_Mvar = double.Parse(frmDataGenerator.txtQmin_Mvar.Text);

            //Mbase
           _dtoMFRecord.PowerMachineMF.MBase = double.Parse(frmDataGenerator.txtMbase_MVA.Text);

            // RSource
            _dtoMFRecord.PowerMachineMF.RSource_pu = double.Parse(frmDataGenerator.txtRSource_pu.Text);
            //X Source
           _dtoMFRecord.PowerMachineMF.XSource_pu = double.Parse(frmDataGenerator.txtXSource_pu.Text);
        }

        public virtual void UpdateTranDataForDatabaseMF(frmDataGenerator frmDataGenerator, DTOGeneEPower _dtoMFRecord)
        {
            //RTran
            _dtoMFRecord.ImpedanceMF.RTran_pu = double.Parse(frmDataGenerator.txtRTran_pu.Text);
            //XTran
            _dtoMFRecord.ImpedanceMF.XTran_pu = double.Parse(frmDataGenerator.txtXTran_pu.Text);
            //genTap
            _dtoMFRecord.ImpedanceMF.Gentap = double.Parse(frmDataGenerator.txtGentapMF.Text);
        }


        public virtual void UpdateWindAndPlantDataForDatabaseMF(frmDataGenerator frmDataGenerator, DTOGeneEPower _dtoMFRecord)
        {
            //ControlMode
            int indexCtrlMode = frmDataGenerator.cboControlMode.SelectedIndex;
            foreach (WindMFControlMode item in Enum.GetValues(typeof(WindMFControlMode)))
            {
                if ((int)item == indexCtrlMode) _dtoMFRecord.WindCtrlMode = item;
            }
            //Set Sched Voltage
            _dtoMFRecord.SchedVoltage = double.Parse(frmDataGenerator.txtSchedVoltage.Text);
            //Remote Bus
            _dtoMFRecord.Remote_Bus = int.Parse(frmDataGenerator.txtRemoteBus.Text);
        }
        #endregion Ok_Set_Data
    }
}
