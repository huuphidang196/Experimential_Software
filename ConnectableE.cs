using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.Class_Small;

namespace Experimential_Software
{
    public enum ContainPreEpower
    {
        NoContain = 0,

        ContainPhead = 1,
        ContainPTail = 2,
    }

    public enum ObjectType
    {
        NoType = 0,

        MF = 1,
        Bus = 2,
        MBA = 3,
        LineEPower = 4,
        Load = 5,
    }

    public partial class ConnectableE : Button, IMouseOnEndsControl
    {
        protected frmCapstone _formCap;
        public frmCapstone FormCapstone => _formCap;

        protected PanelMain pnlMain_Drawn;
        public PanelMain PanelMain => pnlMain_Drawn;


        protected DatabaseEPower databaseE;
        public DatabaseEPower DatabaseE => databaseE;

        protected EPowerProcessMouse _ePowerMouse;

        protected EPowerProcessLineTemp _ePowerLineTemp;
        public EPowerProcessLineTemp EPowerLineTemp => _ePowerLineTemp;

        protected EPowerProcessKey _ePowerKey;

        protected Label lblInfo;
        public Label LblInfoE => lblInfo;

        public bool isOnTool { get; set; }

        protected bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                Invalidate();
            }
        }

        protected int _flag = 0;
        public int Flag { get => _flag; set => _flag = value; }

        protected int _radiusPoint = 7;

        protected Point pHead;
        protected Point pTail;

        public Point PHead
        {
            get { return pHead; }
            set
            {
                pHead = value;
                //  Invalidate();
            }
        }
        public Point PTail
        {
            get { return pTail; }
            set
            {
                pTail = value;
                //  Invalidate();
            }
        }

        protected bool isContainPhead;
        public bool IsContainPhead { get => isContainPhead; set => isContainPhead = value; }

        protected bool isContainPtail;
        public bool IsContainPtail { get => isContainPtail; set => isContainPtail = value; }

        public ContainPreEpower containPreEpower { get; set; }

        protected bool isPHead = false;
        protected bool isPtail = false;

        protected bool nearPhead = false;
        protected bool isMove = false;
        public bool IsMove
        {
            get { return isMove; }
            set
            {
                isMove = value;
            }
        }

        protected bool mouseEnter = false;

        #region Constructor_Class

        public ConnectableE()
        {
            //InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;

            Width = 50;
            Height = 50;
            this.isOnTool = true;
        }

        public ConnectableE(frmCapstone form, PanelMain pnlMain, DatabaseEPower databaseEPower, ImageList imgList)
        {
            this._formCap = form;
            this.pnlMain_Drawn = pnlMain;

            //Set variable
            this.SetVariableOnEPower(databaseEPower, imgList);

            // InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            // Gán sự kiện DoubleClick cho custom button

        }
  
        protected virtual void SetVariableOnEPower(DatabaseEPower databaseEPower, ImageList imgList)
        {
            this.databaseE = databaseEPower;

            this.Width = this.databaseE.Width;
            this.Height = this.databaseE.Height;

            this.isOnTool = true;
            this.isSelected = false;
            this.isContainPhead = false;
            this.isContainPtail = false;
            this.containPreEpower = ContainPreEpower.NoContain;

            int numberImage = databaseE.NumberImage;
            Image originalImage = imgList.Images[numberImage];

            // Tính toán tỉ lệ giữa kích thước control và kích thước ảnh gốc
            float ratioX = (float)this.Width / (float)originalImage.Width;
            float ratioY = (float)this.Height / (float)originalImage.Height;
            float ratio = Math.Min(ratioX, ratioY);

            // Tính toán kích thước ảnh mới
            int newWidth = (int)(originalImage.Width * ratio);
            int newHeight = (int)(originalImage.Height * ratio);

            Image resizedImage = originalImage.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero);

            this.Image = resizedImage;

            // Vẽ ảnh lên control với kích thước mới
            //MessageBox.Show(this.ImageList.ImageSize + "");
            // Set Object Number
            this.pnlMain_Drawn.PanelMainMouse.ProcessSetNumberObjetEPower(this);

            this.GenerateClassProcessChild();

            this.SetPHeadAndPtail();
        }
        protected virtual void GenerateClassProcessChild()
        {
            this._ePowerMouse = new EPowerProcessMouse(this);
            this._ePowerKey = new EPowerProcessKey(this);
            this._ePowerLineTemp = new EPowerProcessLineTemp(this);

            this.GenerateDataLabelInfo();
        }

        protected virtual void GenerateDataLabelInfo()
        {
            this.lblInfo = new Label();
            lblInfo.Font = new Font("Sans-serif", 8, FontStyle.Regular);
            lblInfo.AutoSize = true;

            //Set data show on EPower
            this.SetDataLabelInfo();
           
            // Set Pos lbl
            this.UpdatePositonLabelInfo();

            this.pnlMain_Drawn.Controls.Add(lblInfo);
        }

        public virtual void SetDataLabelInfo()
        {
            lblInfo.Text = this.ToString();
        }

        protected virtual void UpdatePositonLabelInfo()
        {
            lblInfo.Location = new Point(this.Location.X - 120, this.Location.Y - 20);
        }

        protected virtual void SetPHeadAndPtail()
        {
            //MF
            if (this.databaseE.ObjectType == ObjectType.MF)
            {
                this.pHead = new Point(Width / 2, Height - 4);
                this.pTail = Point.Empty;
                this.isContainPtail = true;
                return;
            }

            //Load
            if (this.databaseE.ObjectType == ObjectType.Load)
            {
                this.pHead = new Point(Width / 2, 0);
                this.pTail = Point.Empty;
                this.isContainPtail = true;
                return;
            }

            //Circle => MBA, Line Width > Height
            if (this.Width <= this.Height)
            {
                this.pHead = new Point(Width / 2, 0);
                this.pTail = new Point(Width / 2, Height); //oy Top to Down
                return;
            }
            //=> Bus
            this.pHead = new Point(Width / 2 - Width / 4, Height / 2);
            this.pTail = new Point(Width / 2 + Width / 4, Height / 2);

        }

        #endregion Constructor_Class

        #region Drawn
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // it is on tool not flicker//nhấp nháy
            if (this.isOnTool) return;

            //Drawn Read or remove color when press and not press => update 
            this.DrawRectangleAround(e);

            if (this.mouseEnter && !this.isMove)
            {
                this.nearPhead = this.IsOnNearPHead();
                Point pEnds = this.nearPhead ? this.pHead : this.pTail;
                bool contained = this.nearPhead ? this.isContainPhead : this.isContainPtail;

                if (contained && this.databaseE.ObjectType != ObjectType.Bus) pEnds = Point.Empty;

                if (this.databaseE.ObjectType == ObjectType.MF) pEnds = this.pHead;
                this.DrawCubePinkMouseNearEnds(e, pEnds);
            }


        }
        protected virtual void DrawCubePinkMouseNearEnds(PaintEventArgs e, Point pEnds)
        {
            if (pEnds == Point.Empty) return;

            using (var pen = new Pen(Color.Pink, 3))
            {
                int Point_Oxy = this.Width > this.Height ? pEnds.X : pEnds.Y;
                int PointDrawm = this.nearPhead ? Point_Oxy : Point_Oxy - this._radiusPoint;

                var rectWBigH = new Rectangle(PointDrawm, (Height - this._radiusPoint) / 2, this._radiusPoint, this._radiusPoint);
                var rectWLessH = new Rectangle((Width - this._radiusPoint) / 2, PointDrawm, this._radiusPoint, this._radiusPoint);

                var rectEnds = this.Width > this.Height ? rectWBigH : rectWLessH;

                e.Graphics.DrawRectangle(pen, rectEnds);
                e.Graphics.FillRectangle(Brushes.Pink, rectEnds);
            }

        }
        //Mouse Down Light around
        protected virtual void DrawRectangleAround(PaintEventArgs e)
        {
            var pen = this.isSelected ? new Pen(Color.Red, 5) : new Pen(Color.Transparent, 5);
            using (pen)
            {
                var rect = new Rectangle(0, 0, Width, Height);
                e.Graphics.DrawRectangle(pen, rect);
                e.Graphics.FillRectangle(Brushes.Transparent, rect);
            }

        }
        #endregion Drawn

        #region Mouse
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Right) return;

            if (this._ePowerMouse == null) return;

            this.isMove = !this.IsConnection(e.Location);

            this.isSelected = !this.isSelected;

            //If selected this then remove other EPower
            if (this.isSelected)
            {
                this._formCap.SetIsSelectedEPower(this);
                //=> Coincide Selected Line = false
                this.pnlMain_Drawn.PanelMainMouse.SetFalseSelectedOtherLine(null, this._formCap.LineConnectList);
            }

            //nhớ OnMouseDown chỉ để move Point in order to Connect
            this._ePowerMouse.ButtonInstance_MouseDown(e);
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Right) return;

            if (this._ePowerMouse == null) return;

            if (this.isOnTool) return;

            this.mouseEnter = true;

            this._ePowerMouse.ButtonInstance_MouseMove(e);
            // Set Pos lbl
            this.UpdatePositonLabelInfo();
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Right) return;

            if (this._ePowerMouse == null) return;

            //=> Check if ko move trước đó thì ko set Pos  

            this._ePowerMouse.ButtonInstance_MouseUp(e);
            this.isMove = false;
            this._flag = 0;
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

        #endregion Mouse


        #region Key

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (this._ePowerKey == null) return;

            //Only allow remove When btn is selected
            if (!this.isSelected) return;
            this._ePowerKey.EPowerInstance_KeyDown(e);

        }

        #endregion Key

        #region Function_Overall

        public virtual bool IsConnection(Point ePoint)
        {
            this.isPHead = this.IsOnPHead(ePoint);
            this.isPtail = this.IsOnPTail(ePoint);

            if (!this.isPHead && !this.isPtail) return false;

            return true;
        }

        /// <summary>
        /// Don't remove isOntool beacause objectype isn't set
        /// </summary>
        /// <param name=" this.databaseE.objectType == ObjectType.MF"></param>
        /// <returns></returns>
        public virtual bool IsOnPHead(Point ePoint)
        {
            if (ePoint.X > this.pHead.X + 10 && this.Width > this.Height) return false;
            if (ePoint.Y < this.pHead.Y - 10 && !this.isOnTool && this.databaseE.ObjectType == ObjectType.MF) return false;
            if (ePoint.Y > this.pHead.Y + 10 && this.Width <= this.Height) return false;

            return true;
        }


        public virtual bool IsOnPTail(Point ePoint)
        {
            if (ePoint.X < this.pTail.X - 10 && this.Width > this.Height) return false;
            if (!this.isOnTool && this.databaseE.ObjectType == ObjectType.MF) return false;
            if (!this.isOnTool && this.databaseE.ObjectType == ObjectType.Load) return false;
            if (ePoint.Y < this.pTail.Y - 10 && this.Width <= this.Height) return false;

            return true;
        }

        public virtual bool IsOnNearPHead()
        {
            Point pointHeadtoScreen = this.PointToScreen(this.pHead);
            Point pointTailtoScreen = this.PointToScreen(this.pTail);

            double distanceHead = this.Distance(pointHeadtoScreen);
            double distanceTail = this.Distance(pointTailtoScreen);

            // if (this.databaseE.objectType == ObjectType.MF) distanceTail = 10000;=> Generator
            if (distanceHead < distanceTail) return true;
            return false;
        }

        protected virtual double Distance(Point pointCal)
        {
            double distance = Math.Sqrt(Math.Pow(Cursor.Position.X - pointCal.X, 2) + Math.Pow(Cursor.Position.Y - pointCal.Y, 2));
            return distance;
        }


        public virtual void MouseMoveEnds()
        {
            Point mouseLocal = this.Parent.PointToClient(Cursor.Position);
            if (!this.Bounds.Contains(mouseLocal)) return;

            this.mouseEnter = true;
            Invalidate();
        }

        public override string ToString()
        {
            ObjectType objType = this.databaseE.ObjectType;
            string objName = this.databaseE.ObjectName;
            int objNumber = this.databaseE.ObjectNumber;
            return objType + " " + objNumber + ", Name : " + objName;
        }

        #endregion Function_Overall
    }
}
































