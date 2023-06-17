using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.DTO;

namespace Experimential_Software.DAO.DAO_LineData
{
    public class DAOGeneLineRecord
    {
        private static DAOGeneLineRecord _instance;

        public static DAOGeneLineRecord Instance
        {
            get { if (_instance == null) _instance = new DAOGeneLineRecord(); return DAOGeneLineRecord._instance; }
            private set { DAOGeneLineRecord._instance = value; }
        }

        private DAOGeneLineRecord() { }

        public virtual DTOLineEPower GenerateDTOLineEPowerDefault(int ExistOrderBus)
        {
            DTOLineEPower dtoLineEPower = new DTOLineEPower();

            //Basic Data
            dtoLineEPower.DTOBus_From = null;
            dtoLineEPower.DTOBus_To = null;

            int numberObjectType = (int)ObjectType.LineEPower * 100;
            dtoLineEPower.ObjectNumber = (ExistOrderBus < 100) ? numberObjectType + 1 : ExistOrderBus + 1;
            dtoLineEPower.ObjectName = "";

            dtoLineEPower.IsInService = true;

            //Branch Data
            dtoLineEPower.ImpedanceLineE = new ImpedanceLineEPower();

            return dtoLineEPower;
        }


        public virtual void SetBranchRecordInDataBase(frmDataBranch frmDataBranch, DTOLineEPower dtoLineEPowerRecord)
        {
            string Branch_ID = frmDataBranch.txtBranchID.Text;
            string Branch_Name = frmDataBranch.txtBranchName.Text;

            string LineR_pu = frmDataBranch.txtLineRPu.Text;
            string LineX_pu = frmDataBranch.txtLineXPu.Text;

            //charging B pu
            string ChargingB_pu = frmDataBranch.txtChargingBPu.Text;
            //G,B From
            string LineGFrom_pu = frmDataBranch.txtLineGFromPu.Text;
            string LineBFrom_pu = frmDataBranch.txtLineBFromPu.Text;

            //G,B To
            string LineGTo_pu = frmDataBranch.txtLineGToPu.Text;
            string LineBTo_pu = frmDataBranch.txtLineBToPu.Text;

            string Length_KM = frmDataBranch.txtLengthBr.Text;

            //set Branch ID         
            dtoLineEPowerRecord.ObjectNumber = int.Parse(Branch_ID);
            //Set Branch Name
            dtoLineEPowerRecord.ObjectName = Branch_Name;
            //InService
            dtoLineEPowerRecord.IsInService = frmDataBranch.chkInServiceBr.Checked;

            //*************Branch Data*************
            //txtLine R (pu)
            dtoLineEPowerRecord.ImpedanceLineE.LineR_Pu = double.Parse(LineR_pu);
            // txt Line X (pu)
            dtoLineEPowerRecord.ImpedanceLineE.LineX_Pu = double.Parse(LineX_pu);

            //ChargingB_pu
            dtoLineEPowerRecord.ImpedanceLineE.ChargingB_Pu = double.Parse(ChargingB_pu);
            //Line G From
            dtoLineEPowerRecord.ImpedanceLineE.LineGFrom_Pu = double.Parse(LineGFrom_pu);
            //Line B From
            dtoLineEPowerRecord.ImpedanceLineE.LineBFrom_Pu = double.Parse(LineBFrom_pu);

            //Line G To
            dtoLineEPowerRecord.ImpedanceLineE.LineGTo_Pu = double.Parse(LineGTo_pu);
            //Line B To
            dtoLineEPowerRecord.ImpedanceLineE.LineBTo_Pu = double.Parse(LineBTo_pu);

            //txt length_Km
            dtoLineEPowerRecord.ImpedanceLineE.LengthBr_KM = double.Parse(Length_KM);


        }


    }
}
