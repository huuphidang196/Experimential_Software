using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Experimential_Software
{
    public partial class ProcessPowerConnection
    {
        private bool isDragging;
        public bool IsDragging { get => isDragging; set => isDragging = value; }

        private bool isMove = false;
        private bool allowCreatLine = false;

        protected Point previousMouseLocation;
        public Point PreviousMouseLocation => previousMouseLocation;

        //Coordinate pnlMain system
        private Point _startPLineTemp;
        private Point _endPLinetemp;

        protected ProcessConnectControl processConnect;
        protected ProcessEPowerMove processEPowerMove;

        // private Panel pnlMain;
        public frmCapstone form { get; set; }

        #region Mouse Down

        public virtual void ButtonInstance_MouseDown(object sender, MouseEventArgs e, Object pnlDes)
        {
            if (e.Button == MouseButtons.Right) return; //=> sau này chỉnh sau nếu thêm contextstrip

            //Check to see move or don't move in order to Draw connectLine when button move
            ConnectableE buttonInstance = this.ConvertInstance(sender);

            this.IsDragging = true;
            this.previousMouseLocation = e.Location;

            this.isMove = buttonInstance.IsMove;
            // both move and not move use
            this.processConnect = new ProcessConnectControl();
            if (!this.isMove)
            {
                bool isPhead = buttonInstance.IsOnPHead(e.Location);
                bool isContainEnds = (isPhead == true) ? buttonInstance.IsContainPhead : buttonInstance.IsContainPtail;

                if (buttonInstance.DatabaseE.objectType == ObjectType.Bus) isContainEnds = true;//=?Bus can not point start line
                if (isContainEnds) return;

                //Coordinate button system
                Point pointStartOnButton = isPhead == true ? buttonInstance.PHead : buttonInstance.PTail;


                //coordinate pnlMain system
                this._startPLineTemp = this.TransferPosFindToControl(buttonInstance, pnlDes, pointStartOnButton);
                this.allowCreatLine = true;

                buttonInstance.containPreEpower = isPhead == true ? ContainPreEpower.ContainPhead : ContainPreEpower.ContainPTail;
            }
        }

        #endregion Mouse Down

        #region Mouse_Move

        public virtual void ButtonInstance_MouseMove(object sender, MouseEventArgs e, Object pnlDes)
        {
            //Xử lí draw line        
            if (!IsDragging) return; 

            if (!this.isMove)
            {
                if (this.allowCreatLine)    //Drawn Line
                    this._endPLinetemp = this.processConnect.GenerateLine(sender, e, pnlDes, this._startPLineTemp);
     
                this.form.ShowPointConnect();
                return;
            }

            // button move will remove line. So Drawn all circumstance
            this.form.DrawAllLineOnPanel();
            bool isOnMain = this.IsOnPanelMain(sender, e, pnlDes);

            if (!isOnMain) return;

            ConnectableE btnInstance = this.ConvertInstance(sender);
            btnInstance.Location = this.TransferPosMouseToControl(sender, e, pnlDes);

            //btnmove then Check end set line follow btnEPower that it connect 
            List<LineConnect> lineConnectList = this.form.LineConnectList;

            //When btn move then update , if don't move not update line
            this.processEPowerMove = new ProcessEPowerMove(lineConnectList);
            this.processEPowerMove.ProcessEPowerMoveOverall(btnInstance, this.form, this.processConnect);

        }

        #endregion Mouse_Move

        #region Mouse Up
        public virtual void ButtonInstance_MouseUp(object sender, MouseEventArgs e, Object pnlDes)
        {
            if (e.Button == MouseButtons.Right) return;

            ConnectableE buttonInstance = this.ConvertInstance(sender);

            this.IsDragging = false;

            if (!this.isMove )
            {
                if (this.allowCreatLine) this.CheckAndAddLineConnet(buttonInstance, pnlDes);
                return;
            }


            bool isOnMain = this.IsOnPanelMain(sender, e, pnlDes);

            if (!isOnMain)
            {
                buttonInstance.Location = this.previousMouseLocation;
                return;
            }

            buttonInstance.Location = this.TransferPosMouseToControl(sender, e, pnlDes);
        }

        protected virtual void CheckAndAddLineConnet(ConnectableE buttonInstance, Object pnlDes)
        {
            Panel pnlMain = pnlDes as Panel;
            //Clear line temp
            this.processConnect.ClearOldLine();
            this.allowCreatLine = false;

            // Find have button contain endpoint of Line
            ConnectableE EndEPower = this.form.CheckEndLineIsOnEPower(this._endPLinetemp);
            if (EndEPower == null) return;

            //Check endPoint is near Pheah or Ptail. not use isOnpHead or Patil beacause endLocation use mouse of other button
            Point pointEndToBtn = EndEPower.IsOnNearPHead() ? EndEPower.PHead : EndEPower.PTail;

            //get bool contain Phead or Ptail
            bool isContainEnds = (pointEndToBtn == EndEPower.PHead) ? EndEPower.IsContainPhead : EndEPower.IsContainPtail;

            if (EndEPower.DatabaseE.objectType == ObjectType.Bus) isContainEnds = false;//=?Bus can add > 2
            if (isContainEnds) return; //=> EndPoint has LineConnect 

            //Transfer EndMouse to Point of pnlMain system. EndMouse = pointEndToBtn = Phead or PTail of EndEPower not Instance
            this._endPLinetemp = this.TransferPosFindToControl(EndEPower, pnlDes, pointEndToBtn);

            //generate new Line then add List
            LineConnect newLineConnect = new LineConnect(buttonInstance, EndEPower, this._startPLineTemp, this._endPLinetemp, pnlMain);
            //add Line 
            this.form.AddLine(newLineConnect);
            
            EndEPower.containPreEpower = (pointEndToBtn == EndEPower.PHead) ? ContainPreEpower.ContainPhead : ContainPreEpower.ContainPTail;

            //set 2 Contain Phead or Ptail 2 button
            this.SetContainTwoButton(buttonInstance, EndEPower);
        }

        protected virtual void SetContainTwoButton(ConnectableE StartEPower, ConnectableE EndEPower)
        {
            //Set button start 
            this.SetContainOnce(StartEPower);
            //set button end
            this.SetContainOnce(EndEPower);
        }

        protected virtual void SetContainOnce(ConnectableE btnSet)
        {
            if (btnSet.containPreEpower == ContainPreEpower.ContainPhead)
            {
                btnSet.IsContainPhead = true;
                return;
            }
            btnSet.IsContainPtail = true;
                
        }
        #endregion Mouse Up

        #region Overall Function
        protected virtual ConnectableE ConvertInstance(object sender)
        {
            ConnectableE buttonInstance = sender as ConnectableE;
            return buttonInstance;
        }

        protected virtual bool IsOnPanelMain(object sender, MouseEventArgs e, Object pnlDes)
        {

            Control pnlMain = pnlDes as Control;
            Point pMouseTopnlMain = this.TransferPosMouseToControl(sender, e, pnlMain);

            bool isMain = pnlMain.ClientRectangle.Contains(pMouseTopnlMain);
            return isMain;
        }

        //Trả về vị vị điểm chính giữa Control
        protected virtual Point TransferPosMouseToControl(object sender, MouseEventArgs e, object ControlDes)
        {
            ConnectableE button1Instance = this.ConvertInstance(sender);
            //Get pos center of button Instance in order to smoothly move
            Point posCenter = new Point(e.Location.X - button1Instance.Width / 2, e.Location.Y - button1Instance.Height / 2);

            return this.TransferPosFindToControl(button1Instance, ControlDes, posCenter);
        }

        //Trả về Point control so với pnlMain
        protected virtual Point TransferPosFindToControl(ConnectableE button1Instance, object ControlDes, Point posFind)
        {
            //=> transfer Location to screen
            Point dropToScreen = button1Instance.PointToScreen(posFind);

            Panel pnlMain = ControlDes as Panel;
            //=> transfer posMouse to Control Destionation
            Point pMouseTopnlMain = pnlMain.PointToClient(dropToScreen);

            return pMouseTopnlMain;
        }

        #endregion Overall Function
    }
}