//}

//public virtual bool IsOnPHead(Point ePoint)
//{
//    if (ePoint.X > this.pHead.X + 10 && this.Width > this.Height) return false;
//    if (ePoint.Y < this.pHead.Y - 10 && !this.isOnTool && this.databaseE.objectType == ObjectType.MF) return false;
//    if (ePoint.Y > this.pHead.Y + 10 && this.Width <= this.Height) return false;

//    return true;
//}

//public virtual bool IsOnPTail(Point ePoint)
//{
//    if (ePoint.X < this.pTail.X - 10 && this.Width > this.Height) return false;
//    if (!this.isOnTool && this.databaseE.objectType == ObjectType.MF) return false;
//    if (ePoint.Y < this.pTail.Y - 10 && this.Width <= this.Height) return false;

//    return true;
//}




//protected override void OnPaint(PaintEventArgs e)
//{
//    base.OnPaint(e);
//    if (this.mouseEnter && !this.isMove)
//    {
//        this.nearPhead = this.IsOnNearPHead();
//        Point pEnds = this.nearPhead ? this.pHead : this.pTail;

//        this.DrawCubePinkMouseNearEnds(e, pEnds);
//    }
//    // Draw the rectangle
//    using (var pen = new Pen(Color.Black, 3))
//    {
//        // this.DrawRectangleAndPoint(pen, e);
//    }
//}

//protected virtual void DrawRectangleAndPoint(Pen pen, PaintEventArgs e)
//{
//    int offSetBothside = this._offSetLength + this._radiusPoint;
//    var rect = new Rectangle(offSetBothside, 10, Width - (2 * offSetBothside), Height - 20);
//    e.Graphics.DrawRectangle(pen, rect);
//    e.Graphics.FillRectangle(Brushes.Transparent, rect);

//}




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