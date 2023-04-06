
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software
{
    public class LinePowerBase : Button
    {
        private Point pHead;
        private Point pTail;

        public Point PHead
        {
            get { return pHead; }
            set
            {
                pHead = value;
                Invalidate();
            }
        }

        public Point PTail
        {
            get { return pTail; }
            set
            {
                pTail = value;
                Invalidate();
            }
        }

        private int _offSetLength = 15;
        private int _radiusPoint = 10;

        private bool isPHead = false;
        private bool isPtail = false;
        public LinePowerBase()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;

            Width = 80;
            Height = 30;

            // Lấy tọa độ của custom control so với màn hình
            // Point controlLocation = this.PointToScreen(Point.Empty);

            //// Chuyển tọa độ của 2 Point trong custom control sang tọa độ trên màn hình
            //this.pHead = new Point(controlLocation.X + this.offSet, controlLocation.Y + Height/2);
            //this.pTail = new Point(controlLocation.X + Width + this.offSet, controlLocation.Y + Height/2);

            this.pHead = new Point(0, Height / 2);
            this.pTail = new Point(Width, Height / 2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw the rectangle
            using (var pen = new Pen(Color.Black, 3))
            {
                this.DrawRectangleAndPoint(pen, e);
            }
        }

        protected virtual void DrawRectangleAndPoint(Pen pen, PaintEventArgs e)
        {
            int offSetBothside = this._offSetLength + this._radiusPoint;
            var rect = new Rectangle(offSetBothside, 10, Width - (2 * offSetBothside), Height - 20);
            e.Graphics.DrawRectangle(pen, rect);
            e.Graphics.FillRectangle(Brushes.Transparent, rect);

            // Calculate the midpoint of the short sides of the rectangle
            Point midpoint1 = new Point(rect.X, rect.Y + rect.Height / 2);
            Point midpoint2 = new Point(rect.X + rect.Width, rect.Y + rect.Height / 2);

            // Draw the first point
            var rectPHead = new Rectangle(this.pHead.X, (Height - this._radiusPoint) / 2, this._radiusPoint, this._radiusPoint);
            e.Graphics.FillEllipse(Brushes.Red, rectPHead);
            e.Graphics.DrawEllipse(Pens.Black, rectPHead);

            // Draw the second point
            var rectPTail = new Rectangle(this.pTail.X - this._radiusPoint, (Height - this._radiusPoint) / 2, this._radiusPoint, this._radiusPoint);
            e.Graphics.FillEllipse(Brushes.Green, rectPTail);
            e.Graphics.DrawEllipse(Pens.Black, rectPTail);

            Point connectA1 = new Point(this.pHead.X + this._radiusPoint, this.pHead.Y);
            Point connectA2 = new Point(this.pTail.X - this._radiusPoint, this.pTail.Y);


            // Draw lines from the midpoints to the start and end points
            e.Graphics.DrawLine(pen, midpoint1, connectA1);
            e.Graphics.DrawLine(pen, midpoint2, connectA2);
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;


            if (!IsConnection(e.Location)) return;
            //nhớ OnMouseDown chỉ để move Point in order to Connect
            base.OnMouseDown(e);
        }


        protected virtual bool IsConnection(Point ePoint)
        {
            this.isPHead = this.IsOnPHead(ePoint);
            this.isPtail = this.IsOnPTail(ePoint);

            if (!this.isPHead && !this.isPtail)
            {
                MessageBox.Show("Not Move");
                return false;
            }
            return true;
        }



        protected virtual bool IsOnPHead(Point ePoint)
        {
            if (ePoint.X > this.pHead.X + 10) return false;
            MessageBox.Show("Phead");
            return true;
        }

        protected virtual bool IsOnPTail(Point ePoint)
        {
            if (ePoint.X < this.pTail.X - 10) return false;
            MessageBox.Show("PTail");
            return true;
        }
    }

}

