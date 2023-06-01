using Experimential_Software.CustomControl;
using Experimential_Software.EPowerProcess;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software.EPowerProcess
{
    public class ProcessEPowerMove
    {
        protected ConnectableE _ePowerInstance;

        protected List<LineConnect> lineConnectList;

        public ProcessEPowerMove(EPowerProcessMouse ePowerMouse)
        {
            this._ePowerInstance = ePowerMouse.EPower_Instance;
            this.lineConnectList = ePowerMouse.EPower_Instance.ListBranch_Drawn;
        }

        public virtual void ProcessEPowerMoveOverall( EPowerProcessLineTemp EPowerProcessLinetemp)
        {
            if (this.lineConnectList.Count == 0) return;

            if (this._ePowerInstance == null) return;

            //Update Pos Point
            foreach (LineConnect lineConnect in this.lineConnectList)
            {
                EPowerProcessLinetemp.ClearTwoOldLineWhenMove(lineConnect);
                lineConnect.UpdateEndsPointAfterEPowerMove(this._ePowerInstance);
            }
        }
    }
}
