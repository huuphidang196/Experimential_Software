﻿using System;
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

using Experimential_Software.Class_Database;
using Experimential_Software.DAO.DAO_Curve.DAO_Calculate;
using Experimential_Software.DAO.DAO_Curve.DAO_Check_Stability;
using Experimential_Software.DAO.DAO_Curve.DAO_Calculate_ManyCurve;
using Experimential_Software.DAO.DAO_Curve.DAO_GeneratePath;

namespace Experimential_Software
{
    public partial class frmDrawnCurve : Form
    {
        protected List<ConnectableE> _allEPowers;
        public List<ConnectableE> AllEPowers { get => _allEPowers; set => _allEPowers = value; }

        // Bus Examinate connect with Load
        protected ConnectableE _busLoadExamined;
        public ConnectableE BusLoadExamnined { get => _busLoadExamined; set => _busLoadExamined = value; }
        public object FindIntersection { get; private set; }

        // Góc alpha (đơn vị: độ)
        protected float _alpha = -145; // Góc xoay 45 độ (ví dụ)
        protected float _perRotTen = 24;

        protected bool isOneCurve = true;
        protected double _maxPpre = 100;
        protected double _maxQpre = 100;

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
            this.chartCurveLimted.ChartAreas[0].AxisX.Maximum = this._maxQpre + 50;

            //// Thiết lập giới hạn của trục Y từ -5 đến
            this.chartCurveLimted.ChartAreas[0].AxisY.Minimum = 0;
            this.chartCurveLimted.ChartAreas[0].AxisY.Maximum = this._maxPpre + 100;


            // Thiết lập khoảng cách giữa các ô chia trên trục X là 1 đơn vị
            this.chartCurveLimted.ChartAreas[0].AxisX.Interval = 50;

            // Thiết lập khoảng cách giữa các ô chia trên trục Y là 0.5 đơn vị
            this.chartCurveLimted.ChartAreas[0].AxisY.Interval = 50;

            this.chartCurveLimted.ChartAreas[0].AxisX.Title = "Q (Mvar)"; // Đặt tên cho trục X
            this.chartCurveLimted.ChartAreas[0].AxisY.Title = "P (MW)"; // Đặt tên cho trục Y
        }

        #endregion Form_Load

        #region Picture_Box_Wise
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Tâm của tam giác
            float centerX = 60;
            float centerY = 60;

            // Kích thước cạnh tam giác
            float sideLength = 35;
            float sideLengthScaled = (float)(sideLength * Math.Sqrt(2));

            // Tạo ma trận biến đổi để xoay tam giác và hình vuông
            Matrix transformationMatrix = new Matrix();
            transformationMatrix.RotateAt(_alpha, new PointF(centerX, centerY));

            // Đỉnh tam giác
            PointF[] trianglePoints = new PointF[]
            {
        new PointF(centerX, centerY - sideLengthScaled / 2),
        new PointF(centerX + sideLengthScaled / 2, centerY ),
        new PointF(centerX - sideLengthScaled / 2, centerY)
            };

            // Áp dụng biến đổi vào đỉnh tam giác
            transformationMatrix.TransformPoints(trianglePoints);

            // Vẽ tam giác
            g.FillPolygon(Brushes.Brown, trianglePoints);

            // Tạo hình vuông dính vào cạnh đáy của tam giác
            PointF bottomLeft = trianglePoints[2];

            // Kích thước cạnh hình vuông
            float squareSize = sideLengthScaled;

            // Tạo ma trận biến đổi cho hình vuông
            Matrix squareTransformationMatrix = new Matrix();
            squareTransformationMatrix.RotateAt(_alpha, bottomLeft);

            // Đỉnh hình vuông
            PointF[] squarePoints = new PointF[]
            {
        bottomLeft,
        new PointF(bottomLeft.X + squareSize, bottomLeft.Y),
        new PointF(bottomLeft.X + squareSize, bottomLeft.Y + squareSize),
        new PointF(bottomLeft.X, bottomLeft.Y + squareSize)
            };

