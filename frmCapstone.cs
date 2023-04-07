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
        protected int countLine = 0;
        protected ProcessPowerConnection processPowerConn;

        private List<ConnectableE> EPowers;

        private List<IMouseOnEndsControl> _iEPowers;
        public List<IMouseOnEndsControl> IEPowers1 => _iEPowers;

        private List<LineConnect> lineConnectList;
        public List<LineConnect> LineConnectList => lineConnectList;

        protected float penWidth; // độ rộng mong muốn

        public frmCapstone()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.EPowers = new List<ConnectableE>();
            this._iEPowers = new List<IMouseOnEndsControl>();
            this.lineConnectList = new List<LineConnect>();

        }

        #region Reference_OutSide

        public virtual void AddLine(LineConnect lineConnect)
        {
            this.lineConnectList.Add(lineConnect);
            //Draw All Line
            this.DrawAllLineOnPanel();
        }

        public virtual ConnectableE CheckEndLineIsOnEPower(Point endLinePoint)
        {
            if (endLinePoint == Point.Empty) return null;

            foreach (ConnectableE ePower in this.EPowers)
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
            foreach (ConnectableE ePower in this.EPowers)
            {
                if (ePower != ePower_Focused) ePower.IsSelected = false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btnEPower"></param>

        #endregion Reference_OutSide

        public virtual void DrawAllLineOnPanel()
        {
            //  lblLine.Text = "Line Count = " + this.connectableList.Count;
            //not Clear All => Clear then will have one line because all not added in list line 
            foreach (LineConnect line in this.lineConnectList)
            {
                Point startPoint = line.StartPoint;
                Point endPoint = line.EndPoint;

                pnlMain.CreateGraphics().DrawLine(Pens.Black, startPoint, endPoint);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endLinePoint"></param> EndlinePoint is on coordinate pnlMain system


        #region Control_On_Form

        private void btnMF_MouseDown(object sender, MouseEventArgs e)
        {
            DatabaseEPower databaseE = new DatabaseEPower() { objectType = ObjectType.MF, Width = 50, Height = 50 };
            this.ButtonMouseDown(sender, e, btnMF, databaseE);

        }

        private void btnLineEPower_MouseDown(object sender, MouseEventArgs e)
        {
            DatabaseEPower databaseE = new DatabaseEPower() { objectType = ObjectType.LineEPower, Width = 30, Height = 80 };
            this.ButtonMouseDown(sender, e, btnLineEPower, databaseE);
        }


        private void btnBus_MouseDown(object sender, MouseEventArgs e)
        {
            DatabaseEPower databaseE = new DatabaseEPower() { objectType = ObjectType.Bus, Width = 80, Height = 20 };
            this.ButtonMouseDown(sender, e, btnBus, databaseE);
        }

        /// <summary>
        /// Panel Main 

        private void pnlMain_MouseDown(object sender, MouseEventArgs e)
        {
            //Determine Line is selected
            bool isContainLine = this.processPowerConn.ProcessMain_MouseClick(sender, e, this.lineConnectList);

            if (isContainLine) this.SetIsSelected(null);//select line in Panel, set isSelected false for all btn
        }



        private void frmCapstone_KeyDown(object sender, KeyEventArgs e)
        {

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
                this.EPowers.Add(ePower);
                this._iEPowers.Add(ePower);
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
                ConnectableE ctrlInstance = new ConnectableE(databaseE);
                countLine++;
                ctrlInstance.Name = btnTool.Name + "_" + this.countLine;
                ctrlInstance.Text = btnTool.Text + "_" + this.countLine;
                ctrlInstance.Location = btnTool.Location;

                ctrlInstance.MouseDown += this.ButtonInstance_MouseDown;
                ctrlInstance.MouseMove += this.ButtonInstance_MouseMove;
                ctrlInstance.MouseUp += this.ButtonInstance_MouseUp;
                ctrlInstance.DoDragDrop(ctrlInstance, DragDropEffects.Move);
                pnlMain.Controls.Add(ctrlInstance);
                ctrlInstance.BringToFront();

            }
        }

        #region ButtonInstance

        protected virtual void ButtonInstance_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.processPowerConn == null)
            {
                this.processPowerConn = new ProcessPowerConnection();
            }

            this.isDragging = this.processPowerConn.IsDragging;
            this.previousMouseLocation = this.processPowerConn.PreviousMouseLocation;
            this.processPowerConn.form = this;
            this.processPowerConn.ButtonInstance_MouseDown(sender, e, pnlMain);
            this.SetIsSelected(sender as ConnectableE);
            this.processPowerConn.SetFalseSelectedALLLine(this.LineConnectList);
        }

        protected virtual void ButtonInstance_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.processPowerConn == null)
            {
                this.processPowerConn = new ProcessPowerConnection();
            }
            this.processPowerConn.ButtonInstance_MouseMove(sender, e, pnlMain);

        }

        protected virtual void ButtonInstance_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.processPowerConn == null)
            {
                this.processPowerConn = new ProcessPowerConnection();
            }
            this.processPowerConn.ButtonInstance_MouseUp(sender, e, pnlMain);

            this.isDragging = processPowerConn.IsDragging;
        }

        public virtual void ShowPointConnect()
        {
            foreach (IMouseOnEndsControl ePower in this._iEPowers)
            {
                ePower.MouseMoveEnds();
            }
        }





        #endregion ButtonInstance


    }
}























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






