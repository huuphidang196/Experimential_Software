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
using Experimential_Software.CustomControl;
using Experimential_Software.DAO.DAO_BusData;
using Experimential_Software.DAO.DAO_GeneratorData;
using Experimential_Software.DAO.DAO_LineData;
using Experimential_Software.DAO.DAO_LoadData;
using Experimential_Software.DAO.DAO_MBA2Data;
using Experimential_Software.DAO.DAO_MBA3Data;
using Experimential_Software.DAO.DAO_SaveAndReadPowerSystem;
using Experimential_Software.DAO.DAO_Curve.DAO_Calculate;
using Experimential_Software.DAO.DAOProcessTreeView;
using System.Numerics;
using System.IO;
using Experimential_Software.DAO.DAOCapstone;
using System.Reflection;
using Experimential_Software.DAO.DAO_Curve.DAO_GeneratePath;

namespace Experimential_Software
{
    public partial class frmCapstone : Form
    {
        protected DTODataPowerSystem _dtoPowerSystem;
        public DTODataPowerSystem DTOPowerSystem { get => _dtoPowerSystem; set => _dtoPowerSystem = value; }

        protected List<ConnectableE> _ePowers = new List<ConnectableE>();
        public List<ConnectableE> EPowers { get => _ePowers; set => _ePowers = value; }

        //Remember sam ProcessMnuFile must fix List by directly add, not generate List after equal that this is not reference
        protected List<LineConnect> lineConnectList = new List<LineConnect>();
        public List<LineConnect> LineConnectList { get => lineConnectList; set => lineConnectList = value; }


        protected List<IMouseOnEndsControl> _iEPowers = new List<IMouseOnEndsControl>();
        public List<IMouseOnEndsControl> IEPowers { get => _iEPowers; set => _iEPowers = value; }

        protected double _zoomFactor = 1;

        //TreeView Path FolderSaved
        protected string _folderSaved_Path = "";

        protected bool isAllowSetPosSys = false;

        public frmCapstone()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.OpenFormSetBaseMVA();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.LoadImageMenuFile();

            //Load TreeView
            this.LoadDataTreeView();

            this.pnlMain.PanelMainMouse.FrmCapstone = this;
            this.lblZoomFactor.Text = "Zoom = " + Math.Round(100 * this.pnlMain.ZoomFactor, 0) + " %";

        }

        #region Load_Form
        protected virtual void LoadImageMenuFile()
        {
            if (this.imgListIconMnuStrip.Images.Count == 0) return;

            this.mnuFileNew.Image = this.imgListIconMnuStrip.Images[0];
            this.mnuFileOpen.Image = this.imgListIconMnuStrip.Images[1];
            this.mnuFileSave.Image = this.imgListIconMnuStrip.Images[2];
        }

        private void frmCapstone_Resize(object sender, EventArgs e)
        {
            // this.WindowState = FormWindowState.Maximized; // set window state to normal
            if (this.LineConnectList.Count > 0) this.DrawAllLineOnPanel();
        }

        protected virtual void OpenFormSetBaseMVA()
        {
            this._dtoPowerSystem = new DTODataPowerSystem();
            //Opwen Form BUild New Case
            frmBuildNewCase frmBuildNew = new frmBuildNewCase();
            frmBuildNew.DTPPowerSystem = this._dtoPowerSystem;
            frmBuildNew.ShowDialog();
        }

        #region _Load_Tree_View_Data_Saved
        public virtual void LoadDataTreeView()
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            this._folderSaved_Path = DAOGeneratePathFolder.Instance.CreatFolderSave(appDirectory);
            this.tvDataSaved.Nodes.Clear();
            int posSeperate = this._folderSaved_Path.LastIndexOf('\\');
            string nameNodeOri = this._folderSaved_Path.Substring(posSeperate + 1);
            TreeNode nodeParentOri = new TreeNode(nameNodeOri); // tạo một nút mới với tên là tên thư mục
            this.tvDataSaved.Nodes.Add(nodeParentOri);
            nodeParentOri.ImageIndex = 3;
            nodeParentOri.SelectedImageIndex = 3;

