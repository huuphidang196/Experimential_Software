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
    public partial class frmCapstone : Form
    {
        protected Point previousMouseLocation;
        protected bool isDragging = false;
        protected int countElement = 0;

        protected List<ConnectableE> ePowers = new List<ConnectableE>();
        public List<ConnectableE> EPowers => ePowers;

        private List<LineConnect> lineConnectList = new List<LineConnect>();
        public List<LineConnect> LineConnectList => lineConnectList;

        protected PanelMainMouse _pnlMainMouse;
        public PanelMainMouse PanelMainMouse => _pnlMainMouse;

        private List<IMouseOnEndsControl> iEPowers = new List<IMouseOnEndsControl>();
        public List<IMouseOnEndsControl> IEPowers1 => iEPowers;

        protected float penWidth; // độ rộng mong muốn

        public frmCapstone()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this._pnlMainMouse = new PanelMainMouse(this, pnlMain);
        }

        #region Reference_OutSide

        public virtual void AddLine(LineConnect lineConnect)
        {
            this.lineConnectList.Add(lineConnect);
            //Draw All Line
            this.DrawAllLineOnPanel();

        }

        public virtual void RemoveLine(LineConnect lineConnect)
        {
            this.lineConnectList.Remove(lineConnect);
            //Draw All Line
            this.DrawAllLineOnPanel();
        }

        public virtual void RemoveEPower(ConnectableE ePower)
        {
            this.ePowers.Remove(ePower);
            //Draw All Line
            this.DrawAllLineOnPanel();
        }

        public virtual void RemoveIMouseOnEndsAfterDelete(IMouseOnEndsControl mouseOnEnds)
        {
            this.iEPowers.Remove(mouseOnEnds);
        }

        public virtual void ShowPointConnect()
        {
            foreach (IMouseOnEndsControl ePower in this.iEPowers)
            {
                ePower.MouseMoveEnds();
            }
        }

        public virtual ConnectableE CheckEndLineIsOnEPower(Point endLinePoint)
        {
            if (endLinePoint == Point.Empty) return null;

            foreach (ConnectableE ePower in this.ePowers)
            {
                bool isOnPower = ePower.Bounds.Contains(endLinePoint);
                if (!isOnPower) continue;

                return ePower;
            }

            return null;
        }

        //Remove isselect another ConnectionE
        public virtual void SetIsSelected(ConnectableE ePower_Focused)
        {
            foreach (ConnectableE ePower in this.ePowers)
            {
                if (ePower != ePower_Focused) ePower.IsSelected = false;
            }

        }

        public virtual void SetIsContainEPower(LineConnect lineSelected)
        {
            ConnectableE startEPower = lineSelected.StartEPower;
            ConnectableE endEPower = lineSelected.EndEPower;

            if (this.IsPointOfHead(lineSelected, 0)) startEPower.IsContainPhead = false;
            startEPower.IsContainPtail = false;

            if (this.IsPointOfHead(lineSelected, 1)) endEPower.IsContainPhead = false;
            endEPower.IsContainPtail = false;

        }


        public virtual void DrawAllLineOnPanel()
        {
            //not Clear All => Clear then will have one line because all not added in list line 
            foreach (LineConnect line in this.lineConnectList)
            {
                Point startPoint = line.StartPoint;
                Point endPoint = line.EndPoint;

                pnlMain.CreateGraphics().DrawLine(Pens.Black, startPoint, endPoint);
            }
        }

        #endregion Reference_OutSide



        #region Control_On_Form
        protected void btnBusPower_MouseDown(object sender, MouseEventArgs e)
        {
            DatabaseEPower databaseE = new DatabaseEPower() { objectType = ObjectType.Bus, Width = 80, Height = 20 };
            this.ButtonMouseDown(sender, e, btnBusPower, databaseE);
        }

        protected void btnLinePower_MouseDown(object sender, MouseEventArgs e)
        {
            DatabaseEPower databaseE = new DatabaseEPower() { objectType = ObjectType.LineEPower, Width = 30, Height = 80 };
            this.ButtonMouseDown(sender, e, btnLinePower, databaseE);
        }

        protected void btnMFPower_MouseDown(object sender, MouseEventArgs e)
        {
            DatabaseEPower databaseE = new DatabaseEPower() { objectType = ObjectType.MF, Width = 50, Height = 50 };
            this.ButtonMouseDown(sender, e, btnMFPower, databaseE);
        }

        private void btnTransformer_MouseDown(object sender, MouseEventArgs e)
        {
            DatabaseEPower databaseE = new DatabaseEPower() { objectType = ObjectType.LineEPower, Width = 40, Height = 60 };
            this.ButtonMouseDown(sender, e, btnTransformer, databaseE);
        }

        private void btnLoad_MouseDown(object sender, MouseEventArgs e)
        {
            DatabaseEPower databaseE = new DatabaseEPower() { objectType = ObjectType.Load, Width = 50, Height = 50 };
            this.ButtonMouseDown(sender, e, btnLoad, databaseE);
        }

        /// <summary>
        /// Panel Main 

        private void pnlMain_MouseDown(object sender, MouseEventArgs e)
        {
            this.SetIsSelected(null);

            if (this.lineConnectList.Count == 0) return;
            //Determine Line is selected
            bool isContainLine = this._pnlMainMouse.ProcessMain_MouseClick(e);

            if (isContainLine) this.SetIsSelected(null);//select line in Panel, set isSelected false for all btn

        }


        protected virtual bool IsPointOfHead(LineConnect lineSelected, int numberEnds)
        {
            PointOfEnds internPointEPower = numberEnds == 0 ? lineSelected.StartPointEPower : lineSelected.EndPointEPower;
            bool isContainHead = internPointEPower == PointOfEnds.PointOfHead ? true : false;

            return isContainHead;
        }

        private void pnlMain_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void pnlMain_DragDrop(object sender, DragEventArgs e)
        {
            // Get drop location and move button instance to that location
            Point dropLocation = pnlMain.PointToClient(new Point(e.X, e.Y));
            Control control = (Control)e.Data.GetData(typeof(ConnectableE));

            if (pnlMain.ClientRectangle.Contains(dropLocation))
            {
                control.Location = dropLocation;
                ConnectableE ePower = control as ConnectableE;
                this.ePowers.Add(ePower);
                this.iEPowers.Add(ePower);
                ePower.isOnTool = false;
            }
            else
            {
                pnlMain.Controls.Remove(control);
                control.Dispose();
            }
        }
        /// Panel Main

        #endregion Control_On_Form

        protected virtual void ButtonMouseDown(object sender, MouseEventArgs e, ConnectableE btnTool, DatabaseEPower databaseE)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Create instance of button1 and start drag-and-drop operation
                ConnectableE ctrlInstance = new ConnectableE(this, pnlMain, databaseE);
                countElement++;
                ctrlInstance.Name = btnTool.Name + "_" + this.countElement;
                ctrlInstance.Text = btnTool.Text + "_" + this.countElement;
                ctrlInstance.Location = btnTool.Location;

                ctrlInstance.DoDragDrop(ctrlInstance, DragDropEffects.Move);
                pnlMain.Controls.Add(ctrlInstance);
                ctrlInstance.BringToFront();

            }
        }


        private void frmCapstone_KeyDown(object sender, KeyEventArgs e)
        {
            //LineConnect lineSelected = this.processPowerConn.FindLineConnectIsSelected(this.lineConnectList);
            //if (lineSelected == null) return;

            //if (e.KeyCode != Keys.Delete) return;
            ////Determine ConnectionE connect with line => set iscontainPHead or Tail
            //this.SetIsContainEPower(lineSelected);
            ////=> hava line is selected => pressing delete key => remove lineconnect out list
            //this.lineConnectList.Remove(lineSelected);
            ////Drawn all line
            //this.DrawAllLineOnPanel();

        }

        
    }
}
































