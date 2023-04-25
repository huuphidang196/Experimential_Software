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
        protected ConnectableE  _ePowerInstance;

        protected List<ConnectableE> ePowers;

        protected List<LineConnect> lineConnectList;

        public EPowerProcessKey(ConnectableE ePower)
        {
            this._ePowerInstance = ePower;
            this.ePowers = ePower.FormCapstone.EPowers;
            this.lineConnectList = ePower.FormCapstone.LineConnectList;
        }


        #region Key_Down
        public virtual void EPowerInstance_KeyDown (KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            this.ProcessEPowerDeleted(e);
            //remove observer 
            this._ePowerInstance.FormCapstone.RemoveIMouseOnEndsAfterDelete(this._ePowerInstance);
        }
        #endregion Key_Down

        protected virtual void ProcessEPowerDeleted( KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            //Find line connect this
            // LineConnect lineConnect = this.FindLineConnectEPower(lineConnectList, ePower_Del);
            List<LineConnect> lineListConnected = this.GetLineStageEPower(this._ePowerInstance);

            //remove this out EPowers
            this._ePowerInstance.FormCapstone.RemoveEPower(this._ePowerInstance);
            this._ePowerInstance.Dispose();
            this._ePowerInstance.LblInfoE.Dispose();
            //Set all numberObject
          //  this._ePowerInstance.PanelMain.PanelMainMouse.ProcessSetNumberEPowerAfterDelete(this._ePowerInstance);

            if (lineListConnected.Count == 0) return;
            foreach (LineConnect lineConnect in lineListConnected)
            {
                this._ePowerInstance.EPowerLineTemp.ClearTwoOldLineWhenMove(lineConnect);
                //Determine ConnectionE connect with line => set iscontainPHead or Tail
                this._ePowerInstance.FormCapstone.SetIsContainEPower(lineConnect);
                this._ePowerInstance.FormCapstone.RemoveLine(lineConnect);
            }

            this._ePowerInstance.FormCapstone.DrawAllLineOnPanel();
        }

        protected virtual List<LineConnect> GetLineStageEPower(ConnectableE btnEPower)
        {
            LineConnect lineConPre = null;
            List<LineConnect> lineListConnected = new List<LineConnect>();

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
    }
}
