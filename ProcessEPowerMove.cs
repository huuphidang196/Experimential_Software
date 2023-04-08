using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software
{
    public class ProcessEPowerMove
    {
        protected ConnectableE _ePowerInstance;

        protected frmCapstone _formCap;
        protected List<LineConnect> lineConnectList;

        public ProcessEPowerMove(EPowerProcessMouse ePowerMouse)
        {
            this._formCap = ePowerMouse.EPower_Instance.FormCapstone;
            this._ePowerInstance = ePowerMouse.EPower_Instance;
            this.lineConnectList = ePowerMouse.EPower_Instance.FormCapstone.LineConnectList;
        }

        public virtual void ProcessEPowerMoveOverall( EPowerProcessLineTemp EPowerProcessLinetemp)
        {
            if (this.lineConnectList.Count == 0) return;

            if (this._ePowerInstance == null) return;

            // Not use PHead PTail because Now Phead and PTail is changed
            List<LineConnect> lineListConnected = this.GetLineStageEPower(this._ePowerInstance);

            //Update Pos Point
            foreach (LineConnect lineConnect in lineListConnected)
            {
                EPowerProcessLinetemp.ClearTwoOldLineWhenMove(lineConnect, lineConnect.PanelMain);
                lineConnect.UpdateEndsPointAfterEPowerMove(this._ePowerInstance);
            }

            //Drawn All Line 
            this._ePowerInstance.FormCapstone.DrawAllLineOnPanel();
        }

        public virtual List<LineConnect> GetLineStageEPower(ConnectableE btnEPower)
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


        protected virtual Point TransferPointToMain(ConnectableE connectableE, Point point, Panel pnlMain)
        {
            Point pointToScreen = connectableE.PointToScreen(point);
            Point pointToMain = pnlMain.PointToClient(pointToScreen);

            return pointToMain;
        }
    }
}






//protected virtual LineConnect GetLineStageEPower(ConnectableE btnEPower, int numberEnds, Panel pnlMain)
//{
//    foreach (LineConnect lineConnect in this.lineConnectList)
//    {
//        Point pointEnds = numberEnds == 0 ? btnEPower.PHead : btnEPower.PTail;
//        Point pEndsToMain = this.TransferPointToMain(btnEPower, pointEnds, pnlMain);

//        bool isSame = this.CheckLineIsSameEnds(lineConnect, pEndsToMain); 
//        if (isSame == false) continue;

//        return lineConnect;
//    }

//    return null;
//}


//private bool CheckLineIsSameEnds(LineConnect lineConnect, Point pEndsToMain)
//{
//    if (lineConnect.StartPoint == pEndsToMain || lineConnect.EndPoint == pEndsToMain) return true;

//    return false;
//}



//public virtual void ProcessEPowerMoveOverall(ConnectableE btnEPower, frmCapstone form, ProcessConnectControl processConnect)
//{
//    // Not use PHead PTail because Now Phead and PTail is changed


//    //Find line connect with btnEPower
//    LineConnect lineConPHeadE = this.GetLineStageEPower(btnEPower, null);
//    //In oder to not same 
//    LineConnect lineConPTailE = this.GetLineStageEPower(btnEPower, lineConPHeadE);

//    // if btn don't connect then no thing
//    if (lineConPHeadE == null && lineConPHeadE == null) return;

//    //Update Ends of Line => certain Line contain btnEPower if it difference null

//    if (lineConPHeadE != null)
//    {
//        processConnect.ClearTwoOldLineWhenMove(lineConPHeadE, lineConPHeadE.PanelMain);
//        lineConPHeadE.UpdateEndsPointAfterEPowerMove(btnEPower);
//    }

//    if (lineConPTailE != null)
//    {
//        processConnect.ClearTwoOldLineWhenMove(lineConPTailE, lineConPTailE.PanelMain);
//        lineConPTailE.UpdateEndsPointAfterEPowerMove(btnEPower);
//    }
//    //Drawn All Line 
//    form.DrawAllLineOnPanel();
//}

//protected virtual LineConnect GetLineStageEPower(ConnectableE btnEPower, LineConnect lineConPHeadE)
//{
//    foreach (LineConnect lineConnect in this.lineConnectList)
//    {
//        ConnectableE ePower = this.CheckEndsEPowerOfLine(lineConnect, btnEPower);
//        if (ePower == null) continue;

//        if (lineConnect == lineConPHeadE) continue;

//        return lineConnect;
//    }

//    return null;
//}