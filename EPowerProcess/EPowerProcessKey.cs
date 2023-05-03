using Experimential_Software.CustomControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software.EPowerProcess
{
    public class EPowerProcessKey
    {
        protected ConnectableE _ePowerInstance;

        protected List<ConnectableE> ePowers;

        protected List<LineConnect> lineConnectList;

        public EPowerProcessKey(ConnectableE ePower)
        {
            this._ePowerInstance = ePower;
            this.ePowers = ePower.FormCapstone.EPowers;
            // this.lineConnectList = ePower.FormCapstone.LineConnectList;
            //use List LineConneted with this Epower instead of List of Main => up speed Find
            this.lineConnectList = ePower.ListBranch_Drawn;
        }


        #region Key_Down
        public virtual void EPowerInstance_KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            this.ProcessEPowerDeleted(e);
            //remove observer 
            this._ePowerInstance.FormCapstone.RemoveIMouseOnEndsAfterDelete(this._ePowerInstance);
        }
        #endregion Key_Down

        protected virtual void ProcessEPowerDeleted(KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            //Find line connect this
            // LineConnect lineConnect = this.FindLineConnectEPower(lineConnectList, ePower_Del);
            List<LineConnect> lineListConnected = this.GetLineStageEPower(this._ePowerInstance);

            if (lineListConnected.Count == 0) return;

            foreach (LineConnect lineConnect in lineListConnected)
            {
                this._ePowerInstance.EPowerLineTemp.ClearTwoOldLineWhenMove(lineConnect);
                //Determine ConnectionE connect with line => set iscontainPHead or Tail
                this.SetIsContainEPower(lineConnect);
                //Remove Line Connect with ePower is removed outside List LineConenect of EPower Affect 
                this.RemoveLineConnectWithERemoveOutSideEAffect(lineConnect);

                this._ePowerInstance.FormCapstone.RemoveLine(lineConnect);

                //Remove LineConneted outside this ListLine EPower and other EPower connected with this
                this._ePowerInstance.RemoveLineConnectedToList(lineConnect);
            }

            //remove this out EPowers
            this._ePowerInstance.FormCapstone.RemoveEPower(this._ePowerInstance);
            this._ePowerInstance.Dispose();
            this._ePowerInstance.LblInfoE.Dispose();

            this._ePowerInstance.FormCapstone.DrawAllLineOnPanel();
        }

        

        protected virtual List<LineConnect> GetLineStageEPower(ConnectableE btnEPower)
        {
            LineConnect lineConPre = null;
            List<LineConnect> lineListConnected = new List<LineConnect>();// Because Bus have many Line

            foreach (LineConnect lineConnect in this.lineConnectList)
            {
                ConnectableE ePower = this.CheckEndsEPowerOfLine(lineConnect, btnEPower);
                if (ePower == null) continue;

                if (lineConnect == lineConPre) continue;

                lineConPre = lineConnect;
                lineListConnected.Add(lineConnect);
            }

            return lineListConnected;
        }

        protected virtual ConnectableE CheckEndsEPowerOfLine(LineConnect lineConnect, ConnectableE btnEPower)
        {
            bool isStartEPower = lineConnect.CheckEPowerByName(btnEPower, lineConnect.StartEPower);
            if (isStartEPower) return lineConnect.StartEPower;

            bool isEndEPower = lineConnect.CheckEPowerByName(btnEPower, lineConnect.EndEPower);
            if (isEndEPower) return lineConnect.EndEPower;

            return null;
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
    }
}
