﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.Class_Database;
using Experimential_Software.Class_Process_MnuFile;
using Experimential_Software.CustomControl;
using Experimential_Software.Class_Calculate;
using Experimential_Software.DAO.DAO_BusData;
using Experimential_Software.DAO.DAO_GeneratorData;
using Experimential_Software.DAO.DAO_LineData;
using Experimential_Software.DAO.DAO_LoadData;
using Experimential_Software.DAO.DAO_MBA2Data;
using Experimential_Software.DAO.DAO_SaveAndReadPowerSystem;
using Experimential_Software.DAO.DAO_Curve.DAO_Calculate;
using System.Numerics;

namespace Experimential_Software
{
    public partial class frmCapstone : Form
    {
        protected DTODataPowerSystem _dtoPowerSystem;
        public DTODataPowerSystem DTOPowerSystem { get => _dtoPowerSystem; set => _dtoPowerSystem = value; }

        protected int _countElement = 0;
        public int CountElement { get => _countElement; set => _countElement = value; }
        // protected PanelMain pnlMainDrawn;

        protected List<ConnectableE> _ePowers = new List<ConnectableE>();
        public List<ConnectableE> EPowers { get => _ePowers; set => _ePowers = value; }

        //Remember sam ProcessMnuFile must fix List by directly add, not generate List after equal that this is not reference
        protected List<LineConnect> lineConnectList = new List<LineConnect>();
        public List<LineConnect> LineConnectList { get => lineConnectList; set => lineConnectList = value; }


        protected List<IMouseOnEndsControl> _iEPowers = new List<IMouseOnEndsControl>();
        public List<IMouseOnEndsControl> IEPowers { get => _iEPowers; set => _iEPowers = value; }

        //Process new file, open, save
        //  protected ProcessMnuFile _processMnuFile;


        protected double _zoomFactor = 1;

        public frmCapstone()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Experimental Calculate YBus
            //this.ExperimentalYBus();

            this.OpenFormSetBaseMVA();

            //this.FixScaleSizeForm();
            this.LoadImageMenuFile();
            // this._processMnuFile = new ProcessMnuFile(this);
            this.pnlMain.PanelMainMouse.FrmCapstone = this;
            this.lblLine.Text = "Zoom = " + this.pnlMain.ZoomFactor;
        }


        #region Load_Form
        protected virtual void ExperimentalYBus()
        {
            int number_BusJ = 7; //<=> bus 7
            // Role all number have value = value - 1. Ex : numberF = 3 => numberF = 2 <=> 3 Bus MF 
            int Count_FBus = 3; //<=> 3 MF

            TestResult test = new TestResult(number_BusJ);

            Label lblYBus = new Label();
            lblYBus.AutoSize = true;
            pnlMain.Controls.Add(lblYBus);
            lblYBus.Location = new Point(50, 50);
            lblYBus.Font = new Font("Sans-serif", 10, FontStyle.Regular);
            lblYBus.Text = test.ShowYBus();

            Label lblZBus = new Label();
            lblZBus.AutoSize = true;
            pnlMain.Controls.Add(lblZBus);
            lblZBus.Location = new Point(50, 350);
            lblZBus.Font = new Font("Sans-serif", 10, FontStyle.Regular);
            lblZBus.Text = test.ShowZBus(Count_FBus, number_BusJ);

            Label lblUj = new Label();
            lblUj.AutoSize = true;
            pnlMain.Controls.Add(lblUj);
            lblUj.Location = new Point(350, 500);
            lblUj.Font = new Font("Sans-serif", 10, FontStyle.Regular);
            lblUj.Text = test.ShowUj();

        }


        protected virtual void LoadImageMenuFile()
        {
            if (this.imgListIconCtrl.Images.Count == 0) return;

            this.mnuFileNew.Image = this.imgListIconCtrl.Images[0];
            this.mnuFileOpen.Image = this.imgListIconCtrl.Images[1];
            this.mnuFileSave.Image = this.imgListIconCtrl.Images[2];
        }

