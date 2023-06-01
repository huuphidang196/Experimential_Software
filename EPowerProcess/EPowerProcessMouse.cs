using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Experimential_Software.Class_Database;
using Experimential_Software.CustomControl;
using Experimential_Software.DAO.DAO_LoadData;
using Experimential_Software.DAO.DAO_LineData;
using Experimential_Software.DAO.DAO_GeneratorData;
using Experimential_Software.DAO.DAO_MBA2Data;
using Experimential_Software.DAO.DAOCapstone;

namespace Experimential_Software.EPowerProcess
{
    public partial class EPowerProcessMouse
    {
        protected ConnectableE _ePower;
        public ConnectableE EPower_Instance => _ePower;

        private bool isDragging;
        public bool IsDragging { get => isDragging; set => isDragging = value; }

        private bool isMove = false;
        private bool allowCreatLine = false;

        protected Point previousMouseLocation;
        public Point PreviousMouseLocation => previousMouseLocation;

        //Coordinate pnlMain_Drawn system
        private Point _startPLineTemp;
        private Point _endPLinetemp;


        protected ProcessEPowerMove processEPowerMove;
        public ProcessEPowerMove ProcessEPowerMove => processEPowerMove;

        public EPowerProcessMouse(ConnectableE ePower)
        {
            this._ePower = ePower;
            this.processEPowerMove = new ProcessEPowerMove(this);
        }

        #region Mouse Down

        public virtual void ButtonInstance_MouseDown(MouseEventArgs e)
        {
            //Check to see move or don't move in order to Draw connectLine when button move

            this.isDragging = true;
            //Transfer to point Panel Main
            this.previousMouseLocation = this.TransferPosFindOnInstance(e.Location);

            this.isMove = this._ePower.IsMove;
            // both move and not move use
            if (this.isMove)
            {
                if (Control.ModifierKeys != Keys.Control) return;

                this.isDragging = false;//Avoid after set data EPower follow Mouse
                this.ButtonInstance_DoubleMouseClick(e);
                return;
            }

            // If EPower move
            this.ProcessButtonInstanceMouseDown_Move(e);
        }

        protected virtual void ProcessButtonInstanceMouseDown_Move(MouseEventArgs e)
        {
            if (this._ePower.DatabaseE.ObjectType == ObjectType.MBA3P)
            {
                this.ProcessSpecifiedButtonInstanceMBA3PMouseDown(e);
                return;
            }

            bool isPhead = this._ePower.IsOnPHead(e.Location);
            bool isContainEnds = (isPhead == true) ? this._ePower.IsContainPhead : this._ePower.IsContainPtail;

            if (this._ePower.DatabaseE.ObjectType == ObjectType.Bus) isContainEnds = true;//=?Bus can not point start line
            if (isContainEnds) return;

            //Coordinate button system
            Point pointStartOnButton = isPhead == true ? this._ePower.PHead : this._ePower.PTail;


            //coordinate pnlMain system
            this._startPLineTemp = this.TransferPosFindToControl(this._ePower, pointStartOnButton);
            this.allowCreatLine = true;

            this._ePower.ContainPreEpower = isPhead == true ? ContainPreEpower.ContainPhead : ContainPreEpower.ContainPTail;
        }

        protected virtual void ProcessSpecifiedButtonInstanceMBA3PMouseDown(MouseEventArgs e)
        {
            bool isContainEnds;
            Point pointStartOnButton;
            if (this._ePower.IsOnPIntern(e.Location))
            {
                isContainEnds = this._ePower.IsContainPIntern;
                pointStartOnButton = this._ePower.PIntern;
            }
            else
            {
                bool isPHead = this._ePower.IsOnPHead(e.Location);
                isContainEnds = isPHead ? this._ePower.IsContainPhead : this._ePower.IsContainPtail;
                pointStartOnButton = isPHead ? this._ePower.PHead : this._ePower.PTail;

            }

            if (isContainEnds) return;

            //coordinate pnlMain system
            this._startPLineTemp = this.TransferPosFindToControl(this._ePower, pointStartOnButton);
            this.allowCreatLine = true;

            if (this._ePower.IsOnPIntern(e.Location)) this._ePower.ContainPreEpower = ContainPreEpower.ContainPIntern;
            else this._ePower.ContainPreEpower = this._ePower.IsOnPHead(e.Location) == true ? ContainPreEpower.ContainPhead : ContainPreEpower.ContainPTail;

        }

        #endregion Mouse Down

        #region Mouse_Move

