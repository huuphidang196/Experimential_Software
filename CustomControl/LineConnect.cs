using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software.CustomControl
{
    public enum PointOfEnds
    {
        NoEnds = 0,

        PointOfHead = 1,
        PointOfTail = 2,
    }

    // Lớp đối tượng Line
    public class LineConnect
    {
        private PanelMain pnlMainDrawn;
        public PanelMain PanelMain => pnlMainDrawn;

        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
            }
        }

        private ConnectableE _startEPower;
        public ConnectableE StartEPower { get => _startEPower; set => _startEPower = value; }

        private PointOfEnds _startPointEPower;
        public PointOfEnds StartPointEPower => _startPointEPower;

        private ConnectableE _endEPower;
        public ConnectableE EndEPower { get => _endEPower; set => _endEPower = value; }

        private PointOfEnds _endPointEPower;
        public PointOfEnds EndPointEPower => _endPointEPower;

        // Beacuse line is child of pnlMain so Point coordinate pnlmain system 
        private Point _startPoint;
        private Point _endPoint;

        public Point StartPoint
        {
            get { return _startPoint; }
            set
            {
                _startPoint = value;
            }
        }

        public Point EndPoint
        {
            get { return _endPoint; }
            set
            {
                _endPoint = value;
            }
        }

        //Point Input is phead or pTail of ConnectableE
        public LineConnect(ConnectableE StartEPower, ConnectableE EndEPower, Point start, Point end, PanelMain pnlMainDrawn)
        {
            this.pnlMainDrawn = pnlMainDrawn;

            this._startEPower = StartEPower;
            this._startPoint = start;
            this._startPointEPower = this.CheckPointEndIsPHeadOrPTail(this._startEPower, this._startPoint);


            this._endEPower = EndEPower;
            this._endPoint = end;
            this._endPointEPower = this.CheckPointEndIsPHeadOrPTail(this._endEPower, this._endPoint);

            this.isSelected = false;
        }

        protected virtual PointOfEnds CheckPointEndIsPHeadOrPTail(ConnectableE EPower, Point point)
        {
            Point pointToEPower = this.TransferPointToEPower(EPower, point);

            bool isPHead = pointToEPower == EPower.PHead ? true : false;

            if (isPHead) return PointOfEnds.PointOfHead;

            return PointOfEnds.PointOfTail;
        }

        protected virtual Point TransferPointToEPower(ConnectableE connectableE, Point point)
        {
            Point pointToScreen = this.pnlMainDrawn.PointToScreen(point);
            Point pointToEPower = connectableE.PointToClient(pointToScreen);

            return pointToEPower;
        }

        protected virtual Point TransferPointToMain(ConnectableE connectableE, Point point)
        {
            Point pointToScreen = connectableE.PointToScreen(point);
            Point pointToMain = this.pnlMainDrawn.PointToClient(pointToScreen);
         
           return pointToMain;
        }

     
        /// <summary>
        //numberPoint is update where. 0 then update startPoint, 1 update endPoint
        protected virtual void UpDateEndsPointInSideLine(ConnectableE EPowerUpdated, int numberPoint)
        {
            PointOfEnds GetPointOne = numberPoint == 0 ? this._startPointEPower : this._endPointEPower;

            //Don't care EPowerUpdated is Start or End, update by PointOfEnds
            // => transfer Point PHead or PTail of EPowerUpdated to coordinate pnlMain system
            Point pointUpdated = GetPointOne == PointOfEnds.PointOfHead ? EPowerUpdated.PHead : EPowerUpdated.PTail;
            Point pointToMain = this.TransferPointToMain(EPowerUpdated, pointUpdated);

            //=> Update Point Ends Line not Ends EPower
            if (numberPoint == 0)
            {
                this._startPoint = pointToMain;
                return;
            }

            this._endPoint = pointToMain;
        }


        #region Reference_OutSide
        public virtual void UpdateEndsPointAfterEPowerMove(ConnectableE btnEPower)
        {
            bool isStartEPower = this.CheckEPowerByName(btnEPower, this._startEPower);
            if (isStartEPower)
            {
                this.UpDateEndsPointInSideLine(this._startEPower, 0);
                return;
            }
            this.UpDateEndsPointInSideLine(this._endEPower, 1);
        }

        public virtual bool CheckEPowerByName(ConnectableE btnEPower, ConnectableE ePower)
        {
            if (ePower == null) return false;

            bool isStage = btnEPower.Name == ePower.Name ? true : false;

            return isStage;
        }

        #endregion Reference_OutSide

    }
}