        protected virtual void FixScaleSizeForm()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // fix form không thể thu nhỏ hoặc phóng to
            this.MinimizeBox = false;
            this.MaximizeBox = true;
            this.MaximumSize = this.Size; // giới hạn kích thước lớn nhất bằng kích thước hiện tại
            this.MinimumSize = this.Size; // giới hạn kích thước nhỏ nhất bằng kích thước hiện tại
                                          //Experimental by Form Data Bus. After set again
        }

        private void frmCapstone_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized; // set window state to normal
        }

        protected virtual void OpenFormSetBaseMVA()
        {
            this._dtoPowerSystem = new DTODataPowerSystem();
            //Opwen Form BUild New Case
            frmBuildNewCase frmBuildNew = new frmBuildNewCase();
            frmBuildNew.DTPPowerSystem = this._dtoPowerSystem;
            frmBuildNew.ShowDialog();

            //   MessageBox.Show("MVA = " + this._dtoPowerSystem.PowreBase_S_MVA + ", Frequency = " + this._dtoPowerSystem.Frequency_System_Hz);
        }

        #endregion Load_Form

        #region Reference_OutSide

        public virtual void AddLine(LineConnect lineConnect)
        {
            this.lineConnectList.Add(lineConnect);

        }

        public virtual void RemoveLine(LineConnect lineConnect)
        {
            this.lineConnectList.Remove(lineConnect);
            //Draw All Line
            this.DrawAllLineOnPanel();
        }

        public virtual void AddEPower(ConnectableE ePower)
        {
            this._ePowers.Add(ePower);
        }


        public virtual void RemoveEPower(ConnectableE ePower)
        {
            this._ePowers.Remove(ePower);
            //Draw All Line
            this.DrawAllLineOnPanel();
        }

        public virtual void AddIMouseOnEnds(IMouseOnEndsControl mouseOnEnds)
        {
            this._iEPowers.Add(mouseOnEnds);
        }

        public virtual void RemoveIMouseOnEndsAfterDelete(IMouseOnEndsControl mouseOnEnds)
        {
            this._iEPowers.Remove(mouseOnEnds);
        }

        public virtual void ShowPointConnect()
        {
            foreach (IMouseOnEndsControl ePower in this._iEPowers)
            {
                ePower.MouseMoveEnds();
            }
        }

        public virtual ConnectableE CheckEndLineIsOnEPower(Point endLinePoint, ConnectableE ePower_Origin)
        {
            if (endLinePoint == Point.Empty) return null;

            foreach (ConnectableE ePower in this._ePowers)
            {
                bool isOnPower = ePower.Bounds.Contains(endLinePoint);
                if (!isOnPower) continue;

                if (ePower == ePower_Origin) return null;

                return ePower;
            }

            return null;
        }

        //Remove isselect another ConnectionE
        public virtual void SetIsSelectedEPower(ConnectableE ePower_Focused)
        {
            foreach (ConnectableE ePower in this._ePowers)
            {
                if (ePower != ePower_Focused) ePower.IsSelected = false;
            }

        }




        public virtual void DrawAllLineOnPanel()
        {
            //not Clear All => Clear then will have one line because all not added in list line 
            foreach (LineConnect line in this.lineConnectList)
            {
                this.DrawnLinesConnectOnPanel(line);
            }
        }

        public virtual void DrawnLinesConnectOnPanel(LineConnect lineConnect)
        {
            //not Clear All => Clear then will have one line because all not added in list line 
            Point startPoint = lineConnect.StartPoint;
            Point endPoint = lineConnect.EndPoint;

            pnlMain.CreateGraphics().DrawLine(Pens.Black, startPoint, endPoint);
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
        //Bus
        private void btnBusPower_MouseDown(object sender, MouseEventArgs e)
        {
            ConnectableE btnSelected = sender as ConnectableE;
            ObjectOrientation objOri = btnSelected == btnBusPower_Hor ? ObjectOrientation.Horizontal : ObjectOrientation.Verical;
            DatabaseEPower databaseE = new DatabaseEPower() { ObjectType = ObjectType.Bus, ObjectOri = objOri };
            this.ButtonMouseDown(sender, e, btnSelected, databaseE, GenerateMode.Instance);
        }

        //Line
        protected void btnLinePower_MouseDown(object sender, MouseEventArgs e)
        {
            ConnectableE btnSelected = sender as ConnectableE;
            ObjectOrientation objOri = btnSelected == btnLinePower_Hor ? ObjectOrientation.Horizontal : ObjectOrientation.Verical;
            DatabaseEPower databaseE = new DatabaseEPower() { ObjectType = ObjectType.LineEPower, ObjectOri = objOri };
            this.ButtonMouseDown(sender, e, btnSelected, databaseE, GenerateMode.Instance);
        }

        //MF
        protected void btnMFPower_MouseDown(object sender, MouseEventArgs e)
        {
            ConnectableE btnSelected = sender as ConnectableE;
            ObjectOrientation objOri = btnSelected == btnMFPower_Hor ? ObjectOrientation.Horizontal : ObjectOrientation.Verical;
            DatabaseEPower databaseE = new DatabaseEPower() { ObjectType = ObjectType.MF, ObjectOri = objOri };
            this.ButtonMouseDown(sender, e, btnSelected, databaseE, GenerateMode.Instance);
        }

        //Trans2P
        private void btnTransformer2P_MouseDown(object sender, MouseEventArgs e)
        {
            ConnectableE btnSelected = sender as ConnectableE;
            ObjectOrientation objOri = btnSelected == btnTransformer2P_Hor ? ObjectOrientation.Horizontal : ObjectOrientation.Verical;

            DatabaseEPower databaseE = new DatabaseEPower() { ObjectType = ObjectType.MBA2P, ObjectOri = objOri };
            this.ButtonMouseDown(sender, e, btnSelected, databaseE, GenerateMode.Instance);
        }

        //Trans 3P
        private void btnTransformer3P_MouseDown(object sender, MouseEventArgs e)
        {
            ConnectableE btnSelected = sender as ConnectableE;
            ObjectOrientation objOri = btnSelected == btnTransformer3P_Hor ? ObjectOrientation.Horizontal : ObjectOrientation.Verical;
            DatabaseEPower databaseE = new DatabaseEPower() { ObjectType = ObjectType.MBA3P, ObjectOri = objOri };
            this.ButtonMouseDown(sender, e, btnSelected, databaseE, GenerateMode.Instance);
        }

        //Load
        private void btnLoad_MouseDown(object sender, MouseEventArgs e)
        {
            ConnectableE btnSelected = sender as ConnectableE;
            ObjectOrientation objOri = btnSelected == btnLoad_Hor ? ObjectOrientation.Horizontal : ObjectOrientation.Verical;
            DatabaseEPower databaseE = new DatabaseEPower() { ObjectType = ObjectType.Load, ObjectOri = objOri };
            this.ButtonMouseDown(sender, e, btnSelected, databaseE, GenerateMode.Instance);
        }


        //Panel Main  
        private void pnlMain_MouseDown(object sender, MouseEventArgs e)
        {
            this.PrcocessLineDrawnSelectAndRemoveLineDrawn(e);
        }

        private void PrcocessLineDrawnSelectAndRemoveLineDrawn(MouseEventArgs e)
        {
            //select line in Panel, set isSelected false for all btn
            this.SetIsSelectedEPower(null);

            if (this.lineConnectList.Count == 0) return;

            //Process set isSelected and Color for Line
            this.pnlMain.PanelMainMouse.ProcessMain_MouseCDown(this.lineConnectList, e);

            //find Line is Selected
            LineConnect lineSeleted = pnlMain.PanelMainMouse.FindLineConnectIsSelected(this.lineConnectList);

            //Set false
            if (lineSeleted == null) return;

            //Set falsse other Line is not selected near mouse
            this.pnlMain.PanelMainMouse.SetFalseSelectedOtherLine(lineSeleted, this.lineConnectList);
            //Remove Line Drawn When Press Ctrl
            if (Control.ModifierKeys == Keys.Control) this.pnlMain.ProcessDeleteLine(this);
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

                ePower.PreLocation = dropLocation;

                this._ePowers.Add(ePower);
                this._iEPowers.Add(ePower);
                ePower.IsOnTool = false;

                this._zoomFactor = pnlMain.ZoomFactor;
                pnlMain.SetInsideEPower(ePower);

                //Open Data Record the first
                if (ePower.GenerateModeE == GenerateMode.Instance) ePower.OpenDataRecordForm();

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

        protected virtual void ButtonMouseDown(object sender, MouseEventArgs e, ConnectableE btnTool, DatabaseEPower databaseE, GenerateMode generateMode)
        {
            if (e.Button == MouseButtons.Right) return;
            //count objectype
            var ListEPowerInstance = this._ePowers.FindAll(x => x.DatabaseE.ObjectType == databaseE.ObjectType);
            int currentExistMax = 0;

            databaseE.DataRecordE = new DataRecordEPowerCtrl();
            switch (databaseE.ObjectType)
            {
                case ObjectType.Bus:
                    if (ListEPowerInstance.Count != 0) currentExistMax = ListEPowerInstance.Max(x => x.DatabaseE.DataRecordE.DTOBusEPower.ObjectNumber);//dto Bus = 1
                    databaseE.DataRecordE.DTOBusEPower = DAOGeneBusRecord.Instance.GenerateDTOBusDefault(currentExistMax);
                    break;
                case ObjectType.MF:
                    if (ListEPowerInstance.Count != 0) currentExistMax = ListEPowerInstance.Max(x => x.DatabaseE.DataRecordE.DTOGeneEPower.ObjectNumber);//dto MF = 2
                    databaseE.DataRecordE.DTOGeneEPower = DAOGeneMFRecord.Instance.GenerateDTOMFEPowerDefault(currentExistMax);
                    //Set BaseMVA 
                    databaseE.DataRecordE.DTOGeneEPower.PowerMachineMF.MBase = this._dtoPowerSystem.PowreBase_S_MVA;
                    break;
                case ObjectType.MBA2P:
                    if (ListEPowerInstance.Count != 0) currentExistMax = ListEPowerInstance.Max(x => x.DatabaseE.DataRecordE.DTOTransTwoEPower.ObjectNumber);//dto MBA2 => 3
                    databaseE.DataRecordE.DTOTransTwoEPower = DAOGeneMBA2Record.Instance.GenerateDTOTransTwoDefault(currentExistMax);
                    break;
                case ObjectType.LineEPower:
                    if (ListEPowerInstance.Count != 0) currentExistMax = ListEPowerInstance.Max(x => x.DatabaseE.DataRecordE.DTOLineEPower.ObjectNumber);//dtoLine => 5.
                    databaseE.DataRecordE.DTOLineEPower = DAOGeneLineRecord.Instance.GenerateDTOLineEPowerDefault(currentExistMax);
                    break;
                case ObjectType.Load:
                    if (ListEPowerInstance.Count != 0) currentExistMax = ListEPowerInstance.Max(x => x.DatabaseE.DataRecordE.DTOLoadEPower.ObjectNumber);//dtoLoad.
                    databaseE.DataRecordE.DTOLoadEPower = DAOGeneLoadRecord.Instance.GenerateDTOLoadDefault(currentExistMax);
                    //Set BaseMVA 
                    databaseE.DataRecordE.DTOLoadEPower.MBase = this._dtoPowerSystem.PowreBase_S_MVA;
                    break;
            }
            // Create instance of button1 and start drag-and-drop operation
            ConnectableE ctrlInstance = new ConnectableE(this, pnlMain, databaseE, this.imgListEPower, generateMode);

            //cOUNT aLLL Epowers
            _countElement = this._ePowers.Count + 1;

            ctrlInstance.Location = btnTool.Location;
            ctrlInstance.DoDragDrop(ctrlInstance, DragDropEffects.Move);
            pnlMain.Controls.Add(ctrlInstance);
            ctrlInstance.BringToFront();

            //Add Func Context MenuStrip
            ctrlInstance.MouseUp += CtrlInstance_ClickContextMenuStrip;

        }

        private void CtrlInstance_ClickContextMenuStrip(object sender, MouseEventArgs e)
        {
            //ContextMenuStrip => Drawn => Only open when click right mouse
            if (e.Button == MouseButtons.Right)
            {
                ConnectableE ePowerInstance = sender as ConnectableE;
                if (ePowerInstance.DatabaseE.ObjectType != ObjectType.Bus)
                {
                    MessageBox.Show("Please Click Bus connect with Load !");
                    return;
                }

                ePowerInstance.ContextMenuStrip = this.cxttMenuStripEPower;      
            }        
        }

        private void cxtMnuDCOperatingMode_Click(object sender, EventArgs e)
        {
            //Drawn Curve in Operating Mode
            frmDrawnCurve frmDrawnCurve = new frmDrawnCurve();
            frmDrawnCurve.Show();
        }

        #endregion Button_Instance

        #region MenuStrip

        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            // this._processMnuFile.FunctionMnuFileNew_Click(sender, e);
            DAOProcessMenuFileStrip.Instance.FunctionMnuFileNew_Click(this);
            //Set Again Base MVA
            this.OpenFormSetBaseMVA();
            this._zoomFactor = 1;
            this.pnlMain.ZoomFactor = 1;
            this.lblLine.Text = "Zoom = " + this.pnlMain.ZoomFactor;
        }

        //openFile
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            // this._processMnuFile.FunctionMnuFileOpen_Click(sender, e);
            DAOProcessMenuFileStrip.Instance.FunctionMnuFileOpen_Click(this);
            this._zoomFactor = pnlMain.ZoomFactor;
            this.lblLine.Text = "Zoom = " + this.pnlMain.ZoomFactor;
            //Drawn Line On Panel Main After Have Info Line
            this.DrawAllLineOnPanel();

        }

        //save File
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            // this._processMnuFile.FunctionMnuFileSave_Click(sender, e);
            DAOProcessMenuFileStrip.Instance.FunctionMnuFileSave_Click(this);
        }

        #endregion MenuStrip

        //Experimental CalculateYstate
        private void lblLine_MouseDown(object sender, MouseEventArgs e)
        {
            Complex[,] Y_state = DAOGenerateYState.Instance.CalculateMatrixYState(this._ePowers);

            Label lblYState = new Label();
            lblYState.AutoSize = true;
            pnlMain.Controls.Add(lblYState);
            lblYState.Location = new Point(50, 50);
            lblYState.Font = new Font("Sans-serif", 10, FontStyle.Regular);

            string s = "";
            for (int i = 0; i < Y_state.GetLength(0); i++)
            {
                s += "Bus " + (i + 1);
                for (int j = 0; j < Y_state.GetLength(1); j++)
                {
                    s += Y_state[i, j] + new string(' ', 10);
                }
                s += "\n";
            }
            lblYState.Text = s;

        }

        private void btnLinePower_KeyDown(object sender, KeyEventArgs e)
        {

            // Vẽ lại CustomControl
            btnLinePower_Ver.Invalidate();

            // Vẽ lại Panel
            pnlMain.Invalidate();
        }

    }
}























