        public virtual void ButtonInstance_MouseMove(MouseEventArgs e)
        {
            //Xử lí draw line        
            if (!this.isDragging) return;

            if (!this.isMove)
            {
                if (this.allowCreatLine)    //Drawn Line
                    this._endPLinetemp = this._ePower.EPowerLineTemp.GenerateLine(e, this._startPLineTemp);

                this._ePower.FormCapstone.ShowPointConnect();
                return;
            }

            bool isOnMain = this.IsOnPanelMain(e);

            if (!isOnMain) return;

            this._ePower.Location = this.TransferPosMouseToControl(e);

            if (this._ePower.ListBranch_Drawn.Count == 0) return;
            
            this.UpdateLineWhenMove();
            // button move will remove line. So Drawn all circumstance
            this._ePower.FormCapstone.DrawAllLineOnPanel();
            this._ePower.LblInfoE.Refresh();
        }

        public virtual void UpdateLineWhenMove()
        {
            //When btn move then update , if don't move not update line
            this.processEPowerMove.ProcessEPowerMoveOverall(this._ePower.EPowerLineTemp);
            this._ePower.Refresh();
        }

        #endregion Mouse_Move

        #region Mouse Up
        public virtual void ButtonInstance_MouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;

            this.isDragging = false;

            if (!this.isMove)
            {
                if (this.allowCreatLine) this.CheckAndAddLineConnet(this._ePower);
                return;
            }

            bool isOnMain = this.IsOnPanelMain(e);

            if (!isOnMain)
            {
                this._ePower.Location = this.previousMouseLocation;
                return;
            }

            this._ePower.Location = this.TransferPosMouseToControl(e);
            //After move update again postion of Epower. When move difference Zoom
            double zoomFactor = this._ePower.PanelMain.ZoomFactor;
            this._ePower.PreLocation = DAOProcessCapstone.Instance.CalculatePreLocationWhenInstance(zoomFactor, this._ePower.Location, this._ePower.FormCapstone.EPowers, this._ePower.PanelMain);

        }

        protected virtual void CheckAndAddLineConnet(ConnectableE buttonInstance)
        {
            //Clear line temp
            this._ePower.EPowerLineTemp.ClearOldLine();
            this.allowCreatLine = false;

            // Find have button contain endpoint of Line
            ConnectableE EndEPower = this._ePower.FormCapstone.CheckEndLineIsOnEPower(this._endPLinetemp, this._ePower);
            if (EndEPower == null) return;

            //MF is allowed only connect with Bus, similiar with Load only connect with Bus. All EPower must connect with bus
            if (EndEPower.DatabaseE.ObjectType != ObjectType.Bus) return;

            //Check endPoint is near Pheah or Ptail. not use isOnpHead or Patil beacause endLocation use mouse of other button
            Point pointEndToBtn;
            if (this._ePower.DatabaseE.ObjectType != ObjectType.MBA3P) pointEndToBtn = EndEPower.IsOnNearPHead() ? EndEPower.PHead : EndEPower.PTail;
            else
            {
                EndEPower.SetIsOnNearAnyPEnds();
                if (EndEPower.NearPIntern) pointEndToBtn = EndEPower.PIntern;
                else if (EndEPower.NearPHead) pointEndToBtn = EndEPower.PHead;
                else pointEndToBtn = EndEPower.PTail;
            }
            //get bool contain Phead or Ptail
            bool isContainEnds = (pointEndToBtn == EndEPower.PHead) ? EndEPower.IsContainPhead : EndEPower.IsContainPtail;
            if (pointEndToBtn == EndEPower.PIntern) isContainEnds = EndEPower.IsContainPIntern;

            if (EndEPower.DatabaseE.ObjectType == ObjectType.Bus) isContainEnds = false;//=?Bus can add > 2
            if (isContainEnds) return; //=> EndPoint has LineConnect 

            //Transfer EndMouse to Point of pnlMain system. EndMouse = pointEndToBtn = Phead or PTail of EndEPower not Instance
            this._endPLinetemp = this.TransferPosFindToControl(EndEPower, pointEndToBtn);

            //generate new Line then add List
            LineConnect newLineConnect = new LineConnect(buttonInstance, EndEPower, this._startPLineTemp, this._endPLinetemp, this._ePower.PanelMain);
            //Add to List LineConnected on EPower Start and Bus Connected with ButtonInstance
            buttonInstance.AddLineConnectedToList(newLineConnect);
            EndEPower.AddLineConnectedToList(newLineConnect);

            //add Line On Form Capstone
            this._ePower.FormCapstone.AddLine(newLineConnect);
            this._ePower.FormCapstone.DrawAllLineOnPanel();

            //Beacause End EPower certainly is Bus => Bus not Contain Ends
            //  EndEPower.containPreEpower = (pointEndToBtn == EndEPower.PHead) ? ContainPreEpower.ContainPhead : ContainPreEpower.ContainPTail;

            //set 2 Contain Phead or Ptail  button Start , End is Bus not set Contain
            this.SetContainOnce(buttonInstance);
            buttonInstance.UpdateDataRecordEPowerWhenConnectOrRemove(false);
        }

