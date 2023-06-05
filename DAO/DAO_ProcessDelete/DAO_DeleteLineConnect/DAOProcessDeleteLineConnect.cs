using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.CustomControl;
namespace Experimential_Software.DAO.DAO_ProcessDelete.DAO_DeleteLineConnect
{
    public class DAOProcessDeleteLineConnect
    {
        private static DAOProcessDeleteLineConnect _instance;
        public static DAOProcessDeleteLineConnect Instance
        {
            get { if (_instance == null) _instance = new DAOProcessDeleteLineConnect(); return _instance; }
            private set {; }
        }

        private DAOProcessDeleteLineConnect() {; }

        public virtual void ProcessDeleteLineConnect(LineConnect lineConnect)
        {
            //Determine ConnectionE connect with line => set iscontainPHead or Tail
            this.SetIsContainEPower(lineConnect);
            //Remove Line Connect with ePower is removed outside List LineConenect of EPower Affect 
            this.RemoveLineConnectWithERemoveOutSideEAffect(lineConnect);
        }
        protected virtual void SetIsContainEPower(LineConnect lineRemoved)
        {
            //Line alwway 2 Connect 
            ConnectableE startEPower = lineRemoved.StartEPower;
            ConnectableE endEPower = lineRemoved.EndEPower;

            this.ProcessSetContainForEndsEPowerOfLineConnect(lineRemoved, startEPower);
            this.ProcessSetContainForEndsEPowerOfLineConnect(lineRemoved, endEPower);
        }

        protected virtual void ProcessSetContainForEndsEPowerOfLineConnect(LineConnect lineRemoved, ConnectableE EndsLineEPower)
        {
            int numberEnds = EndsLineEPower == lineRemoved.StartEPower ? 0 : 1;
            if (this.IsPointOfHead(lineRemoved, numberEnds)) EndsLineEPower.IsContainPhead = false;
            else
            {
                if (EndsLineEPower.DatabaseE.ObjectType != ObjectType.MBA3P)
                {
                    EndsLineEPower.IsContainPtail = false;
                    return;
                }

                if (this.IsPointOfIntern(lineRemoved, numberEnds)) EndsLineEPower.IsContainPIntern = false;
                else EndsLineEPower.IsContainPtail = false;
            }

        }

        protected virtual bool IsPointOfHead(LineConnect lineSelected, int numberEnds)
        {
            PointOfEnds internPointEPower = numberEnds == 0 ? lineSelected.StartPointEPower : lineSelected.EndPointEPower;
            bool isContainHead = internPointEPower == PointOfEnds.PointOfHead ? true : false;

            return isContainHead;
        }

        //Only apply for MBA3P 
        protected virtual bool IsPointOfIntern(LineConnect lineSelected, int numberEnds)
        {
            PointOfEnds internPointEPower = numberEnds == 0 ? lineSelected.StartPointEPower : lineSelected.EndPointEPower;
            bool isContainIntern = internPointEPower == PointOfEnds.PointOfIntern ? true : false;

            return isContainIntern;
        }

        private void RemoveLineConnectWithERemoveOutSideEAffect(LineConnect lineRemoved)
        {
            ConnectableE startEPower = lineRemoved.StartEPower;
            ConnectableE endEPower = lineRemoved.EndEPower;
            //Remove LinnConnected is removed from List In StartE and End
            //Update Data EPower When EPower Connected is removed
            //Remove before update
            startEPower.RemoveLineConnectedToList(lineRemoved);
            lineRemoved.StartEPower = null;
            startEPower.UpdateDataRecordEPowerWhenConnectOrRemove();

            endEPower.RemoveLineConnectedToList(lineRemoved);
            lineRemoved.EndEPower = null;
            endEPower.UpdateDataRecordEPowerWhenConnectOrRemove();
        }


        public virtual void ClearOldLine(LineConnect LineRemoved, PanelMain pnlMain_Drawn)
        {
            Point startLine = LineRemoved.StartPoint;
            Point endLine = LineRemoved.EndPoint;

            if (startLine != Point.Empty && endLine != Point.Empty)
            {
                pnlMain_Drawn.CreateGraphics().DrawLine(Pens.White, startLine, endLine);
            }
        }
    }
}
