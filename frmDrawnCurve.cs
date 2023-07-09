using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Media;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.IO;

using Experimential_Software.DTO;
using Experimential_Software.BLL.BLL_Curve.BLL_Calculate;
using Experimential_Software.BLL.BLL_Curve.BLL_Calculate_ManyCurve;
using Experimential_Software.BLL.BLL_Curve.BLL_Check_Stability;
using Experimential_Software.BLL.BLL_Curve.BLL_GeneratePath;
using Experimential_Software.BLL.BLL_Curve.BLL_InteractServer;

namespace Experimential_Software
{
    public partial class frmDrawnCurve : Form
    {
        protected frmCapstone _frmCapstone;
        public frmCapstone frmCapstone { set => _frmCapstone = value; }

        protected List<ConnectableE> _allEPowers;
        public List<ConnectableE> AllEPowers { get => _allEPowers; set => _allEPowers = value; }

        // Bus Examinate connect with Load
        protected ConnectableE _busLoadExamined;
        public ConnectableE BusLoadExamnined { get => _busLoadExamined; set => _busLoadExamined = value; }
        public object FindIntersection { get; private set; }

        // Góc alpha (đơn vị: độ)
        protected float _alpha = 0; // Góc xoay 45 độ (ví dụ)
        protected float _perRotTen = 24;

        protected bool isOneCurve = true;

        //Max P, Q
        protected double _PMax_Global = 100;
        protected double _QMax_Global = 100;

        //Get Server
        protected bool isGetServer = false;
        public bool IsGetServer { set => isGetServer = value; }

        public frmDrawnCurve()
        {
            InitializeComponent();
        }

        #region Form_Load
        private void frmDrawnCurve_Load(object sender, EventArgs e)
        {
            if (this._busLoadExamined != null)
            {
                this.SetDefaultPanelRandom();
                this.ShowDataOnForm();
                this.SetValueStartForChart();

                //Set Rotate Picturebox ClockWise
                this.RotateImage(this._alpha);
            }
        }

        protected virtual void SetDefaultPanelRandom()
        {
            //Min Per
            this.txtMinPer.Text = 100 + "";
            //Max Per
            this.txtMaxPer.Text = 100 + "";
            // Many Curve
            this.txtCountCurve.Text = 1 + "";

            //Check Box 1 Curve
            this.chkOneCurve.Checked = true;
            this.isOneCurve = true;

            //Check Get ListPoint
            this.chkGetListPoints.Checked = true;
        }

        protected virtual void ShowDataOnForm()
        {
            lblNumberBusLoad.Text = (this._busLoadExamined.DatabaseE.DataRecordE.DTOBusEPower.ObjectNumber - 100 * (int)ObjectType.Bus) + "";

            this.lblCmdReset.Visible = true;
            this.lblProgress.Visible = false;

        }

        protected virtual void SetValueStartForChart()
        {
            this.chartCurveLimted.BackColor = Color.LightGray;
            this.chartCurveLimted.Titles.Add("Miền làm việc ổn định trong mặt phẳng công suất P-Q");
            this.chartCurveLimted.Titles[0].Font = new Font("Tohoma", 11, FontStyle.Bold);
            this.chartCurveLimted.Titles[0].ForeColor = Color.Black;

            // Ẩn phần chú thích mặc định của Chart
            this.chartCurveLimted.Legends.Clear();

            this.chartCurveLimted.ChartAreas[0].AxisX.Minimum = 0;
            // Thiết lập giới hạn của trục X từ 0 đến max + 10
            this.chartCurveLimted.ChartAreas[0].AxisX.Maximum = this._QMax_Global + 50;

            //// Thiết lập giới hạn của trục Y từ -5 đến
            this.chartCurveLimted.ChartAreas[0].AxisY.Minimum = 0;
            this.chartCurveLimted.ChartAreas[0].AxisY.Maximum = this._PMax_Global + 100;


            // Thiết lập khoảng cách giữa các ô chia trên trục X là 1 đơn vị
            this.chartCurveLimted.ChartAreas[0].AxisX.Interval = 50;

            // Thiết lập khoảng cách giữa các ô chia trên trục Y là 0.5 đơn vị
            this.chartCurveLimted.ChartAreas[0].AxisY.Interval = 50;

            this.chartCurveLimted.ChartAreas[0].AxisX.Title = "Q (Mvar)"; // Đặt tên cho trục X
            this.chartCurveLimted.ChartAreas[0].AxisY.Title = "P (MW)"; // Đặt tên cho trục Y
        }