            //Add Child Nodes 
            DAOProcessCapstone.Instance.GetNodeFolderChildInFolderOrigin(this._folderSaved_Path, nodeParentOri);
            //Expand tree view
            // Tìm node gốc
            TreeNode rootNode = this.tvDataSaved.Nodes[0];
            if (rootNode != null)
            {
                rootNode.Expand();
                foreach (TreeNode node in rootNode.Nodes)
                {
                    if (node.Text == "Tree Data Saved") node.Expand();
                }
            }
        }

        private void tvDataSaved_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            if (!selectedNode.Text.Contains("txt") && !selectedNode.Text.Contains("jpg")) return;

            string pathFile = DAOProcessTreeView.Instance.GetPathOpenFileOnTreeView(this._folderSaved_Path, selectedNode);

            if (selectedNode.Text.Contains("txt"))
            {
                //not use treeview => null path
                this.OpenDatabaseFormSave(pathFile);
                return;
            }

            //Open Form Picture
            frmOpenImageFromTreeView frmPicture = new frmOpenImageFromTreeView();
            frmPicture.Text = selectedNode.Text;
            frmPicture.ImgPrinted = Image.FromFile(pathFile);
            frmPicture.Show();

        }


        #endregion _Load_Tree_View_Data_Saved

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
                if (ePower.DatabaseE.ObjectType != ObjectType.Bus) continue;

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
            if (e.Button == MouseButtons.Left)
            {
                //select line in Panel, set isSelected false for all btn
                this.SetIsSelectedEPower(null);

                if (this.lineConnectList.Count == 0) return;

                //Process set isSelected and Color for Line
                this.pnlMain.PanelMainMouse.ProcessMain_MouseCDown(this.lineConnectList, e);
                //find Line is Selected
                LineConnect lineSeletedCur = this.pnlMain.PanelMainMouse.FindLineConnectIsSelected(this.lineConnectList);
                if (lineSeletedCur == null && this.isAllowSetPosSys) this.pnlMain.ProcessAllEPowerWhenMouseWheel(MousePosition);
                return;
            }

            //find Line is Selected
            LineConnect lineSeleted = pnlMain.PanelMainMouse.FindLineConnectIsSelected(this.lineConnectList);
            //Set false
            if (lineSeleted == null) return;

            //Set falsse other Line is not selected near mouse
            this.pnlMain.PanelMainMouse.SetFalseSelectedOtherLine(lineSeleted, this.lineConnectList);
            //Show Context Menu strip
            this.cxtRemoveLineDrawn.Show(this.pnlMain.PointToScreen(e.Location));

        }
        private void RemoveThisLineDrawnOnPanel(object sender, EventArgs e)
        {
            //Remove Line Drawn When press Remove On Context menu strip
            this.pnlMain.ProcessDeleteLine(this);
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

                if (ePower.GenerateModeE == GenerateMode.LoadDatabase) return;

                this._zoomFactor = pnlMain.ZoomFactor;

                ePower.PreLocation = DAOProcessCapstone.Instance.CalculatePreLocationWhenInstance(this._zoomFactor, dropLocation, this._ePowers, this.pnlMain);
                this._ePowers.Add(ePower);
                this._iEPowers.Add(ePower);
                ePower.IsOnTool = false;

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
                case ObjectType.MBA3P:
                    if (ListEPowerInstance.Count != 0) currentExistMax = ListEPowerInstance.Max(x => x.DatabaseE.DataRecordE.DTOTransThreeEPower.ObjectNumber);//dto MBA3 => 3
                    databaseE.DataRecordE.DTOTransThreeEPower = DAOGeneMBA3Record.Instance.GenerateDTOTransThreeDefault(currentExistMax);
                    break;
                case ObjectType.LineEPower:
                    if (ListEPowerInstance.Count != 0) currentExistMax = ListEPowerInstance.Max(x => x.DatabaseE.DataRecordE.DTOLineEPower.ObjectNumber);//dtoLine => 5.
                    databaseE.DataRecordE.DTOLineEPower = DAOGeneLineRecord.Instance.GenerateDTOLineEPowerDefault(currentExistMax);
                    break;
                case ObjectType.Load:
                    if (ListEPowerInstance.Count != 0) currentExistMax = ListEPowerInstance.Max(x => x.DatabaseE.DataRecordE.DTOLoadEPower.ObjectNumber);//dtoLoad.
                    databaseE.DataRecordE.DTOLoadEPower = DAOGeneLoadRecord.Instance.GenerateDTOLoadDefault(currentExistMax);
                    //Set BaseMVA 
                    databaseE.DataRecordE.DTOLoadEPower.SBase = this._dtoPowerSystem.PowreBase_S_MVA;
                    break;
            }
            // Create instance of button1 and start drag-and-drop operation
            ConnectableE ctrlInstance = new ConnectableE(this, pnlMain, databaseE, this.imgListEPower, generateMode);

            ctrlInstance.Location = btnTool.Location;
            ctrlInstance.DoDragDrop(ctrlInstance, DragDropEffects.Move);
            pnlMain.Controls.Add(ctrlInstance);
            ctrlInstance.BringToFront();

        }
        //ybus. Ystate
        private void cxtMnuDCDominationDia_Click(object sender, EventArgs e)
        {
            frmSystemIsoval frmSystemIsoval = new frmSystemIsoval();
            frmSystemIsoval.AllEPowers = this._ePowers;
            frmSystemIsoval.BusLoadExamnined = this._ePowers.Find(x => x.IsSelected);
            ConnectableE ELoad = DAOCalculateQLJStepOne.Instance.GetEPowerPLoadFromEPowerBusLoadConsider(frmSystemIsoval.BusLoadExamnined);

            if (ELoad == null) return;
            frmSystemIsoval.Show();
        }
        //Isoval
        private void cxtMnuDCOperatingMode_Click(object sender, EventArgs e)
        {
            //Drawn Curve in Operating Mode
            frmDrawnCurve frmDrawnCurve = new frmDrawnCurve();
            frmDrawnCurve.frmCapstone = this;
            frmDrawnCurve.AllEPowers = this._ePowers;
            frmDrawnCurve.BusLoadExamnined = this._ePowers.Find(x => x.IsSelected);
            // MessageBox.Show("MVA = " + this._dtoPowerSystem.PowreBase_S_MVA + ", Frequency = " + this._dtoPowerSystem.Frequency_System_Hz);
            frmDrawnCurve.ShowDialog();

            if (frmDrawnCurve.DialogResult == DialogResult.Yes) this.LoadDataTreeView();
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
            this.lblZoomFactor.Text = "Zoom = " + Math.Round(100 * this.pnlMain.ZoomFactor, 0) + " %";

            this.Text = "Phần mềm đánh giá khả năng ổn định điện áp của hệ thống điện";
        }

        //openFile
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            //not use treeview => null path
            this.OpenDatabaseFormSave("");
        }

        protected virtual void OpenDatabaseFormSave(string path)
        {
            DAOProcessMenuFileStrip.Instance.FunctionMnuFileOpen_Click(this, path);
            this._zoomFactor = pnlMain.ZoomFactor;
            this.lblZoomFactor.Text = "Zoom = " + Math.Round(100 * this.pnlMain.ZoomFactor, 0) + " %";
            //Drawn Line On Panel Main After Have Info Line
            this.DrawAllLineOnPanel();

        }

        //save File
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            // this._processMnuFile.FunctionMnuFileSave_Click(sender, e);
            DAOProcessMenuFileStrip.Instance.FunctionMnuFileSave_Click(this);

            //Update TreeView
            this.LoadDataTreeView();
        }

        //Print Data
        private void btnPrintSystem_Click(object sender, EventArgs e)
        {
            this.btnPrintSystem.BackColor = Color.GreenYellow;

            frmPrintDataBase frmPrint = new frmPrintDataBase();
            frmPrint.AllEPowers = this._ePowers;
           DialogResult ret = frmPrint.ShowDialog();

            if (ret == DialogResult.Cancel) this.btnPrintSystem.BackColor = Color.White;
        }

        //Set Pos System
        private void btnSetPosSystem_Click(object sender, EventArgs e)
        {
            this.isAllowSetPosSys = !this.isAllowSetPosSys;
            this.btnSetPosSystem.BackColor = (this.isAllowSetPosSys) ? Color.SpringGreen : Color.HotPink;
        }
        //Help how to use softWare
        private void mnuStripHelpUseSW_Click(object sender, EventArgs e)
        {
            frmHelpForm frmHelpForm = new frmHelpForm();
            frmHelpForm.ShowDialog();
        }

        //Zoom In at Center Panel pnlMain
        private void btnZoomInCenter_Click(object sender, EventArgs e)
        {
            Point pointCenter = this.GetPointCenterPanelMain();
            double zoomPer = 1.1;
            this.pnlMain.SetZoomPanel(pointCenter, zoomPer);
        }

        //Zoom In at Center Panel pnlMain

        private void btnZoomOutCenter_Click(object sender, EventArgs e)
        {
            Point pointCenter = this.GetPointCenterPanelMain();
            double zoomPer = 1 / 1.1;
            this.pnlMain.SetZoomPanel(pointCenter, zoomPer);
        }

        protected virtual Point GetPointCenterPanelMain()
        {
            int xCenter = this.pnlMain.Width / 2;
            int yCenter = this.pnlMain.Height / 2;

            Point pointCenter = new Point(xCenter, yCenter);
            return pointCenter;
        }


        #endregion MenuStrip

     
    }
}

