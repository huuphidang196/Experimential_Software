using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Drawing.Drawing2D;

namespace Experimential_Software
{
    public partial class ProcessConnectControl 
    {
        private Point _startOldLine;
        private Point _endOldLine;

        Panel pnlMain;

        //startPointLine is on coordinate pnlMain system
        public virtual Point GenerateLine(object sender, MouseEventArgs e, Object pnlDes, Point startPointLine)
        {
            ConnectableE buttonInstance = sender as ConnectableE;
            this.pnlMain = pnlDes as Panel;

            // Xóa các line cũ bằng cách vẽ lại nền của panel
            this.ClearOldLine();
            //pnlMain.CreateGraphics().Clear(pnlMain.BackColor);

            // Lấy vị trí con trỏ chuột trên pnlMain
            Point mousePoint = pnlMain.PointToClient(Cursor.Position);

            this._startOldLine = startPointLine;
            this._endOldLine = mousePoint;

            //// Vẽ new line 
            pnlMain.CreateGraphics().DrawLine(Pens.Black, startPointLine, mousePoint);

            return mousePoint;

        }

        public virtual void ClearOldLine()
        {
            if (this._startOldLine != Point.Empty && this._endOldLine != Point.Empty)
            {
                pnlMain.CreateGraphics().DrawLine(Pens.White, this._startOldLine, this._endOldLine);
            }
        }

        public virtual void ClearTwoOldLineWhenMove(LineConnect LineRemove, Panel pnlMain)
        {
            this.pnlMain = pnlMain;

            Point startLine = LineRemove.StartPoint;
            Point endLine = LineRemove.EndPoint;
            //Clean
            this.ClearOldLine(startLine, endLine);
        }

        public virtual void ClearOldLine(Point startLine, Point endLine)
        {
            if (startLine != Point.Empty && endLine != Point.Empty)
            {
                pnlMain.CreateGraphics().DrawLine(Pens.White, startLine, endLine);
            }
        }
        protected virtual Point TransferPointToMain(ConnectableE btnOrigin, Point pointN)
        {
            Point pointForm = btnOrigin.PointToScreen(pointN);
            Point pointMain = pnlMain.PointToClient(pointForm);

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