        #endregion Form_Load

        #region Picture_Box_Wise

        private void RotateImage(float angle)
        {
            string pathImage = BLLGeneratePathFolder.Instance.LoadImageClockWiseInsideLibraryLogo();
            Image imgWise = Image.FromFile(pathImage);
            Bitmap rotatedImage = new Bitmap(imgWise.Width, imgWise.Height);

            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                // Xoay hình ảnh
                g.TranslateTransform((float)imgWise.Width / 2, (float)imgWise.Height / 2);
                g.RotateTransform(angle);
                g.TranslateTransform(-(float)imgWise.Width / 2, -(float)imgWise.Height / 2);
                g.DrawImage(imgWise, Point.Empty);
            }

            // Hiển thị hình ảnh xoay trên PictureBox
            ptbClockWise.Image = rotatedImage;
            ptbClockWise.SizeMode = PictureBoxSizeMode.Zoom;

        }

        #endregion Picture_Box_Wise

        #region Button_Reset_Event
        private void btnReset_MouseDown(object sender, MouseEventArgs e)
        {
            this.pnlProgress.Visible = true;
            this.lblCmdReset.Visible = false;

            this.lblProgress.Text = "Program is Processing ...";
            this.lblProgress.Visible = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (this._busLoadExamined == null)
            {
                MessageBox.Show("You must select one Bus is considered!");
                this.Close();
                return;
            }

            //Get set value server
            if (this.isGetServer) this.GetAndSetDataSystemFromServer();

            //Set Variable
            this.SetVariableWhenResetPressed();
            //Add point Load Random if many curve mode
            this.AddPointLoadRandomInManyCurveUnit();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            int toltalCount = int.Parse(this.txtCountCurve.Text);
            double rateMin = double.Parse(this.txtMinPer.Text) / 100;
            double rateMax = double.Parse(this.txtMaxPer.Text) / 100;

            //Generate Old Dictionary Power Load Old
            Dictionary<string, PowerSystem> Dic_PQ_Old = BLLCalculateManyCurve.Instance.GetDictionaryPowerSystemOld(this._allEPowers);

            for (int i = 0; i < toltalCount; i++)
            {
                //Reccify PLoad, QLoad All Load
                this._allEPowers = BLLCalculateManyCurve.Instance.RecifyAllPowerSystemLoad(this._allEPowers, Dic_PQ_Old, rateMin, rateMax);
                //Process Chart and ListBox
                this.ProcessDrawnChartCurveLimited(i + 1);
            }
            //Set label Stability
            if (!this.isOneCurve) this.SetLabelStablityAndProbility(null);

            //Processing completed event
            this.ProcessingCompletedEvent(Dic_PQ_Old, stopwatch);
        }

        protected virtual void GetAndSetDataSystemFromServer()
        {
            BLLInteractServer.Instance.GetAndSetDataSystemFromServer(this._allEPowers, "huuphidang2804", "19062001Phi@");
        }

        protected virtual void SetVariableWhenResetPressed()
        {
            this._alpha = 0;
            this.RotateImage(this._alpha);

            this.lblKPghRatio.Text = "P0 / PGh = 0 %";
            this.lblStableReserve.Text = "Độ dự trữ ổn định : 0%";


            this.chartCurveLimted.Series.Clear();
            this._PMax_Global = this._QMax_Global = 100;

            this.lstBoxExperPoint.Items.Clear();
        }

