using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.Class_Database;
using Experimential_Software.EPowerProcess;

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

    public enum GenerateMode
    {
        Instance = 1,

        LoadDatabase = 2,
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
        public EPowerProcessMouse EPowerProcessMouse => _ePowerMouse;

        protected EPowerProcessLineTemp _ePowerLineTemp;
        public EPowerProcessLineTemp EPowerLineTemp => _ePowerLineTemp;

        protected EPowerProcessKey _ePowerKey;

        protected Label lblInfo;
        public Label LblInfoE { get => lblInfo; set => lblInfo = value; }

        protected Point _oldLocation;
        public Point OldLocation { get => _oldLocation; set => _oldLocation = value; }

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
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;

            Width = 50;
            Height = 50;
            this.isOnTool = true;
        }

        public ConnectableE(frmCapstone form, PanelMain pnlMain, DatabaseEPower databaseEPower, ImageList imgList, GenerateMode generateMode)
        {
            this._formCap = form;
            this.pnlMain_Drawn = pnlMain;

            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;

            //Set variable
            this.SetVariableOnEPower(databaseEPower, imgList, generateMode);

        }

        protected virtual void SetVariableOnEPower(DatabaseEPower databaseEPower, ImageList imgList, GenerateMode generateMode)
        {
            this.databaseE = databaseEPower;

            this.Width = this.databaseE.Width;
            this.Height = this.databaseE.Height;

            this.isOnTool = true;
            this.isSelected = false;

            //Case new Generate diffrence Load from database
            this.ProcessBoolState(generateMode);


            //Set Size
            this.SetSizeImageForEPower(databaseE, imgList);

            // Vẽ ảnh lên control với kích thước mới
            //MessageBox.Show(this.ImageList.ImageSize + "");
            // Set Object Number
            this.pnlMain_Drawn.PanelMainMouse.ProcessSetNumberObjetEPower(this);

            this.GenerateDataLabelInfo();

            this.GenerateClassProcessChild();

            this.SetPHeadAndPtail();

        }

        protected virtual void ProcessBoolState(GenerateMode generateMode)
        {
            if (generateMode == GenerateMode.Instance)
            {
                this.isContainPhead = false;
                this.isContainPtail = false;
                this.containPreEpower = ContainPreEpower.NoContain;
                return;
            }

            this.isContainPhead = this.databaseE.IsContainPhead;
            this.isContainPtail = this.databaseE.IsContainPtail;
            this.containPreEpower = this.databaseE.ContainPreEpower;
        }

        protected virtual void SetSizeImageForEPower(DatabaseEPower databaseEPower, ImageList imgList)
        {
            int numberImage = databaseE.NumberImage;
            Image originalImage = imgList.Images[numberImage];

            // Tính toán tỉ lệ giữa kích thước control và kích thước ảnh gốc
            float ratioX = (float)this.Width / (float)originalImage.Width;
            float ratioY = (float)this.Height / (float)originalImage.Height;
            float ratio = Math.Min(ratioX, ratioY);

            this.UpdateScaleImage(originalImage, ratio);

        }

        public virtual void UpdateScaleImage(Image originalImage, float ratio)
        {
            // Tính toán kích thước ảnh mới
            int newWidth = (int)(originalImage.Width * ratio);
            int newHeight = (int)(originalImage.Height * ratio);

            Image resizedImage = originalImage.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero);

            this.Image = resizedImage;
        }
        protected virtual void GenerateClassProcessChild()
        {
            this._ePowerMouse = new EPowerProcessMouse(this);
            this._ePowerKey = new EPowerProcessKey(this);
            this._ePowerLineTemp = new EPowerProcessLineTemp(this);
        }

        protected virtual void GenerateDataLabelInfo()
        {
            this.lblInfo = new Label();
            this.lblInfo.Font = new Font("Sans-serif", 8, FontStyle.Regular);
            this.lblInfo.AutoSize = true;
            this.lblInfo.Visible = true;

            //Set data show on EPower
            this.SetDataLabelInfo();

            this.pnlMain_Drawn.Controls.Add(lblInfo);

            // Set Pos lbl
            this.UpdatePositonLabelInfo();

        }

        public virtual void SetDataLabelInfo()
        {
            lblInfo.Text = this.ToString();
            this.Name = this.ToString();
        }

        public virtual void UpdatePositonLabelInfo()
        {
            this.lblInfo.Location = new Point(this.Location.X - 120, this.Location.Y - 20);
        }

        public override string ToString()
        {
            ObjectType objType = this.databaseE.ObjectType;
            string objName = this.databaseE.ObjectName;
            int objNumber = this.databaseE.ObjectNumber;
            return objType + " " + objNumber + ", Name : " + objName;
        }

        public virtual void SetPHeadAndPtail()
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

        protected virtual void SetValueOldLocation(Point mouseLocation)
        {
            // Trong sự kiện MouseUp của ConnectionE
            Point screenPoint = this.PointToScreen(mouseLocation); // Chuyển đổi tọa độ chuột so với ConnectionE sang tọa độ trên màn hình
            Point panelCoords = this.pnlMain_Drawn.PointToClient(screenPoint); // Chuyển đổi tọa độ trên màn hình sang tọa độ trên panel chứa ConnectionE
            this._oldLocation = panelCoords; // Lưu trữ tọa độ của ConnectionE trên panel
           // MessageBox.Show("OldLocation = " + this._oldLocation);
        }

        #endregion Constructor_Class

        #region Drawn
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // it is on tool not flicker//nhấp nháy
            if (this.isOnTool) return;

            if (this.mouseEnter && !this.isMove)
            {
                this.nearPhead = this.IsOnNearPHead();
                Point pEnds = this.nearPhead ? this.pHead : this.pTail;
                bool contained = this.nearPhead ? this.isContainPhead : this.isContainPtail;

                if (contained && this.databaseE.ObjectType != ObjectType.Bus) pEnds = Point.Empty;

                if (this.databaseE.ObjectType == ObjectType.MF) pEnds = this.pHead;
                this.DrawCubePinkMouseNearEnds(e, pEnds);
            }
            //Drawn Read or remove color when press and not press => update 
            this.DrawRectangleAround(e);
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

            //After move update again postion of Epower
            this.SetValueOldLocation(e.Location);
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



        #endregion Function_Overall
    }
}

























