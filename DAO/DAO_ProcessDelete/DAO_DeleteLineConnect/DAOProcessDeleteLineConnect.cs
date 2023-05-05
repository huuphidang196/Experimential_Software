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

            if (this.IsPointOfHead(lineRemoved, 0)) startEPower.IsContainPhead = false;
            else startEPower.IsContainPtail = false;

            if (this.IsPointOfHead(lineRemoved, 1)) endEPower.IsContainPhead = false;
            else endEPower.IsContainPtail = false;

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
            startEPower.UpdateDataRecordEPowerWhenConnect(true);

            endEPower.RemoveLineConnectedToList(lineRemoved);
            lineRemoved.EndEPower = null;
            endEPower.UpdateDataRecordEPowerWhenConnect(true);
        }
        protected virtual bool IsPointOfHead(LineConnect lineSelected, int numberEnds)
        {
            PointOfEnds internPointEPower = numberEnds == 0 ? lineSelected.StartPointEPower : lineSelected.EndPointEPower;
            bool isContainHead = internPointEPower == PointOfEnds.PointOfHead ? true : false;

            return isContainHead;
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
