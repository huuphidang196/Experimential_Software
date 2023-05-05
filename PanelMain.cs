using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.CustomControl;
using Experimential_Software.DAO.DAO_ProcessDelete.DAO_DeleteLineConnect;

namespace Experimential_Software
{
    public partial class PanelMain : Panel
    {

        protected PanelMainMouse _pnlMainMouse;
        public PanelMainMouse PanelMainMouse => _pnlMainMouse;

        protected double _minZoom = Math.Pow((1 / 1.1), 6);

        protected double _maxZooom = Math.Pow(1.1, 6);

        protected double _zoomFactor;
        public double ZoomFactor { get => _zoomFactor; set => _zoomFactor = value; }

        public PanelMain()
        {
            InitializeComponent();
            this._pnlMainMouse = new PanelMainMouse(this);
            this.AutoScroll = true;
            if (this._zoomFactor == 0) this._zoomFactor = 1;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
           
            if (Control.ModifierKeys != Keys.Control) return;

            // Lấy vị trí con trỏ chuột trong control
            Point mouseLocation = e.Location;

            // Tính toán độ zoom hiện tại
            double zoomPer = e.Delta > 0 ? 1.1 : (1 / 1.1);  // e.Delta là giá trị của bánh xe chuột
            this._zoomFactor *= zoomPer;
            this._zoomFactor = Math.Round(this._zoomFactor, 9);

            this._zoomFactor = Math.Max(this._zoomFactor, this._minZoom);
            this._zoomFactor = Math.Min(this._zoomFactor, this._maxZooom);

            this._pnlMainMouse.FrmCapstone.lblLine.Text = "zoom = " + this._zoomFactor;

            if (this._zoomFactor == this._minZoom || this._zoomFactor == this._maxZooom) return;

            List<ConnectableE> EPowers = this.PanelMainMouse.FrmCapstone.EPowers;
            // Phóng to hoặc thu nhỏ các control trong panel
            foreach (ConnectableE ePower in EPowers)
            {
                this.SetNewSizeAndNewPostion(mouseLocation, ePower);
                ePower.EPowerProcessMouse.UpdateLineWhenMove();
            }
        }

        public virtual void SetNewSizeAndNewPostion(Point mouseLocation, ConnectableE ePower)
        {
            int oldX = ePower.PreLocation.X;
            int oldY = ePower.PreLocation.Y;

            int newX = (int)mouseLocation.X + (int)((oldX - (int)mouseLocation.X) * this._zoomFactor);
            int newY = (int)mouseLocation.Y + (int)((oldY - (int)mouseLocation.Y) * this._zoomFactor);

            // Set lại vị trí và kích thước của control
            ePower.Location = new Point(newX, newY);
            this.SetInsideEPower(ePower);
        }

        public virtual void SetInsideEPower(ConnectableE ePower)
        {
            // Tính toán vị trí và kích thước mới của control
            int newWidth = (int)(ePower.DatabaseE.Width * this._zoomFactor);
            int newHeight = (int)(ePower.DatabaseE.Height * this._zoomFactor);

            ePower.Size = new Size(newWidth, newHeight);
            ePower.BackgroundImageLayout = ImageLayout.Zoom;

            int numberImage = ePower.DatabaseE.NumberImage;
            Image originalImage = this._pnlMainMouse.FrmCapstone.imgListEPower.Images[numberImage];
            ePower.UpdateScaleImage(originalImage, (float)this._zoomFactor);

            ePower.LblInfoE.Font = new Font("Sans-serif", (int)(8 * this._zoomFactor), FontStyle.Regular);

            ePower.SetPHeadAndPtail();

            ePower.UpdatePositonLabelInfo();
        }

        #region Key  
        public virtual void ProcessDeleteLine(frmCapstone frmCapstone)
        {
            //Find Line is Seleted
            LineConnect lineSelected = frmCapstone.FindLineIsSelected();
            if (lineSelected == null) return;

            DAOProcessDeleteLineConnect.Instance.ClearOldLine(lineSelected, this);

            DAOProcessDeleteLineConnect.Instance.ProcessDeleteLineConnect(lineSelected);

            //=> hava line is selected => pressing delete key => remove lineconnect out list
            frmCapstone.RemoveLine(lineSelected);

            //Drawn all line
            frmCapstone.DrawAllLineOnPanel();
        }



        #endregion Key


        #region Function_Overall


        #endregion Function_Overall
    }
}

























//#region Mouse

////protected override void OnMouseClick(MouseEventArgs e)
////{
////    base.OnMouseClick(e);

////    //select line in Panel, set isSelected false for all btn
////    if (this._frmCap == null) this._frmCap = this.FindForm() as frmCapstone;

////    this._frmCap.SetIsSelectedEPower(null);

////    if (this._frmCap.LineConnectList.Count == 0) return;

////    //Process set isSelected and Color for Line
////    this._pnlMainMouse.ProcessMain_MouseClick(this._frmCap, e);

////    //find Line is Selected
////    LineConnect lineSeleted = this._pnlMainMouse.FindLineConnectIsSelected(this._frmCap);

////    //Set false
////    if (lineSeleted != null) this._pnlMainMouse.SetFalseSelectedOtherLine(lineSeleted, this._frmCap);

////}

//#endregion Mouse

//#region Drag
////protected override void OnDragEnter(DragEventArgs e)
////{
////    base.OnDragEnter(e);

////    e.Effect = DragDropEffects.Move;
////}

////protected override void OnDragDrop(DragEventArgs e)
////{
////    base.OnDragDrop(e);
////    if (this._frmCap == null) this._frmCap = this.FindForm() as frmCapstone;

////    // Get drop location and move button instance to that location
////    Point dropLocation = this.PointToClient(new Point(e.X, e.Y));
////    Control control = (Control)e.Data.GetData(typeof(ConnectableE));

////    if (this.ClientRectangle.Contains(dropLocation))
////    {
////        control.Location = dropLocation;
////        ConnectableE ePower = control as ConnectableE;

////        this._frmCap.AddEPower(ePower);
////        this._frmCap.AddIMouseOnEndsAfterDelete(ePower);
////        ePower.isOnTool = false;

////        this.Controls.Add(ePower);
////    }
////    else
////    {
////        this.Controls.Remove(control);
////        control.Dispose();
////    }
////}
//#endregion Drag
