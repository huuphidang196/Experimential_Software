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
        public List<LineConnect> ListBranch_Drawn => _listBranch_Drawn;

        //Use for Proccessing Zoom
        protected Point _oldLocation;
        public Point OldLocation { get => _oldLocation; set => _oldLocation = value; }


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
                this.containPreEpower = ContainPreEpower.NoContain;
                return;
            }

            this.isContainPhead = this._databaseE.IsContainPhead;
            this.isContainPtail = this._databaseE.IsContainPtail;
            this.containPreEpower = this._databaseE.ContainPreEpower;
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
            //MF
            if (this._databaseE.ObjectType == ObjectType.MF)
            {
                this.pHead = new Point(Width / 2, Height - 4);
                this.pTail = Point.Empty;
                this.isContainPtail = true;
                return;
            }

            //Load
            if (this._databaseE.ObjectType == ObjectType.Load)
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

            if (this.mouseEnter && !this.isMove)
            {
                this.nearPhead = this.IsOnNearPHead();
                Point pEnds = this.nearPhead ? this.pHead : this.pTail;
                bool contained = this.nearPhead ? this.isContainPhead : this.isContainPtail;

                if (contained && this._databaseE.ObjectType != ObjectType.Bus) pEnds = Point.Empty;

                if (this._databaseE.ObjectType == ObjectType.MF) pEnds = this.pHead;
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

            if (e.Button == MouseButtons.Right) return;

            if (this._ePowerMouse == null) return;

            //=> Check if ko move trước đó thì ko set Pos  

            this._ePowerMouse.ButtonInstance_MouseUp(e);
            this.isMove = false;
           // MessageBox.Show(this.ToString() + ", Count = " + this._listBranch_Drawn.Count);
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
            if (ePoint.Y < this.pHead.Y - 10 && !this.isOnTool && this._databaseE.ObjectType == ObjectType.MF) return false;
            if (ePoint.Y > this.pHead.Y + 10 && this.Width <= this.Height) return false;

            return true;
        }


        public virtual bool IsOnPTail(Point ePoint)
        {
            if (ePoint.X < this.pTail.X - 10 && this.Width > this.Height) return false;
            if (!this.isOnTool && this._databaseE.ObjectType == ObjectType.MF) return false;
            if (!this.isOnTool && this._databaseE.ObjectType == ObjectType.Load) return false;
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

        #region Refercen_OutSide
        public virtual void UpdateDataRecordEPowerWhenConnect(bool isRemoved)
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
                        //Update DataDTO bus After Connect 
                        DAOUpdateMBA2AfterConnectEnds.Instance.UpdateMBA2AfterConnectEnds(this, isRemoved);
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

