/// Panel Main 




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






//#region MenuStrip

//private void mnuFileNew_Click(object sender, EventArgs e)
//{
//    this.ClearAllEPowerAndLineOnMain();
//}

//protected virtual void ClearAllEPowerAndLineOnMain()
//{
//    this.pnlMain.Controls.Clear();
//    this.ePowers.Clear();
//    this.IEPowers.Clear();
//    this.lineConnectList.Clear();
//    this.countElement = 0;
//}

////openFile
//private void mnuFileOpen_Click(object sender, EventArgs e)
//{
//    //Question Before Open;
//    bool saveBefore = this.QuestionSaveBeforeOpen();

//    if (saveBefore) return;

//    OpenFileDialog openFileDialogMaain = new OpenFileDialog();
//    openFileDialogMaain.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
//    openFileDialogMaain.FilterIndex = 1;
//    //FilterIndex cho biết định dạng mặc định khi mở hộp thoại
//    openFileDialogMaain.RestoreDirectory = true;
//    //RestoreDirectory cho phép hộp thoại khôi phục đường dẫn trước đó khi được mở lên.

//    if (openFileDialogMaain.ShowDialog() != DialogResult.OK) return;

//    string path = openFileDialogMaain.FileName;

//    //Clear All 
//    this.ClearAllEPowerAndLineOnMain();
//    //Add EPower
//    this.ProcessOpenFile(path);

