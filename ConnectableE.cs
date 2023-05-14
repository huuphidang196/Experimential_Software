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
using Experimential_Software.CustomControl;
using Experimential_Software.DAO.DAO_GeneratorData;
using Experimential_Software.DAO.DAO_MBA2Data;
using Experimential_Software.DAO.DAO_LineData;
using Experimential_Software.DAO.DAO_LoadData;

namespace Experimential_Software
{
    [Serializable]
    public enum ContainPreEpower
    {
        NoContain = 0,

        ContainPhead = 1,
        ContainPTail = 2,

        ContainPIntern = 3,
    }

    [Serializable]
    public enum ObjectType
    {
        NoType = 0,

        Bus = 1,
        MF = 2,
        MBA2P = 3,
        MBA3P = 4,
        LineEPower = 5,
        Load = 6,
    }


    [Serializable]
    public enum ObjectOrientation
    {
        NoType = 0,

        Horizontal = 1001,
        Verical = 1002,
    }

    [Serializable]
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


        protected DatabaseEPower _databaseE;
        public DatabaseEPower DatabaseE => _databaseE;

        protected EPowerProcessMouse _ePowerMouse;
        public EPowerProcessMouse EPowerProcessMouse => _ePowerMouse;

        protected EPowerProcessLineTemp _ePowerLineTemp;
        public EPowerProcessLineTemp EPowerLineTemp => _ePowerLineTemp;

        protected EPowerProcessKey _ePowerKey;

        protected Label lblInfo;
        public Label LblInfoE { get => lblInfo; set => lblInfo = value; }


        //List LineConnected with this EPower
        protected List<LineConnect> _listBranch_Drawn;
        public List<LineConnect> ListBranch_Drawn { get => _listBranch_Drawn; set => _listBranch_Drawn = value; }

        //Use for Proccessing Zoom
        protected Point _preLocation;
        public Point PreLocation { get => _preLocation; set => _preLocation = value; }


        //if GenerateMode = Instance => Open frm Record
        protected GenerateMode _generateMode;
        public GenerateMode GenerateModeE => _generateMode;

        protected bool isOnTool;
        public bool IsOnTool { get => isOnTool; set => isOnTool = value; }

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

        protected int _radiusPoint = 7;

        protected Point pHead;
        protected Point pTail;
        protected Point pIntern = Point.Empty;//mba3p
        public Point PHead
        {
            get { return pHead; }
            set
            {
                pHead = value;
            }
        }
        public Point PTail
        {
            get { return pTail; }
            set
            {
                pTail = value;
            }
        }

        public Point PIntern// only apply for MBA3p
        {
            get { return pIntern; }
            set
            {
                pIntern = value;
            }
        }

        protected bool isContainPhead;
        public bool IsContainPhead { get => isContainPhead; set => isContainPhead = value; }

        protected bool isContainPtail;
        public bool IsContainPtail { get => isContainPtail; set => isContainPtail = value; }

        protected bool isContainPIntern;
        public bool IsContainPIntern { get => isContainPIntern; set => isContainPIntern = value; }

        public ContainPreEpower ContainPreEpower { get; set; }

        protected bool isPHead = false;
        protected bool isPtail = false;
        protected bool isPIntern = false;

        protected bool nearPhead = false;
        public bool NearPHead => nearPhead;

        protected bool nearIntern = false;
        public bool NearPIntern => nearIntern;

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

