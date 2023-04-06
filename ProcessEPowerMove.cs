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
        public ProcessEPowerMove(List<LineConnect> lineConnectList)
        {
            this.lineConnectList = lineConnectList;
        }

        protected List<LineConnect> lineConnectList;

        public virtual void ProcessEPowerMoveOverall(ConnectableE btnEPower, frmCapstone form, ProcessConnectControl processConnect)
        {
            // Not use PHead PTail because Now Phead and PTail is changed

            //Find line connect with btnEPower
            LineConnect lineConPHeadE = this.GetLineStageEPower(btnEPower, null);
            //In oder to not same 
            LineConnect lineConPTailE = this.GetLineStageEPower(btnEPower, lineConPHeadE);

            // if btn don't connect then no thing
            if (lineConPHeadE == null && lineConPHeadE == null) return;

            //Update Ends of Line => certain Line contain btnEPower if it difference null

            if (lineConPHeadE != null)
            {
                processConnect.ClearTwoOldLineWhenMove(lineConPHeadE, lineConPHeadE.PanelMain);
                lineConPHeadE.UpdateEndsPointAfterEPowerMove(btnEPower);
            }

            if (lineConPTailE != null)
            {
                processConnect.ClearTwoOldLineWhenMove(lineConPTailE, lineConPTailE.PanelMain);
                lineConPTailE.UpdateEndsPointAfterEPowerMove(btnEPower);
            }
            //Drawn All Line 
            form.DrawAllLineOnPanel();
        }

        protected virtual LineConnect GetLineStageEPower(ConnectableE btnEPower, LineConnect lineConPHeadE)
        {
            foreach (LineConnect lineConnect in this.lineConnectList)
            {
                ConnectableE ePower = this.CheckEndsEPowerOfLine(lineConnect, btnEPower);
                if (ePower == null) continue;

                if (lineConnect == lineConPHeadE) continue;

                return lineConnect;
            }

            return null;
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