            // Áp dụng biến đổi vào đỉnh hình vuông
            squareTransformationMatrix.TransformPoints(squarePoints);

            // Vẽ hình vuông
            g.FillPolygon(Brushes.Orange, squarePoints);

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
            Dictionary<string, PowerSystem> Dic_PQ_Old = DAOCalculateManyCurve.Instance.GetDictionaryPowerSystemOld(this._allEPowers);

            for (int i = 0; i < toltalCount; i++)
            {
                //Reccify PLoad, QLoad All Load
                this._allEPowers = DAOCalculateManyCurve.Instance.RecifyAllPowerSystemLoad(this._allEPowers, Dic_PQ_Old, rateMin, rateMax);
                //Process Chart and ListBox
                this.ProcessDrawnChartCurveLimited(i + 1);
            }
            //Set label Stability
            if (!this.isOneCurve) this.SetLabelStablityAndProbility(null);

            //Processing completed event
            this.ProcessingCompletedEvent(Dic_PQ_Old);

            // Thực hiện các tác vụ hoặc đoạn code khác trong Window Form

            stopwatch.Stop();
            TimeSpan duration = stopwatch.Elapsed;
            MessageBox.Show("Time = " + string.Format("{0}:{1:D2}", duration.Minutes, duration.Seconds));
        }

        protected virtual void SetVariableWhenResetPressed()
        {
            this._alpha = -145;
            this.ptbClockWise.Invalidate();
            this.lblKPghRatio.Text = "P0 / PGh = 0 %";


            this.chartCurveLimted.Series.Clear();
            this._maxPpre = this._maxQpre = 100;

            this.lstBoxExperPoint.Items.Clear();
        }

        protected virtual void AddPointLoadRandomInManyCurveUnit()
        {
            if (this.isOneCurve) return;

            PowerSystem psLoad = DAODrawnChartCurveLimited.Instance.GetPowerSystemFromRandomValueLoad(this._busLoadExamined);
            double rateMLimit_Min = double.Parse(this.txtMinPointRandom.Text) / 100;
            double rateMLimit_Max = double.Parse(this.txtMaxPointRandom.Text) / 100;

            PowerSystem psM_Random = DAOCalculateManyCurve.Instance.GetValueRandomInTheRange(psLoad, rateMLimit_Min, rateMLimit_Max);
            DAODrawnChartCurveLimited.Instance.AddPointLoadOnChart(this.chartCurveLimted, psM_Random, this.isOneCurve);
        }

        #endregion Button_Reset_Event


        #region Process_Chart_Curve
        protected virtual void ProcessDrawnChartCurveLimited(int numberSeries)
        {
            List<PowerSystem> List_PS_Point = DAOGenerateListPoints.Instance.GenerateListPointStabilityLimitCurve(this._allEPowers, this._busLoadExamined);
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
            PointF? pSectionLimit = DAOCheckStability.Instance.FindInterSectionPQLimtOnCurve(this.chartCurveLimted.Series[nameData], this.chartCurveLimted.Series["PointLoad"], this.isOneCurve);

            if (pSectionLimit == null) return;//Only many Mode 

            PowerSystem pointLimitOnCurve = new PowerSystem(pSectionLimit.Value.Y, pSectionLimit.Value.X);
            //set type seri
            this.chartCurveLimted.Series["PointLoad"].ChartType = SeriesChartType.Line;
            DAODrawnChartCurveLimited.Instance.AddPointCircleOnChart(this.chartCurveLimted, pointLimitOnCurve, "PointLoad", this.isOneCurve);

            if (!this.isOneCurve)
            {
                this.AddPerElementOnListBox(pointLimitOnCurve);
                return;
            }
            //Set label Stability
            this.SetLabelStablityAndProbility(pSectionLimit);


        }

        //Label Stability One Curve Mode
        protected virtual void SetLabelStablityAndProbility(PointF? pSectionLimit)
        {
            string str_Stability = (this.isOneCurve) ? DAOCheckStability.Instance.GetStringStabilityByOffSetOneCurveMode(pSectionLimit, this.chartCurveLimted.Series["PointLoad"])
                : DAOCheckStability.Instance.GetStringStabilityByCountSectionManyCurveMode(this.chartCurveLimted.Series["PointLoad"], double.Parse(this.txtCountCurve.Text));

            string str_Probility = (this.isOneCurve) ? DAOCheckStability.Instance.GetStringProbilitySystemByOffSetOneCurveMode(pSectionLimit, this.chartCurveLimted.Series["PointLoad"])
                : DAOCheckStability.Instance.GetStringProbilityByCountSectionManyCurveMode(this.chartCurveLimted.Series["PointLoad"], double.Parse(this.txtCountCurve.Text));

            this.lblStateSystem.Text = str_Stability;
            this.txtPerProbility.Text = str_Probility;
        }

        protected virtual void FindPLimitAndQLimitWhenStabilitySystem()
        {
            DAOFindPLimitAndQLimitWhenStabilitySystem.Instance.FindPLimitAndQLimitWhenStabilitySystem(this.chartCurveLimted, this.isOneCurve);
        }

        //ListBox P, Q
        protected virtual void ProcessPowerLimitOnListBox(List<PowerSystem> List_PS_Point)
        {
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

            Percent = Math.Min(Percent, 120);

            this._alpha += (this._perRotTen * (float)Percent / 10);
            this.ptbClockWise.Invalidate();
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
            if (numberSeries > 1) return;

            double Pmax = list_PS_Point.Max(S => S.P_ActivePower);
            double Qmax = list_PS_Point.Max(S => S.Q_ReactivePower);

            this._maxPpre = Math.Max(Pmax, this._maxPpre);
            this._maxQpre = Math.Max(Qmax, this._maxQpre);

            // Thiết lập giới hạn của trục X từ 0 đến max + 10
            this.chartCurveLimted.ChartAreas[0].AxisX.Maximum = this._maxQpre + 300;

            //// Thiết lập giới hạn của trục Y từ -5 đến
            this.chartCurveLimted.ChartAreas[0].AxisY.Maximum = this._maxPpre + 300;

        }

        protected void AddListPointPowerSystemFoundOnChart(List<PowerSystem> list_PS_Point, int numberSeries)
        {
            DAODrawnChartCurveLimited.Instance.AddListPointPowerSystemFoundOnChart(this.chartCurveLimted, list_PS_Point, numberSeries, this.isOneCurve, this._busLoadExamined);
        }

        protected virtual void ProcessingCompletedEvent(Dictionary<string, PowerSystem> Dic_PQ_Old)
        {
            this.pnlProgress.Visible = false;

            //Save Old Power Load
            this._allEPowers = DAOCalculateManyCurve.Instance.ReturnAllPowerSystemLoadOrigin(this._allEPowers, Dic_PQ_Old);

            //Creat folder Library Sound
            string pathSound = DAOGeneratePathFolder.Instance.CreatFolderLibrarySound();
            SoundPlayer player = new SoundPlayer(pathSound);

            //Play Sound
            player.Play();
        }

        #endregion Drawn_Chart_Curve

        //Button Close event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            string savePath = DAOGeneratePathFolder.Instance.CreatFolderLibraryImageDrawnCurve();

            //Open Form Name Image
            frmNameImagePrint frmNameImage = new frmNameImagePrint();
            frmNameImage.ShowDialog();
            if (frmNameImage.DialogResult != DialogResult.OK) return;

            string fileName = (frmNameImage.NameImage != "") ? frmNameImage.NameImage + ".jpg" : "Image_Drawn" + int.Parse(this.txtCountCurve.Text) + "Curve.jpg";
            string filePath = Path.Combine(savePath, fileName); // Kết hợp đường dẫn thư mục và tên tệp tin

            snipBitmap.Save(filePath); // Lưu đối tượng Image vào đường dẫn đã xác định

            // Hiển thị thông báo khi hoàn tất snip ảnh
            MessageBox.Show("Save Image " + fileName + " Success!");
            DialogResult = DialogResult.Yes;
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
