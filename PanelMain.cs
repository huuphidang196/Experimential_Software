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

namespace Experimential_Software
{
    public partial class PanelMain : Panel
    {
        protected PanelMainMouse _pnlMainMouse;
        public PanelMainMouse PanelMainMouse => _pnlMainMouse;

        protected double _minZoom = Math.Pow(1 / 1.1, 6);

        protected double _maxZooom = Math.Pow(1.1, 10);

        protected double _zoomFactor = 1;
        public double ZoomFactor => _zoomFactor;

        public PanelMain()
        {
            InitializeComponent();
            this._pnlMainMouse = new PanelMainMouse(this);
        }



        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (Control.ModifierKeys != Keys.Control)
            {
                this.AutoScroll = true;
                return;
            }

            this.AutoScroll = false;
            // Lấy vị trí con trỏ chuột trong control
            Point mouseLocation = e.Location;

            // Tính toán độ zoom hiện tại
            double zoomPer = e.Delta > 0 ? 1.1 : 1 / 1.1;  // e.Delta là giá trị của bánh xe chuột
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
            //int oldX = this.OldLocationsEPowers[ePower.ToString()].X;
            //int oldY = this.OldLocationsEPowers[ePower.ToString()].Y;

            int oldX = ePower.OldLocation.X;
            int oldY = ePower.OldLocation.Y;

            int newX = (int)mouseLocation.X + (int)((oldX - (int)mouseLocation.X) * this._zoomFactor);
            int newY = (int)mouseLocation.Y + (int)((oldY - (int)mouseLocation.Y) * this._zoomFactor);

            newX = Math.Max(newX, 1 + newX);
            newY = Math.Max(newY, 1 + newY);

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

        public virtual void ProcessDeleteLine(frmCapstone frmCapstone, KeyEventArgs e)
        {
            //Find Line is Seleted
            LineConnect lineSelected = frmCapstone.FindLineIsSelected();
            if (lineSelected == null) return;


            if (e.KeyCode != Keys.Delete) return;

            //Determine ConnectionE connect with line => set iscontainPHead or Tail
            frmCapstone.SetIsContainEPower(lineSelected);

            //=> hava line is selected => pressing delete key => remove lineconnect out list
            frmCapstone.LineConnectList.Remove(lineSelected);

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
