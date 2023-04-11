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

        // protected PanelMain pnlMainDrawn;

        protected List<ConnectableE> ePowers = new List<ConnectableE>();
        public List<ConnectableE> EPowers => ePowers;

        private List<LineConnect> lineConnectList = new List<LineConnect>();
        public List<LineConnect> LineConnectList => lineConnectList;


        private List<IMouseOnEndsControl> iEPowers = new List<IMouseOnEndsControl>();
        public List<IMouseOnEndsControl> IEPowers => iEPowers;

        protected float penWidth; // độ rộng mong muốn

        public frmCapstone()
        {
            InitializeComponent();
            // this.pnlMain = new PanelMain(this); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // fix form không thể thu nhỏ hoặc phóng to
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.MaximumSize = this.Size; // giới hạn kích thước lớn nhất bằng kích thước hiện tại
            this.MinimumSize = this.Size; // giới hạn kích thước nhỏ nhất bằng kích thước hiện tại
                                          //Experimental by Form Data Bus. After set again
          
        }


        private void frmCapstone_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized; // set window state to normal
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

        public virtual void AddEPower(ConnectableE ePower)
        {
            this.ePowers.Add(ePower);
        }

        public virtual void RemoveEPower(ConnectableE ePower)
        {
            this.ePowers.Remove(ePower);
            //Draw All Line
            this.DrawAllLineOnPanel();
        }

        public virtual void AddIMouseOnEndsAfterDelete(IMouseOnEndsControl mouseOnEnds)
        {
            this.iEPowers.Add(mouseOnEnds);
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
        public virtual void SetIsSelectedEPower(ConnectableE ePower_Focused)
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

        protected virtual bool IsPointOfHead(LineConnect lineSelected, int numberEnds)
        {
            PointOfEnds internPointEPower = numberEnds == 0 ? lineSelected.StartPointEPower : lineSelected.EndPointEPower;
            bool isContainHead = internPointEPower == PointOfEnds.PointOfHead ? true : false;

            return isContainHead;
        }

        public virtual LineConnect FindLineIsSelected()
        {
            foreach (LineConnect lineConnect in this.lineConnectList)
            {
                if (lineConnect.IsSelected) return lineConnect;
            }

            return null;
        }
        #endregion Reference_OutSide



        #region Control_On_Form
        protected void btnBusPower_MouseDown(object sender, MouseEventArgs e)
        {
            DatabaseEPower databaseE = new DatabaseEPower() { ObjectType = ObjectType.Bus, Width = 100, Height = 30 };
            this.ButtonMouseDown(sender, e, btnBusPower, databaseE);
        }

        protected void btnLinePower_MouseDown(object sender, MouseEventArgs e)
        {
            DatabaseEPower databaseE = new DatabaseEPower() { ObjectType = ObjectType.LineEPower, Width = 16, Height = 64 };
            this.ButtonMouseDown(sender, e, btnLinePower, databaseE);
        }

        protected void btnMFPower_MouseDown(object sender, MouseEventArgs e)
        {
            DatabaseEPower databaseE = new DatabaseEPower() { ObjectType = ObjectType.MF, Width = 40, Height = 40 };
            this.ButtonMouseDown(sender, e, btnMFPower, databaseE);
        }

        private void btnTransformer_MouseDown(object sender, MouseEventArgs e)
        {
            DatabaseEPower databaseE = new DatabaseEPower() { ObjectType = ObjectType.MBA, Width = 40, Height = 40 };
            this.ButtonMouseDown(sender, e, btnTransformer, databaseE);
        }

        private void btnLoad_MouseDown(object sender, MouseEventArgs e)
        {
            DatabaseEPower databaseE = new DatabaseEPower() { ObjectType = ObjectType.Load, Width = 40, Height = 40 };
            this.ButtonMouseDown(sender, e, btnLoad, databaseE);
        }


        //Panel Main
        private void pnlMain_MouseDown(object sender, MouseEventArgs e)
        {
            //select line in Panel, set isSelected false for all btn
            this.SetIsSelectedEPower(null);

            if (this.lineConnectList.Count == 0) return;

            //Process set isSelected and Color for Line
            this.pnlMain.PanelMainMouse.ProcessMain_MouseCDown(this.lineConnectList, e);

            //find Line is Selected
            LineConnect lineSeleted = pnlMain.PanelMainMouse.FindLineConnectIsSelected(this.lineConnectList);

            //Set false
            if (lineSeleted != null) this.pnlMain.PanelMainMouse.SetFalseSelectedOtherLine(lineSeleted, this.lineConnectList);

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

       

        /// <summary>

        #endregion Control_On_Form

        #region Button_Instance

        protected virtual void ButtonMouseDown(object sender, MouseEventArgs e, ConnectableE btnTool, DatabaseEPower databaseE)
        {
            if (e.Button == MouseButtons.Right) return;
            // Create instance of button1 and start drag-and-drop operation
            ConnectableE ctrlInstance = new ConnectableE(this, pnlMain, databaseE, this.imgListEPower);
            countElement++;
            ctrlInstance.Name = btnTool.Name + "_" + this.countElement;
            // ctrlInstance.Text = btnTool.Text + "_" + this.countElement;
            ctrlInstance.Location = btnTool.Location;

            ctrlInstance.DoDragDrop(ctrlInstance, DragDropEffects.Move);
            pnlMain.Controls.Add(ctrlInstance);
            ctrlInstance.BringToFront();
        }

        #endregion Button_Instance


    }
}























































/// Panel Main 

//private void pnlMain_MouseDown(object sender, MouseEventArgs e)
//{
//    this.SetIsSelected(null);

//    if (this.lineConnectList.Count == 0) return;
//    //Determine Line is selected
//    bool isContainLine = this.pnlMain.ProcessMain_MouseClick(e);

//    if (isContainLine) this.SetIsSelected(null);//select line in Panel, set isSelected false for all btn
//}




//private void pnlMain_DragEnter(object sender, DragEventArgs e)
//{
//    e.Effect = DragDropEffects.Move;
//}

//private void pnlMain_DragDrop(object sender, DragEventArgs e)
//{
//    // Get drop location and move button instance to that location
//    Point dropLocation = pnlMain.PointToClient(new Point(e.X, e.Y));
//    Control control = (Control)e.Data.GetData(typeof(ConnectableE));

//    if (pnlMain.ClientRectangle.Contains(dropLocation))
//    {
//        control.Location = dropLocation;
//        ConnectableE ePower = control as ConnectableE;
//        this.ePowers.Add(ePower);
//        this.iEPowers.Add(ePower);
//        ePower.isOnTool = false;
//    }
//    else
//    {
//        pnlMain.Controls.Remove(control);
//        control.Dispose();
//    }
//}
///// Panel Main













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