        protected virtual void SetContainOnce(ConnectableE btnSet)
        {
            if (btnSet.ContainPreEpower == ContainPreEpower.ContainPhead)
            {
                btnSet.IsContainPhead = true;
                return;
            }
            else if (btnSet.ContainPreEpower == ContainPreEpower.ContainPIntern)
            {
                btnSet.IsContainPIntern = true;
                return;
            }
            btnSet.IsContainPtail = true;

        }


        #endregion Mouse Up


        #region Mouse_Click
        //Open Form Set Data
        public virtual void ButtonInstance_DoubleMouseClick(MouseEventArgs e)
        {
            this.ShowDataRecordForEPower(this._ePower);
        }
        //Open Data Record first when drop panelmain
        public virtual void ShowDataRecordForEPower(ConnectableE ePower)
        {
            ObjectType objectType = ePower.DatabaseE.ObjectType;
            switch (objectType)
            {
                case ObjectType.Bus://Obj Type = 1
                    {
                        frmDataBus frmDataBus = new frmDataBus();
                        frmDataBus.BusEPowerFixed = ePower;
                        if (frmDataBus.ShowDialog() == DialogResult.OK) this._ePower.SetDataLabelInfo();
                    }
                    break;
                case ObjectType.MF://Obj Type = 2
                    {
                        frmDataGenerator frmDataMF = new frmDataGenerator();
                        frmDataMF.MF_EPowerFixed = ePower;
                        if (frmDataMF.ShowDialog() == DialogResult.OK) this._ePower.SetDataLabelInfo();
                    }
                    break;
                case ObjectType.MBA2P://Obj Type = 3
                    {
                        frmDataMBA2 frmDataMBA2 = new frmDataMBA2();
                        frmDataMBA2.MBA2EPowerFixed = ePower;
                        if (frmDataMBA2.ShowDialog() == DialogResult.OK) this._ePower.SetDataLabelInfo();
                    }
                    break;
                case ObjectType.MBA3P://Obj Type = 3
                    {
                        frmDataMBA3 frmDataMBA3 = new frmDataMBA3();
                        frmDataMBA3.MBA3EPowerFixed = ePower;
                        if (frmDataMBA3.ShowDialog() == DialogResult.OK) this._ePower.SetDataLabelInfo();
                    }
                    break;
                case ObjectType.LineEPower://Obj Type = 5
                    {
                        frmDataBranch frmDataLineE = new frmDataBranch();
                        frmDataLineE.LineEPowerFixed = ePower;
                        if (frmDataLineE.ShowDialog() == DialogResult.OK) this._ePower.SetDataLabelInfo();
                    }
                    break;
                case ObjectType.Load://Obj Type = 6
                    {
                        frmDataLoad frmDataLoad = new frmDataLoad();
                        frmDataLoad.LoadEPowerFixed = ePower;
                        if (frmDataLoad.ShowDialog() == DialogResult.OK) this._ePower.SetDataLabelInfo();
                    }
                    break;
            }

        }
        #endregion Mouse_Click

        #region Overall Function

        protected virtual bool IsOnPanelMain(MouseEventArgs e)
        {

            Point pMouseTopnlMain = this.TransferPosMouseToControl(e);

            bool isMain = this._ePower.PanelMain.ClientRectangle.Contains(pMouseTopnlMain);
            return isMain;
        }

        //Trả về vị vị điểm chính giữa Control
        protected virtual Point TransferPosMouseToControl(MouseEventArgs e)
        {
            //Get pos center of button Instance in order to smoothly move
            Point posCenter = new Point(e.Location.X - this._ePower.Width / 2, e.Location.Y - this._ePower.Height / 2);

            return this.TransferPosFindOnInstance(posCenter);
        }

        protected virtual Point TransferPosFindOnInstance(Point posFind)
        {
            //=> transfer Location to screen
            Point dropToScreen = this._ePower.PointToScreen(posFind);

            //=> transfer posMouse to Control Destionation
            Point pMouseTopnlMain = this._ePower.PanelMain.PointToClient(dropToScreen);

            return pMouseTopnlMain;
        }

        //Trả về Point control end khi mouse move diffrence this ConnectinE so với pnlMain
        protected virtual Point TransferPosFindToControl(ConnectableE EPowerEndLine, Point posFind)
        {
            //=> transfer Location to screen
            Point dropToScreen = EPowerEndLine.PointToScreen(posFind);

            //=> transfer posMouse to Control Destionation
            Point pMouseTopnlMain = this._ePower.PanelMain.PointToClient(dropToScreen);

            return pMouseTopnlMain;
        }

        #endregion Overall Function
    }
}