            //if GenerateMode = Instance => Open frm Record
            this._generateMode = generateMode;
            //Set variable
            this.SetVariableOnEPower(databaseEPower, imgList);

        }

        protected virtual void SetVariableOnEPower(DatabaseEPower databaseEPower, ImageList imgList)
        {
            this._databaseE = databaseEPower;

            this.Width = this._databaseE.Width;
            this.Height = this._databaseE.Height;

            this.isOnTool = true;
            this.isSelected = false;

            if (this._databaseE.ObjectType != ObjectType.MBA3P)
            {
                this.pIntern = Point.Empty;
                this.isContainPIntern = true;
            }
            //Case new Generate diffrence Load from database
            this.ProcessBoolState();

            //Set Size
            this.SetSizeImageForEPower(_databaseE, imgList);

            //Generate new Line
            this._listBranch_Drawn = new List<LineConnect>();

            this.GenerateDataLabelInfo();

            this.GenerateClassProcessChild();

            this.SetPHeadAndPtail();

        }

        protected virtual void ProcessBoolState()
        {
            if (this._generateMode == GenerateMode.Instance)
            {
                this.isContainPhead = false;
                this.isContainPtail = false;
                this.ContainPreEpower = ContainPreEpower.NoContain;
                return;
            }

            this.isContainPhead = this._databaseE.IsContainPhead;
            this.isContainPtail = this._databaseE.IsContainPtail;
            this.ContainPreEpower = this._databaseE.ContainPreEpower;
        }

        protected virtual void SetSizeImageForEPower(DatabaseEPower databaseEPower, ImageList imgList)
        {
            int numberImage = _databaseE.NumberImage;
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

            if (this._databaseE.ObjectOri == ObjectOrientation.Verical && this._databaseE.ObjectType != ObjectType.Bus) return;

            if (this._databaseE.ObjectType != ObjectType.Load)
            {
                this.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                return;
            }

            this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
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
            ObjectType objType = this._databaseE.ObjectType;
            string objName = "";
            int objNumber = 1;

            switch (objType)
            {
                case ObjectType.Bus:
                    {
                        objName = this._databaseE.DataRecordE.DTOBusEPower.ObjectName;
                        objNumber = this._databaseE.DataRecordE.DTOBusEPower.ObjectNumber;
                    }
                    break;
                case ObjectType.MF:
                    {
                        objName = this._databaseE.DataRecordE.DTOGeneEPower.ObjectName;
                        objNumber = this._databaseE.DataRecordE.DTOGeneEPower.ObjectNumber;
                    }
                    break;
                case ObjectType.MBA2P:
                    {
                        objName = this._databaseE.DataRecordE.DTOTransTwoEPower.ObjectName;
                        objNumber = this._databaseE.DataRecordE.DTOTransTwoEPower.ObjectNumber;
                    }
                    break;
                case ObjectType.MBA3P:
                    {
                        objName = this._databaseE.DataRecordE.DTOTransThreeEPower.ObjectName;
                        objNumber = this._databaseE.DataRecordE.DTOTransThreeEPower.ObjectNumber;
                    }
                    break;
                case ObjectType.LineEPower:
                    {
                        objName = this._databaseE.DataRecordE.DTOLineEPower.ObjectName;
                        objNumber = this._databaseE.DataRecordE.DTOLineEPower.ObjectNumber;
                    }
                    break;
                case ObjectType.Load:
                    {
                        objName = this._databaseE.DataRecordE.DTOLoadEPower.ObjectName;
                        objNumber = this._databaseE.DataRecordE.DTOLoadEPower.ObjectNumber;
                    }
                    break;
            }

            return objType + " " + objNumber + ", Name : " + objName;
        }

        public virtual void SetPHeadAndPtail()
        {

            ObjectType objType = this._databaseE.ObjectType;
            switch (objType)
            {
                case ObjectType.NoType:
                    break;

                case ObjectType.Bus:
                    {
                        //=> Bus
                        if (this._databaseE.ObjectOri == ObjectOrientation.Horizontal)
                        {
                            this.pHead = new Point(Width / 2 - Width / 4, Height / 2);
                            this.pTail = new Point(Width / 2 + Width / 4, Height / 2);
                            return;
                        }
                        this.pHead = new Point(Width / 2, Height / 2 - Height / 4);
                        this.pTail = new Point(Width / 2, Height / 2 + Height / 4);
                    }
                    break;
                case ObjectType.MF:
                    {
                        //MF
                        this.pTail = Point.Empty;
                        this.isContainPtail = true;

                        if (this._databaseE.ObjectOri == ObjectOrientation.Horizontal)
                        {
                            this.pHead = new Point(Width, Height / 2);
                            return;
                        }

                        this.pHead = new Point(Width / 2, Height - 4);
                    }
                    break;
                case ObjectType.MBA2P:
                case ObjectType.LineEPower:
                    {
                        //Circle => MBA, Line Width > Height
                        if (this._databaseE.ObjectOri == ObjectOrientation.Horizontal)
                        {
                            this.pHead = new Point(0, Height / 2);
                            this.pTail = new Point(Width, Height / 2); //oy Top to Down
                            return;
                        }
                        this.pHead = new Point(Width / 2, 0);
                        this.pTail = new Point(Width / 2, Height); //oy Top to Down
                    }
                    break;
                case ObjectType.MBA3P:
                    {
                        //Circle => MBA, Line Width > Height
                        if (this._databaseE.ObjectOri == ObjectOrientation.Horizontal)
                        {
                            this.pHead = new Point(0, Height / 2);
                            this.pTail = new Point(Width, Height / 2); //oy Top to Down

                            this.pIntern = new Point(Width / 2, 0);//
                            return;
                        }
                        this.pHead = new Point(Width / 2, 0);
                        this.pTail = new Point(Width / 2, Height); //oy Top to Down

                        this.pIntern = new Point(Width, Height / 2);//I-
                    }
                    break;
                case ObjectType.Load:
                    {
                        //Load
                        this.pTail = Point.Empty;
                        this.isContainPtail = true;

                        if (this._databaseE.ObjectOri == ObjectOrientation.Horizontal)
                        {
                            this.pHead = new Point(Width, Height / 2);//->
                            return;
                        }
                        this.pHead = new Point(Width / 2, 0);//-.-
                    }
                    break;
            }
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

            if (!this.mouseEnter || this.isMove) return;

            if (this._databaseE.ObjectType != ObjectType.MBA3P) this.ProcessOnPaintDifferenceMBA3P(e);
            else this.ProcessOnPaintMBA3P(e);
        }

        protected virtual void ProcessOnPaintDifferenceMBA3P(PaintEventArgs e)
        {
            this.nearPhead = this.IsOnNearPHead();
            Point pEnds = this.nearPhead ? this.pHead : this.pTail;
            bool contained = this.nearPhead ? this.isContainPhead : this.isContainPtail;

            // if (contained && this._databaseE.ObjectType != ObjectType.Bus) pEnds = Point.Empty;
            if (contained && this._databaseE.ObjectType != ObjectType.Bus) return;

            if (this._databaseE.ObjectType == ObjectType.MF || this._databaseE.ObjectType == ObjectType.Load) pEnds = this.pHead;
            this.DrawCubePinkMouseNearEnds(e, pEnds);
        }

        protected virtual void ProcessOnPaintMBA3P(PaintEventArgs e)
        {
            Point pEnds;
            bool contained;

            if (this.nearPhead)
            {
                pEnds = this.pHead;
                contained = this.isContainPhead;
            }
            else if (this.nearIntern)
            {
                pEnds = this.pIntern;
                contained = this.isContainPIntern;
            }
            else
            {
                pEnds = this.pTail;
                contained = this.isContainPtail;
            }

            if (contained) return;

            this.DrawCubePinkMouseNearEnds(e, pEnds);
        }


        protected virtual void DrawCubePinkMouseNearEnds(PaintEventArgs e, Point pEnds)
        {
            if (pEnds == Point.Empty) return;

            using (var pen = new Pen(Color.Pink, 3))
            {
                Rectangle rectEnds;
                if (this._databaseE.ObjectType != ObjectType.MBA3P) rectEnds = this.GetRectangleDiffMBA3P(pEnds);
                else rectEnds = this.GetRectangleMBA3P(pEnds);

                e.Graphics.DrawRectangle(pen, rectEnds);
                e.Graphics.FillRectangle(Brushes.Pink, rectEnds);
                //   MessageBox.Show("Phead = " + this.PHead + ", Ptail = " + this.pTail + ", pIntern = " + this.pIntern);
            }

        }

        protected virtual Rectangle GetRectangleDiffMBA3P(Point pEnds)
        {
            //Get value interact with radius variable
            int Point_Oxy = this.Width > this.Height ? pEnds.X : pEnds.Y;

            int PointDrawn = this.nearPhead ? Point_Oxy : Point_Oxy - this._radiusPoint;

            var rectWBigH = new Rectangle(PointDrawn, (Height - this._radiusPoint) / 2, this._radiusPoint, this._radiusPoint);
            var rectWLessH = new Rectangle((Width - this._radiusPoint) / 2, PointDrawn, this._radiusPoint, this._radiusPoint);
            if (this._databaseE.ObjectOri == ObjectOrientation.Horizontal)
            {
                int k_Compen = this.nearPhead ? 0 : -1 * this._radiusPoint;
                rectWLessH = new Rectangle(pEnds.X + k_Compen, pEnds.Y - this._radiusPoint / 2, this._radiusPoint, this._radiusPoint);
            }
            var rectEnds = this.Width > this.Height ? rectWBigH : rectWLessH;

            return rectEnds;
        }

        protected virtual Rectangle GetRectangleMBA3P(Point pEnds)
        {
            int Point_Oxy, PointDrawn;
            //Get value interact with radius variable
            if (this._databaseE.ObjectOri == ObjectOrientation.Horizontal)
            {
                //Get value interact with radius variable
                Point_Oxy = pEnds == this.pIntern ? pEnds.Y : pEnds.X;//y == x
                if (pEnds == pIntern) PointDrawn = Point_Oxy;
                else PointDrawn = pEnds == this.pHead ? Point_Oxy : Point_Oxy - this._radiusPoint;

                //  MessageBox.Show("PointDrawn = " + PointDrawn);

                var rectEnds_Hor = (pEnds == this.pIntern) ? new Rectangle((Width - this._radiusPoint) / 2, PointDrawn, this._radiusPoint, this._radiusPoint)
                : new Rectangle(PointDrawn, (Height - this._radiusPoint) / 2, this._radiusPoint, this._radiusPoint);
                return rectEnds_Hor;
            }

            //Get value interact with radius variable
            Point_Oxy = pEnds == this.pIntern ? pEnds.X : pEnds.Y;//y == x
            PointDrawn = pEnds == this.pHead ? Point_Oxy : Point_Oxy - this._radiusPoint;

            var rectEnds_Ver = (pEnds == this.pIntern) ? new Rectangle(PointDrawn, (Height - this._radiusPoint) / 2, this._radiusPoint, this._radiusPoint)
            : new Rectangle((Width - this._radiusPoint) / 2, PointDrawn, this._radiusPoint, this._radiusPoint);
            return rectEnds_Ver;

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

            this.isMove = !this.IsConection(e.Location);

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

            if (this.isOnTool) return;

            if (this._ePowerMouse == null) return;

            this.mouseEnter = true;

            this._ePowerMouse.ButtonInstance_MouseMove(e);
            // Set Pos lbl
            this.UpdatePositonLabelInfo();

            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Right)
            {
                //Open ContextMenuStrip
                this.ShowContextMenuOfEPower();
                return;
            }
            if (this._ePowerMouse == null) return;

            //=> Check if ko move trước đó thì ko set Pos  

            this._ePowerMouse.ButtonInstance_MouseUp(e);
            this.isMove = false;

        }

        protected virtual void ShowContextMenuOfEPower()
        {
            if (!this.isSelected) return;

            if (this.DatabaseE.ObjectType != ObjectType.Bus)
            {
                MessageBox.Show("Please Click Bus connect with Load !");
                return;
            }

            this.ContextMenuStrip = this._formCap.cxtMenuStripEPower;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!this.isOnTool && this._databaseE.ObjectType == ObjectType.MBA3P) this.SetIsOnNearAnyPEnds();
            this.mouseEnter = true;
            Invalidate();
        }


        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.mouseEnter = false;
            Invalidate();
        }


        public virtual void OpenDataRecordForm()
        {
            //When ePower is not on Panel Main => element new => frm
            this._ePowerMouse.ShowDataRecordForEPower(this);
        }

        #endregion Mouse

        //if this is generated incorrect then remove it
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            //if not invalid generate => destroy
            // if it on tool and is not generated => haven't database then not destroy
            if (this.isOnTool && this._databaseE != null) this.Dispose();
        }


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

        public virtual bool IsConection(Point ePoint)
        {
            ObjectType objType = this._databaseE.ObjectType;
            this.isPHead = this.IsOnPHead(ePoint);
            this.isPtail = this.IsOnPTail(ePoint);

            //MBA3
            if (objType == ObjectType.MBA3P) this.isPIntern = this.IsOnPIntern(ePoint);

            if (!this.isPHead && !this.isPtail && objType != ObjectType.MBA3P) return false;

            if (!this.isPHead && !this.isPtail && !this.isPIntern && objType == ObjectType.MBA3P) return false;

            return true;
        }

        public virtual bool IsOnPHead(Point ePoint)
        {
            return this.IsContainEnds(ePoint, 0);
        }


        public virtual bool IsOnPTail(Point ePoint)
        {
            return this.IsContainEnds(ePoint, 1);
        }

        public virtual bool IsOnPIntern(Point ePoint)
        {
            return this.IsContainEnds(ePoint, 2);
        }

        protected virtual bool IsContainEnds(Point ePoint, int numEnds)
        {
            //Phead = 0, pTail = 1, pIntern = 2
            Point pointEnds = this.pIntern;

            if (numEnds == 0) pointEnds = this.pHead;
            else if (numEnds == 1) pointEnds = this.pTail;

            double distance = Math.Sqrt(Math.Pow(ePoint.X - pointEnds.X, 2) + Math.Pow(ePoint.Y - pointEnds.Y, 2));

            if (distance < 10) return true;

            return false;
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
        public virtual void SetIsOnNearAnyPEnds()
        {
            Point pointHeadtoScreen = this.PointToScreen(this.pHead);
            Point pointTailtoScreen = this.PointToScreen(this.pTail);
            Point pointInterntoScreen = this.PointToScreen(this.pIntern);

            double distanceHead = this.Distance(pointHeadtoScreen);
            double distanceTail = this.Distance(pointTailtoScreen);
            double distanceIntern = this.Distance(pointInterntoScreen);

            double minDis = Math.Min(Math.Min(distanceHead, distanceTail), distanceIntern);

            if (minDis == distanceIntern)
            {
                this.nearIntern = true;
                this.nearPhead = false;
                return;
            }
            else if (minDis == distanceHead)
            {
                this.nearPhead = true;
                this.nearIntern = false;
            }
            else//pTail
            {
                this.nearPhead = false;
                this.nearIntern = false;
            }
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

        #region Refercen_OutSide
        public virtual void UpdateDataRecordEPowerWhenConnectOrRemove(bool isRemoved)
        {
            //Except Bus
            ObjectType objType = this._databaseE.ObjectType;
            switch (objType)
            {
                case ObjectType.MF: // 2
                    {
                        //Update DataDTO bus After Connect 
                        DAOUpdateMFAfterConnectBus.Instance.UpdateMFAfterConnectEnds(this);
                    }
                    break;
                case ObjectType.MBA2P: // 3
                    {
                        //Update DataDTO MBA2P After Connect 
                        DAOUpdateMBA2AfterConnectEnds.Instance.UpdateMBA2AfterConnectEnds(this, isRemoved);
                    }
                    break;
                case ObjectType.MBA3P: // 4
                    {
                        //Update DataDTO MBA3p After Connect 
                      
                    }
                    break;
                case ObjectType.LineEPower: // 5
                    {
                        //Update DataDTO bus After Connect 
                        DAOUpdateLineAfterConnectEnds.Instance.UpdateLineAfterConnectEnds(this, isRemoved);
                    }
                    break;
                case ObjectType.Load://6
                    {
                        //Update DataDTO bus After Connect 
                        DAOUpdateLoadAfterConnectBus.Instance.UpDateLoadRecordAfterConnectBus(this);
                    }
                    break;
            }
        }
        //Add when Drawn line Mouse up Success!
        public virtual void AddLineConnectedToList(LineConnect lineConnect)
        {
            this._listBranch_Drawn.Add(lineConnect);
        }

        public virtual void RemoveLineConnectedToList(LineConnect lineConnect)
        {
            this._listBranch_Drawn.Remove(lineConnect);
        }
        #endregion Reference_OutSide
    }
}








//Not Remove*******************


/// <summary>
/// Don't remove isOntool beacause objectype isn't set
/// </summary>
/// <param name=" this.databaseE.objectType == ObjectType.MF"></param>
/// <returns></returns>
//public virtual bool IsOnPHead(Point ePoint)
//{
//    if (ePoint.X > this.pHead.X + 10 && this.Width > this.Height) return false;
//    if (ePoint.Y < this.pHead.Y - 10 && !this.isOnTool && this._databaseE.ObjectType == ObjectType.MF) return false;
//    if (ePoint.Y > this.pHead.Y + 10 && this.Width <= this.Height) return false;

//    return true;
//}

//public virtual bool IsOnPTail(Point ePoint)
//{
//    if (ePoint.X < this.pTail.X - 10 && this.Width > this.Height) return false;
//    if (!this.isOnTool && this._databaseE.ObjectType == ObjectType.MF) return false;
//    if (!this.isOnTool && this._databaseE.ObjectType == ObjectType.Load) return false;
//    if (ePoint.Y < this.pTail.Y - 10 && this.Width <= this.Height) return false;

//    return true;
//}