//    if (this.ePowers == null) return;

//    //  MessageBox.Show("Open Successed , count = " + this.ePowers.Count);
//}

//protected virtual bool QuestionSaveBeforeOpen()
//{
//    if (pnlMain.Controls.Count < 0) return false;

//    DialogResult result = MessageBox.Show("Do you want to Save this File", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//    if (result == DialogResult.Yes)
//    {
//        this.mnuFileSave.PerformClick();
//        return true;
//    }

//    this.mnuFileNew.PerformClick();
//    return false;
//}

//protected virtual void ProcessOpenFile(string path)
//{
//    List<DatabaseEPower> databaseEPowers = FileFoctory.ReadDatabaseEPower(path);

//    foreach (DatabaseEPower databaseE in databaseEPowers)
//    {
//        ConnectableE ePower = new ConnectableE(this, this.pnlMain, databaseE, this.imgListEPower);
//        this.EPowers.Add(ePower);
//        this.iEPowers.Add(ePower);
//        ePower.isOnTool = false;

//        pnlMain.Controls.Add(ePower);
//        ePower.BringToFront();

//        ePower.Location = this.GetPointOldInDatabaseEpower(databaseE);

//    }
//}

//protected virtual Point GetPointOldInDatabaseEpower(DatabaseEPower databaseE)
//{
//    Point oldLocation = databaseE.OldLocation;
//    return oldLocation;
//}



////save File
//private void mnuFileSave_Click(object sender, EventArgs e)
//{
//    SaveFileDialog saveFileDialogMaain = new SaveFileDialog();
//    saveFileDialogMaain.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
//    saveFileDialogMaain.FilterIndex = 1;
//    saveFileDialogMaain.RestoreDirectory = true;

//    if (saveFileDialogMaain.ShowDialog() != DialogResult.OK) return;

//    string path = saveFileDialogMaain.FileName;
//    this.ProcessSaveOldPostionEPower(this.ePowers);
//    bool saveSuccess = FileFoctory.SaveDataBaseEPower(this.ePowers, path);

//    if (!saveSuccess) return;
//    MessageBox.Show("Save Successed");
//}

//protected virtual void ProcessSaveOldPostionEPower(List<ConnectableE> EPowersSave)
//{
//    foreach (ConnectableE ePower in EPowersSave)
//    {
//        DatabaseEPower databaseE = ePower.DatabaseE;
//        databaseE.OldLocation = ePower.Location;
//    }
//}