//#region ButtonInstance

//protected virtual void ButtonInstance_MouseDown(object sender, MouseEventArgs e)
//{
//    this.isDragging = this._processPowerConn.IsDragging;
//    this.previousMouseLocation = this._processPowerConn.PreviousMouseLocation;
//    this._processPowerConn.ButtonInstance_MouseDown(sender, e, pnlMain);
//    this.SetIsSelected(sender as ConnectableE);
//    this._processPowerConn.SetFalseSelectedALLLine(this.LineConnectList);
//}

//protected virtual void ButtonInstance_MouseMove(object sender, MouseEventArgs e)
//{
//    this._processPowerConn.ButtonInstance_MouseMove(sender, e, pnlMain);

//}

//protected virtual void ButtonInstance_MouseUp(object sender, MouseEventArgs e)
//{ 
//    this._processPowerConn.ButtonInstance_MouseUp(sender, e, pnlMain);

//    this.isDragging = _processPowerConn.IsDragging;
//}


//#endregion ButtonInstance





//private void ButtonInstance_MouseDown(object sender, MouseEventArgs e)
//{
//    if (e.Button == MouseButtons.Left)
//    {
//        isDragging = true;
//        previousMouseLocation = e.Location;
//    }
//}

//private void ButtonInstance_MouseMove(object sender, MouseEventArgs e)
//{
//    if (!isDragging) return;

//    //Control is moved
//    Button button1Instance = sender as Button;

//    Point pMouseTopnlMain = this.TransferPosMouseToControl(sender, e, pnlMain);

//    bool isOnMain = pnlMain.ClientRectangle.Contains(pMouseTopnlMain);

//    if (!isOnMain) return;

//    button1Instance.Location = pMouseTopnlMain;
//}

//private void ButtonInstance_MouseUp(object sender, MouseEventArgs e)
//{

//    if (e.Button == MouseButtons.Right) return;

//    Button button1Instance = sender as Button;
//    isDragging = false;

//    Point pMouseTopnlMain = this.TransferPosMouseToControl(sender, e, pnlMain);

//    bool isOnMain = pnlMain.ClientRectangle.Contains(pMouseTopnlMain);

//    if (!isOnMain)
//    {
//        button1Instance.Location = previousMouseLocation;
//        return;
//    }

//    button1Instance.Location = pMouseTopnlMain;
//}

////Trả về vị vị điểm 
//protected virtual Point TransferPosMouseToControl(object sender, MouseEventArgs e, object ControlDes)
//{
//    //Control is moved
//    Button button1Instance = sender as Button;

//    //Get pos center of button Instance in order to smoothly move
//    Point posCenter = new Point(e.Location.X - button1Instance.Width / 2, e.Location.Y - button1Instance.Height / 2);
//    //=> transfer Location to screen
//    Point dropToScreen = button1Instance.PointToScreen(posCenter);

//    Control ctrlDes = ControlDes as Control;
//    //=> transfer posMouse to Control Destionation
//    Point pMouseTopnlMain = ctrlDes.PointToClient(dropToScreen);

//    return pMouseTopnlMain;
//}






