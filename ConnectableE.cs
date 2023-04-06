using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software
{
    public enum ContainPreEpower
    {
        NoContain = 0,

        ContainPhead = 1,
        ContainPTail = 2,
    }
    public partial class ConnectableE : Button, IMouseOnEndsControl
    {
        private int _offSetLength = 15;
        private int _radiusPoint = 7;

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

        private bool isContainPhead;
        public bool IsContainPhead { get => isContainPhead; set => isContainPhead = value; }

        private bool isContainPtail;
        public bool IsContainPtail { get => isContainPtail; set => isContainPtail = value; }

        public ContainPreEpower containPreEpower { get; set; }

        private bool isPHead = false;
        private bool isPtail = false;

        private bool nearPhead = false;
        private bool isMove = false;
        public bool IsMove
        {
            get { return isMove; }
            set
            {
                isMove = value;
            }
        }

        private bool mouseEnter = false;
        public ConnectableE()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;

            Width = 30;
            Height = 80;

            this.isContainPhead = false;
            this.isContainPtail = false;
            this.containPreEpower = ContainPreEpower.NoContain;

            //Circle => MF, Line Width > Height
            if (this.Width <= this.Height)
            {
                this.pHead = new Point(Width / 2, 0);
                this.pTail = new Point(Width / 2, Height); //oy Top to Down
                return;
            }
            //=> Bus
            this.pHead = new Point(0, Height / 2);
            this.pTail = new Point(Width, Height / 2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.mouseEnter && !this.isMove)
            {
                this.nearPhead = this.IsOnNearPHead();
                Point pEnds = this.nearPhead ? this.pHead : this.pTail;

                this.DrawCubePinkMouseNearEnds(e, pEnds);
            }
            // Draw the rectangle
            using (var pen = new Pen(Color.Black, 3))
            {
                // this.DrawRectangleAndPoint(pen, e);
            }
        }

        protected virtual void DrawRectangleAndPoint(Pen pen, PaintEventArgs e)
        {
            int offSetBothside = this._offSetLength + this._radiusPoint;
            var rect = new Rectangle(offSetBothside, 10, Width - (2 * offSetBothside), Height - 20);
            e.Graphics.DrawRectangle(pen, rect);
            e.Graphics.FillRectangle(Brushes.Transparent, rect);

            //// Calculate the midpoint of the short sides of the rectangle
            //Point midpoint1 = new Point(rect.X, rect.Y + rect.Height / 2);
            //Point midpoint2 = new Point(rect.X + rect.Width, rect.Y + rect.Height / 2);

            //// Draw the first point
            //var rectPHead = new Rectangle(this.pHead.X, (Height - this._radiusPoint) / 2, this._radiusPoint, this._radiusPoint);
            //e.Graphics.FillEllipse(Brushes.Red, rectPHead);
            //e.Graphics.DrawEllipse(Pens.Black, rectPHead);

            //// Draw the second point
            //var rectPTail = new Rectangle(this.pTail.X - this._radiusPoint, (Height - this._radiusPoint) / 2, this._radiusPoint, this._radiusPoint);
            //e.Graphics.FillEllipse(Brushes.Green, rectPTail);
            //e.Graphics.DrawEllipse(Pens.Black, rectPTail);

            //Point connectA1 = new Point(this.pHead.X + this._radiusPoint, this.pHead.Y);
            //Point connectA2 = new Point(this.pTail.X - this._radiusPoint, this.pTail.Y);


            //// Draw lines from the midpoints to the start and end points
            //e.Graphics.DrawLine(pen, midpoint1, connectA1);
            //e.Graphics.DrawLine(pen, midpoint2, connectA2);
        }

        protected virtual void DrawCubePinkMouseNearEnds(PaintEventArgs e, Point pEnds)
        {
            using (var pen = new Pen(Color.Pink, 3))
            {
                int PointDrawm;
                var rectEnds = new Rectangle();
                if (this.Width > this.Height)
                {
                    PointDrawm = this.nearPhead ? pEnds.X : pEnds.X - this._radiusPoint;
                    rectEnds = new Rectangle(PointDrawm, (Height - this._radiusPoint) / 2, this._radiusPoint, this._radiusPoint);
                }
                else
                {
                    PointDrawm = this.nearPhead ? pEnds.Y: pEnds.Y - this._radiusPoint - 3;// this._radiusPoint;
                    rectEnds = new Rectangle((Width - this._radiusPoint) / 2, PointDrawm, this._radiusPoint, this._radiusPoint);
                }

                e.Graphics.DrawRectangle(pen, rectEnds);
                e.Graphics.FillRectangle(Brushes.Pink, rectEnds);
            }

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.isMove = !this.IsConnection(e.Location);

            //nhớ OnMouseDown chỉ để move Point in order to Connect

            base.OnMouseDown(e);
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.mouseEnter = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            //=> Check if ko move trước đó thì ko set Pos  
            base.OnMouseUp(mevent);
            this.isMove = false;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.mouseEnter = true;
            Invalidate();
        }


        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.mouseEnter = false;
            Invalidate();
        }

        public virtual bool IsConnection(Point ePoint)
        {
            this.isPHead = this.IsOnPHead(ePoint);
            this.isPtail = this.IsOnPTail(ePoint);

            if (!this.isPHead && !this.isPtail) return false;

            return true;
        }


        public virtual bool IsOnPHead(Point ePoint)
        {
            if (ePoint.X > this.pHead.X + 10 && this.Width > this.Height) return false;
            if (ePoint.Y > this.pHead.Y + 10 && this.Width <= this.Height) return false;

            return true;
        }

        public virtual bool IsOnPTail(Point ePoint)
        {
            if (ePoint.X < this.pTail.X - 10 && this.Width > this.Height) return false;
            if (ePoint.Y < this.pTail.Y - 10 && this.Width <= this.Height) return false;

            return true;
        }

        public virtual bool IsOnNearPHead()
        {
            Point pointHeadtoScreen = this.PointToScreen(this.pHead);
            Point pointTailtoScreen = this.PointToScreen(this.pTail);

            double distanceHead = this.Distance(pointHeadtoScreen);
            double distanceTail = this.Distance(pointTailtoScreen);

            if (distanceHead < distanceTail) return true;
            return false;
        }

        protected virtual double Distance(Point pointCal)
        {
            double distance = Math.Sqrt(Math.Pow(Cursor.Position.X - pointCal.X, 2) + Math.Pow(Cursor.Position.Y - pointCal.Y, 2));
            return distance;
        }

        public void MouseMoveEnds()
        {
            Point mouseLocal = this.Parent.PointToClient(Cursor.Position);
            if (!this.Bounds.Contains(mouseLocal)) return;

            this.mouseEnter = true;
            Invalidate();
        }
    }
}