        protected virtual void AddPointLoadRandomInManyCurveUnit()
        {
            if (this.isOneCurve) return;

            PowerSystem psLoad = BLLDrawnChartCurveLimited.Instance.GetPowerSystemFromRandomValueLoad(this._busLoadExamined);
            double rateMLimit_Min = double.Parse(this.txtMinPointRandom.Text) / 100;
            double rateMLimit_Max = double.Parse(this.txtMaxPointRandom.Text) / 100;

            PowerSystem psM_Random = BLLCalculateManyCurve.Instance.GetValueRandomInTheRange(psLoad, rateMLimit_Min, rateMLimit_Max);
            BLLDrawnChartCurveLimited.Instance.AddPointLoadOnChart(this.chartCurveLimted, psM_Random, this.isOneCurve);
        }

        #endregion Button_Reset_Event


        #region Process_Chart_Curve
        protected virtual void ProcessDrawnChartCurveLimited(int numberSeries)
        {
            List<PowerSystem> List_PS_Point = BLLGenerateListPoints.Instance.GenerateListPointStabilityLimitCurve(this._allEPowers, this._busLoadExamined);
            if (List_PS_Point.Count == 0)
            {
                if (this.isOneCurve) MessageBox.Show("Please consider this Database !", "Remider notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Drawn Curve
            this.DrawnChartCurveLimited(List_PS_Point, numberSeries);
            //Find Point Limit On Curve
            this.FindLimitPointOnCurveAndEvaluateStability(numberSeries);

            if (!this.isOneCurve) return;

            this.ProcessPowerLimitOnListBox(List_PS_Point);
            //Find Pgh Qgh
            this.FindPLimitAndQLimitWhenStabilitySystem();

            //Set Percent Stability
            this.SetClockWiseStaticReserveFactor();

        }

        protected virtual void FindLimitPointOnCurveAndEvaluateStability(int numberSeries)
        {
            string nameData = "Data" + numberSeries;
            PointF? pSectionLimit = BLLCheckStability.Instance.FindInterSectionPQLimtOnCurve(this.chartCurveLimted.Series[nameData], this.chartCurveLimted.Series["PointLoad"], this.isOneCurve);

            if (pSectionLimit == null) return;//Only many Mode 

            PowerSystem pointLimitOnCurve = new PowerSystem(pSectionLimit.Value.Y, pSectionLimit.Value.X);
            //set type seri
            this.chartCurveLimted.Series["PointLoad"].ChartType = SeriesChartType.Line;
            BLLDrawnChartCurveLimited.Instance.AddPointCircleOnChart(this.chartCurveLimted, pointLimitOnCurve, "PointLoad", this.isOneCurve);

            if (!this.isOneCurve)
            {
                //if Not Get List Point
                if (!this.chkGetListPoints.Checked) return;

                this.AddPerElementOnListBox(pointLimitOnCurve);
                return;
            }
            //Set label Stability
            this.SetLabelStablityAndProbility(pSectionLimit);


        }

        //Label Stability One Curve Mode
        protected virtual void SetLabelStablityAndProbility(PointF? pSectionLimit)
        {
            string str_Stability = (this.isOneCurve) ? BLLCheckStability.Instance.GetStringStabilityByOffSetOneCurveMode(pSectionLimit, this.chartCurveLimted.Series["PointLoad"])
                : BLLCheckStability.Instance.GetStringStabilityByCountSectionManyCurveMode(this.chartCurveLimted.Series["PointLoad"], double.Parse(this.txtCountCurve.Text));

            string str_Probility = (this.isOneCurve) ? BLLCheckStability.Instance.GetStringProbilitySystemByOffSetOneCurveMode(pSectionLimit, this.chartCurveLimted.Series["PointLoad"])
                : BLLCheckStability.Instance.GetStringProbilityByCountSectionManyCurveMode(this.chartCurveLimted.Series["PointLoad"], double.Parse(this.txtCountCurve.Text));

            this.lblStateSystem.Text = str_Stability;
            this.txtPerProbility.Text = str_Probility;
        }

        protected virtual void FindPLimitAndQLimitWhenStabilitySystem()
        {
            BLLFindPLimitAndQLimitWhenStabilitySystem.Instance.FindPLimitAndQLimitWhenStabilitySystem(this.chartCurveLimted, this.isOneCurve);
        }

        //ListBox P, Q
        protected virtual void ProcessPowerLimitOnListBox(List<PowerSystem> List_PS_Point)
        {
            //if Not Get List Point
            if (!this.chkGetListPoints.Checked) return;

            foreach (PowerSystem ps in List_PS_Point)
            {
                this.AddPerElementOnListBox(ps);
            }
        }

        protected virtual void AddPerElementOnListBox(PowerSystem ps)
        {
            this.lstBoxExperPoint.Items.Add("(P =  " + Math.Round(ps.P_ActivePower, 4) + ", Q = " + Math.Round(ps.Q_ReactivePower, 4));
        }

        //Set ClockWise
        protected virtual void SetClockWiseStaticReserveFactor()
        {
            if (this.chartCurveLimted.Series["PointPQLimit"].Points.Count < 2) return;

            int numberPgh = this.chartCurveLimted.Series["PointPQLimit"].Points.Count - 1;
            DataPoint pointPgh = this.chartCurveLimted.Series["PointPQLimit"].Points[numberPgh];
            double Pgh = pointPgh.YValues[0];

            int numberM0 = this.chartCurveLimted.Series["PointPQLimit"].Points.Count - 2;
            DataPoint pointM0 = this.chartCurveLimted.Series["PointPQLimit"].Points[numberM0];
            double P0 = pointM0.YValues[0];

            double Percent = 100 * (P0 / Pgh);
            this.lblKPghRatio.Text = "P0 / PGh = " + Math.Round(Percent, 2) + " %";
            this.lblStableReserve.Text = "Độ dự trữ ổng định : " + (Percent <= 100 ? Math.Round(100 - Percent, 2) : 0) + " %";


            Percent = Math.Min(Percent, 120);

            this._alpha += (this._perRotTen * (float)Percent / 10);
            this.RotateImage(this._alpha);
        }

        #endregion Process_Chart_Curve

        #region Drawn_Chart_Curve
        //Drawn
        private void DrawnChartCurveLimited(List<PowerSystem> list_PS_Point, int numberSeries)
        {
            this.SetLimtValueChartAndPerUnit(list_PS_Point, numberSeries);

            //Add list point on Chart
            this.AddListPointPowerSystemFoundOnChart(list_PS_Point, numberSeries);

        }

        //limte value and per unit value
        protected virtual void SetLimtValueChartAndPerUnit(List<PowerSystem> list_PS_Point, int numberSeries)
        {
            double Pmax = list_PS_Point.Max(S => S.P_ActivePower);
            double Qmax = list_PS_Point.Max(S => S.Q_ReactivePower);

            if (this._PMax_Global < Pmax) this._PMax_Global = Pmax;
            if (this._QMax_Global < Pmax) this._QMax_Global = Qmax;
        }

        protected void AddListPointPowerSystemFoundOnChart(List<PowerSystem> list_PS_Point, int numberSeries)
        {
            BLLDrawnChartCurveLimited.Instance.AddListPointPowerSystemFoundOnChart(this.chartCurveLimted, list_PS_Point, numberSeries, this.isOneCurve, this._busLoadExamined);
        }

        protected virtual void ProcessingCompletedEvent(Dictionary<string, PowerSystem> Dic_PQ_Old, Stopwatch stopwatch)
        {
            this.pnlProgress.Visible = false;

            //Save Old Power Load
            this._allEPowers = BLLCalculateManyCurve.Instance.ReturnAllPowerSystemLoadOrigin(this._allEPowers, Dic_PQ_Old);

            // Thiết lập giới hạn của trục X từ 0 đến max + 10
            this.chartCurveLimted.ChartAreas[0].AxisX.Maximum = this._QMax_Global + 200;

            //// Thiết lập giới hạn của trục Y từ -5 đến
            this.chartCurveLimted.ChartAreas[0].AxisY.Maximum = this._PMax_Global + 300;


            //Creat folder Library Sound
            string pathSound = BLLGeneratePathFolder.Instance.LoadPathSoundInsideLibrarySound();
            SoundPlayer player = new SoundPlayer(pathSound);

            stopwatch.Stop();
            TimeSpan duration = stopwatch.Elapsed;

            //Play Sound
            player.Play();

            MessageBox.Show("Time Span = " + string.Format("{0}:{1:D2}", duration.Minutes, duration.Seconds));
        }

        #endregion Drawn_Chart_Curve

        //Button Close event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.isGetServer = false;
        }


        #region Print_Click
        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Lấy kích thước và vị trí của Form
            Rectangle formBounds = Bounds;
            int formWidth = formBounds.Width;
            int formHeight = formBounds.Height;
            int formX = formBounds.Left;
            int formY = formBounds.Top;

            // Tạo một Bitmap để chứa ảnh snip
            Bitmap snipBitmap = new Bitmap(formWidth, formHeight);

            // Copy nội dung của Form vào Bitmap
            using (Graphics graphics = Graphics.FromImage(snipBitmap))
            {
                graphics.CopyFromScreen(formX + 2, formY + 2, 0, 0, new Size(formWidth - 2, formHeight - 2));
            }

            // Lưu ảnh snip vào đường dẫn chỉ định
            string savePath = BLLGeneratePathFolder.Instance.CreatFolderLibraryImageDrawnCurve();

            // Khởi tạo SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Đặt đường dẫn ban đầu cho SaveFileDialog
            saveFileDialog.InitialDirectory = savePath; // Thay đổi đường dẫn thành thư mục cha đã có path của bạn

            // Đặt các tùy chọn khác cho SaveFileDialog nếu cần

            // Mở SaveFileDialog và xử lí kết quả
            saveFileDialog.Filter = "JPEG Image|*.jpg";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            // Người dùng đã chọn vị trí để lưu tập tin, bạn có thể xử lí vị trí và lưu tập tin tại đây
            string selectedFilePath = saveFileDialog.FileName;
            // Thêm phần mở rộng ".jpg" vào tên file nếu nó chưa có
            if (!selectedFilePath.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
            {
                selectedFilePath += ".jpg";
            }

            // Tiếp tục xử lí và lưu tập tin...
            snipBitmap.Save(selectedFilePath);

            // Lấy tên file từ đường dẫn đầy đủ
            string fileName = Path.GetFileName(selectedFilePath);
            MessageBox.Show("Save Image " + fileName + " Success!");

            //Refresh TreeView
            this._frmCapstone.LoadDataTreeView();
        }

        #endregion Print_Click

        #region Check_Box

        private void chkManyCurve_CheckStateChanged(object sender, EventArgs e)
        {
            bool ManyChecked = this.chkManyCurve.Checked;
            this.chkOneCurve.Checked = !ManyChecked;
            this.ProcessCountDrawn();

        }

        private void chkOneCurve_CheckStateChanged(object sender, EventArgs e)
        {
            bool OneChecked = this.chkOneCurve.Checked;
            this.chkManyCurve.Checked = !OneChecked;
            this.ProcessCountDrawn();
        }

        protected virtual void ProcessCountDrawn()
        {
            this.isOneCurve = this.chkOneCurve.Checked;
            this.txtCountCurve.Text = (this.isOneCurve) ? "1" : "100";
            this.txtMinPer.Text = (this.isOneCurve) ? "100" : "30";
        }

        #endregion Check_Box

        #region TextBoxLeave
        private void txtCountCurve_Leave(object sender, EventArgs e)
        {
            TextBox txtDataChanged = sender as TextBox;

            bool isNumber = double.TryParse(txtDataChanged.Text, out double result);
            if (!isNumber || result == 0)
            {
                this.CallMessageBox(txtDataChanged);
                return;
            }

            if (txtDataChanged == this.txtMinPointRandom || txtDataChanged == this.txtMaxPointRandom)
            {
                double minRandom = double.Parse(this.txtMinPointRandom.Text);
                double maxRandom = double.Parse(this.txtMaxPointRandom.Text);

                if (minRandom > maxRandom)
                {
                    this.CallMessageBox(txtDataChanged);
                    return;
                }
            }

            txtDataChanged.BackColor = Color.WhiteSmoke;

        }

        protected virtual void CallMessageBox(TextBox txtDataChanged)
        {
            MessageBox.Show("Bạn hãy xem xét lại số vừa nhập !", "Số Không Hợp Lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtDataChanged.BackColor = Color.Yellow;
        }
        #endregion TextBoxLeave


    }
}
