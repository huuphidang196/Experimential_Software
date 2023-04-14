using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Drawing.Drawing2D;
using Experimential_Software.CustomControl;

namespace Experimential_Software.EPowerProcess
{
    public partial class EPowerProcessLineTemp
    {
        protected ConnectableE _ePower;

        private Point _startOldLine;
        private Point _endOldLine;

        protected PanelMain pnlMain_Drawn;
        public EPowerProcessLineTemp(ConnectableE ePowerInstance)
        {
            this._ePower = ePowerInstance;
            this.pnlMain_Drawn = ePowerInstance.PanelMain;
        }

        public virtual Point GenerateLine( MouseEventArgs e, Point startPointLine)
        {
            // Xóa các line cũ bằng cách vẽ lại nền của panel
            this.ClearOldLine();

            // Lấy vị trí con trỏ chuột trên pnlMain
            Point mousePoint = pnlMain_Drawn.PointToClient(Cursor.Position);

            this._startOldLine = startPointLine;
            this._endOldLine = mousePoint;

            //// Vẽ new line 
            pnlMain_Drawn.CreateGraphics().DrawLine(Pens.Black, startPointLine, mousePoint);

            return mousePoint;

        }

        public virtual void ClearOldLine()
        {
            if (this._startOldLine != Point.Empty && this._endOldLine != Point.Empty)
            {
                pnlMain_Drawn.CreateGraphics().DrawLine(Pens.White, this._startOldLine, this._endOldLine);
            }
        }

        public virtual void ClearTwoOldLineWhenMove(LineConnect LineRemove)
        {
            Point startLine = LineRemove.StartPoint;
            Point endLine = LineRemove.EndPoint;
            //Clean
            this.ClearOldLine(startLine, endLine);
        }

        public virtual void ClearOldLine(Point startLine, Point endLine)
        {
            if (startLine != Point.Empty && endLine != Point.Empty)
            {
                pnlMain_Drawn.CreateGraphics().DrawLine(Pens.White, startLine, endLine);
            }
        }


        // not reference, => final check then remove if not reference
        protected virtual Point TransferPointToMain(ConnectableE btnOrigin, Point pointN)
        {
            Point pointForm = btnOrigin.PointToScreen(pointN);
            Point pointMain = pnlMain_Drawn.PointToClient(pointForm);

            return pointMain;
        }


    }


}
















//public virtual void GenerateLine(object sender, MouseEventArgs e, Object pnlDes, Point startPointLine)
//{
//    ConnectableE buttonInstance = this.ConvertInstance(sender);

//    Panel pnlMain = pnlDes as Panel;
//    this.colorBGMain = pnlMain.BackColor;

//    // Xóa các line cũ bằng cách vẽ lại nền của panel
//    pnlMain.CreateGraphics().Clear(this.colorBGMain);

//    //Láy vị trí Phead hoặc Ptail của control
//    Point startLine = buttonInstance.IsOnPHead(startPointLine) ? buttonInstance.PHead : buttonInstance.PTail;
//    Point startLtoMain = this.TransferPosFindToControl(buttonInstance, pnlMain, startLine);

//    // Lấy vị trí con trỏ chuột trên pnlMain
//    Point mousePoint = pnlMain.PointToClient(Cursor.Position);

//    // Thêm line mới vào danh sách
//    lines.Add(new Line(startLtoMain, mousePoint));

//    // Vẽ lại các line từ danh sách
//    foreach (Line line in lines)
//    {
//        Point startPoint = line.StartPoint;
//        Point endPoint = line.EndPoint;
//        pnlMain.CreateGraphics().DrawLine(Pens.Black, startPoint, endPoint);
//    }

//    ////so sánh pos chuột vs end cũ => disposed
//    //using (Graphics g = pnlMain.CreateGraphics())
//    //{
//    //    g.DrawLine(Pens.Black, startLtoMain, endLtoMain);
//    //}

//}