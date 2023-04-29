﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Experimential_Software.Class_Database;
using Experimential_Software.CustomControl;
using Experimential_Software.DAO.DAO_LoadData;
using Experimential_Software.DAO.DAO_LineData;
using Experimential_Software.DAO.DAO_GeneratorData;

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

        private int _clickCount = 0;

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
            bool isPhead = this._ePower.IsOnPHead(e.Location);
            bool isContainEnds = (isPhead == true) ? this._ePower.IsContainPhead : this._ePower.IsContainPtail;

            if (this._ePower.DatabaseE.ObjectType == ObjectType.Bus) isContainEnds = true;//=?Bus can not point start line
            if (isContainEnds) return;

            //Coordinate button system
            Point pointStartOnButton = isPhead == true ? this._ePower.PHead : this._ePower.PTail;


            //coordinate pnlMain system
            this._startPLineTemp = this.TransferPosFindToControl(this._ePower, pointStartOnButton);
            this.allowCreatLine = true;

            this._ePower.containPreEpower = isPhead == true ? ContainPreEpower.ContainPhead : ContainPreEpower.ContainPTail;
        }

        #endregion Mouse Down

        #region Mouse_Move

        public virtual void ButtonInstance_MouseMove(MouseEventArgs e)
        {
            if (this._clickCount == 2) return;

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
            this.UpdateLineWhenMove();

        }

        public virtual void UpdateLineWhenMove()
        {
            //When btn move then update , if don't move not update line
            this.processEPowerMove.ProcessEPowerMoveOverall(this._ePower.EPowerLineTemp);

            // button move will remove line. So Drawn all circumstance
            this._ePower.FormCapstone.DrawAllLineOnPanel();
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
            this._ePower.OldLocation = this._ePower.Location;
            // MessageBox.Show("After Old Location = " + this._ePower.OldLocation);
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
            Point pointEndToBtn = EndEPower.IsOnNearPHead() ? EndEPower.PHead : EndEPower.PTail;

            //get bool contain Phead or Ptail
            bool isContainEnds = (pointEndToBtn == EndEPower.PHead) ? EndEPower.IsContainPhead : EndEPower.IsContainPtail;

            if (EndEPower.DatabaseE.ObjectType == ObjectType.Bus) isContainEnds = false;//=?Bus can add > 2
            if (isContainEnds) return; //=> EndPoint has LineConnect 

            //Transfer EndMouse to Point of pnlMain system. EndMouse = pointEndToBtn = Phead or PTail of EndEPower not Instance
            this._endPLinetemp = this.TransferPosFindToControl(EndEPower, pointEndToBtn);

            //generate new Line then add List
            LineConnect newLineConnect = new LineConnect(buttonInstance, EndEPower, this._startPLineTemp, this._endPLinetemp, this._ePower.PanelMain);
            //add Line 
            this._ePower.FormCapstone.AddLine(newLineConnect);
            this._ePower.FormCapstone.DrawAllLineOnPanel();


            EndEPower.containPreEpower = (pointEndToBtn == EndEPower.PHead) ? ContainPreEpower.ContainPhead : ContainPreEpower.ContainPTail;

            //set 2 Contain Phead or Ptail 2 button
            this.SetContainTwoButton(buttonInstance, EndEPower);
            this.UpdateDataRecordEPower(buttonInstance);
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

        protected virtual void UpdateDataRecordEPower(ConnectableE buttonInstance)
        {
            //Except Bus
            ObjectType objType = this._ePower.DatabaseE.ObjectType;
            switch (objType)
            {
                case ObjectType.MF: // 2
                    {
                        //Update DataDTO bus After Connect 
                        DAOUpdateMFAfterConnectBus.Instance.UpdateMFAfterConnectEnds(buttonInstance);
                    }
                    break;
                case ObjectType.LineEPower: // 5
                    {
                        //Update DataDTO bus After Connect 
                        DAOUpdateLineAfterConnectEnds.Instance.UpdateLineAfterConnectEnds(buttonInstance);
                    }
                    break;
                case ObjectType.Load://6
                    {
                        //Update DataDTO bus After Connect 
                        DAOUpdateLoadAfterConnectBus.Instance.UpDateLoadRecordAfterConnectBus(buttonInstance);
                    }
                    break;
            }    
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
                case ObjectType.MF://Obj Type = 1
                    {
                        frmDataGenerator frmDataMF = new frmDataGenerator();
                        frmDataMF.MF_EPowerFixed = ePower;
                        if (frmDataMF.ShowDialog() == DialogResult.OK) this._ePower.SetDataLabelInfo();
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