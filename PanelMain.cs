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

        public PanelMain()
        {
            InitializeComponent();
            this._pnlMainMouse = new PanelMainMouse(this);
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
