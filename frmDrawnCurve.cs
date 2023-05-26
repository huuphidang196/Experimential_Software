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
using Experimential_Software.Class_Database;
using Experimential_Software.DAO.DAO_Curve.DAO_Calculate;
using System.Windows.Forms.DataVisualization.Charting;
using Experimential_Software.CustomControl;
using System.Media;
using Experimential_Software.DAO.DAO_Curve.DAO_Check_Stability;
using System.Drawing.Drawing2D;
using Experimential_Software.DAO.DAO_Curve.DAO_Calculate_ManyCurve;
using System.Diagnostics;
using System.IO;

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

        #region Picture_Box
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
        #endregion Picture_Box

        #region Button_Reset_Event

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (this._busLoadExamined == null)
            {
                MessageBox.Show("You must select one Bus is considered!");
                this.Close();
                return;
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            this.chartCurveLimted.Series.Clear();
            this._maxPpre = this._maxQpre = 100;

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
            //Processing completed event
            this.ProcessingCompletedEvent(Dic_PQ_Old);

            // Thực hiện các tác vụ hoặc đoạn code khác trong Window Form

            stopwatch.Stop();
            TimeSpan duration = stopwatch.Elapsed;
            MessageBox.Show("Time = " + string.Format("{0}:{1:D2}", duration.Minutes, duration.Seconds));
        }

        private void btnReset_MouseDown(object sender, MouseEventArgs e)
        {
            this.pnlProgress.Visible = true;
            this.lblCmdReset.Visible = false;

            this.lblProgress.Text = "Program is Processing ...";
            this.lblProgress.Visible = true;
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

            if (!this.isOneCurve) return;

            this.ProcessPowerLimitOnListBox(List_PS_Point);

            //Find Point Limit On Curve
            this.CheckStabilitySystem();

            //Find Pgh Qgh
            this.FindPLimitAndQLimitWhenStabilitySystem();

        }

        protected virtual void CheckStabilitySystem()
        {
            PointF? pSectionLimit = DAOCheckStability.Instance.FindInterSectionPQLimtOnCurve(this.chartCurveLimted.Series["Data1"], this.chartCurveLimted.Series["PointLoad"]);
            if (pSectionLimit == null)
            {
                this.lblStateSystem.Text = "Hệ thống không ổn định";
                this.lblProbilityOfInstability.Text = "Xác suất mất ổn định : 100%";
                return;
            }

            PowerSystem pointLimitOnCurve = new PowerSystem(pSectionLimit.Value.Y, pSectionLimit.Value.X);
            this.AddPointCircleOnChart(pointLimitOnCurve, "PointLoad");

            DataPoint pLoad = this.chartCurveLimted.Series["PointLoad"].Points[1];
            this.lblStateSystem.Text = (pSectionLimit.Value.X == pLoad.XValue && pSectionLimit.Value.Y == pLoad.YValues[0]) ? " Hệ thống đang làm việc trên biên giới ổn định " : "Hệ thống đang làm việc ổn định";
            this.lblProbilityOfInstability.Text = (pSectionLimit.Value.X == pLoad.XValue && pSectionLimit.Value.Y == pLoad.YValues[0]) ? "Xác suất mất ổn định : 50%" : "Xác suất mất ổn định : 0%";


        }

        protected virtual void FindPLimitAndQLimitWhenStabilitySystem()
        {
            //Check if Count PointSeries < 3 <=> not stability Not Drawn
            if (this.chartCurveLimted.Series["PointLoad"].Points.Count < 3) return;

            string nameSeri = "PointPQLimit";
            this.chartCurveLimted.Series.Add(nameSeri);
            this.chartCurveLimted.Series[nameSeri].Color = Color.DarkOrange;

            //Find Qgh
            PointF? qGH_SectionLimit = DAOCheckStability.Instance.FindInterSectionQGHLimtOnCurve(this.chartCurveLimted.Series["Data1"], this.chartCurveLimted.Series["PointLoad"]);
            if (qGH_SectionLimit != null)
            {
                PowerSystem pointQGHLimit = new PowerSystem(qGH_SectionLimit.Value.Y, qGH_SectionLimit.Value.X);
                this.AddPointCircleOnChart(pointQGHLimit, "PointPQLimit");
                this.chartCurveLimted.Series["PointPQLimit"].Points[0].Label = $"(Qgh = {qGH_SectionLimit.Value.X})";
            }
            //Add M(p0,Q0)
            DataPoint dataM0 = this.chartCurveLimted.Series["PointLoad"].Points[1];
            PowerSystem pointM0 = new PowerSystem(dataM0.YValues[0], dataM0.XValue);
            this.AddPointCircleOnChart(pointM0, "PointPQLimit");
            this.chartCurveLimted.Series["PointPQLimit"].Points[1].Label = $"M0";

            //Find Pgh
            PointF? pGH_SectionLimit = DAOCheckStability.Instance.FindInterSectionPGHLimtOnCurve(this.chartCurveLimted.Series["Data1"], this.chartCurveLimted.Series["PointLoad"]);
            if (pGH_SectionLimit != null)
            {
                PowerSystem pointPGHLimit = new PowerSystem(pGH_SectionLimit.Value.Y, pGH_SectionLimit.Value.X);
                this.AddPointCircleOnChart(pointPGHLimit, "PointPQLimit");
                this.chartCurveLimted.Series["PointPQLimit"].Points[2].Label = $"(Pgh = {pGH_SectionLimit.Value.Y})";

                //Set Percent Stability
                this.SetClockWiseStaticReserveFactor();
            }
        }


        //ListBox P, Q
        protected virtual void ProcessPowerLimitOnListBox(List<PowerSystem> List_PS_Point)
        {

            foreach (PowerSystem ps in List_PS_Point)
            {
                this.lstBoxExperPoint.Items.Add("(P =  " + Math.Round(ps.P_ActivePower, 4) + ", Q = " + Math.Round(ps.Q_ReactivePower, 4));
            }
        }

        //Set ClockWise
        protected virtual void SetClockWiseStaticReserveFactor()
        {
            DataPoint pointPgh = this.chartCurveLimted.Series["PointPQLimit"].Points[2];

            double Pgh = pointPgh.YValues[0];

            DataPoint pointM0 = this.chartCurveLimted.Series["PointPQLimit"].Points[1];

            double P0 = pointM0.YValues[0];

            double Percent = 100 - (P0 / Pgh) * 100;

            this._alpha += (float)Percent;
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
            this.chartCurveLimted.ChartAreas[0].AxisX.Maximum = this._maxQpre + 400;

            //// Thiết lập giới hạn của trục Y từ -5 đến
            this.chartCurveLimted.ChartAreas[0].AxisY.Maximum = this._maxPpre + 400;

        }

        protected void AddListPointPowerSystemFoundOnChart(List<PowerSystem> list_PS_Point, int numberSeries)
        {
            string nameData = "Data" + numberSeries;
            this.chartCurveLimted.Series.Add(nameData); // Thêm một chuỗi dữ liệu mới với tên là "Data"

            foreach (PowerSystem point in list_PS_Point)
            {
                this.chartCurveLimted.Series[nameData].Points.AddXY(point.Q_ReactivePower, point.P_ActivePower); // Thêm từng điểm vào chuỗi dữ liệu "Data"
            }

            this.chartCurveLimted.Series[nameData].ChartType = SeriesChartType.Line;
            this.chartCurveLimted.Series[nameData].Color = Color.Blue;

            //Add point P, Q at Load connect bus considered
            if (this.isOneCurve) this.AddPointLoadOnChart();
        }

        //Add point P, Q at Load connect bus considered
        protected virtual void AddPointLoadOnChart()
        {
            string nameSeri = "PointLoad";
            this.chartCurveLimted.Series.Add(nameSeri);
            this.chartCurveLimted.Series[nameSeri].Color = Color.Red;
            PowerSystem power_Load = new PowerSystem(this.GetDTOLoadConectWithBusConsider().PLoad, this.GetDTOLoadConectWithBusConsider().QLoad);

            //Add O Point
            this.chartCurveLimted.Series[nameSeri].Points.Add(new DataPoint(0, 0));
            //Ad Point Circle
            this.AddPointCircleOnChart(power_Load, nameSeri);

        }

        protected virtual void AddPointCircleOnChart(PowerSystem power_Load, string nameSeri)
        {
            //Set Color Point and Radius point display
            DataPoint point_Load = new DataPoint(power_Load.Q_ReactivePower, power_Load.P_ActivePower);
            point_Load.MarkerColor = Color.Red;
            point_Load.MarkerStyle = MarkerStyle.Circle;
            point_Load.MarkerSize = 10;
            this.chartCurveLimted.Series[nameSeri].Points.Add(point_Load);

            // Ghi giá trị position vào bên cạnh điểm
            // Đặt định dạng chữ in đậm cho nhãn
            point_Load.Font = new Font(point_Load.Font, FontStyle.Bold);

            // Các thiết lập khác cho nhãn
            point_Load.LabelForeColor = Color.Black;
            point_Load.LabelBackColor = Color.SandyBrown;
            point_Load.LabelBorderColor = Color.Transparent;


            // Lấy tọa độ X và Y của điểm
            double x = Math.Round(point_Load.XValue, 3);
            double y = Math.Round(point_Load.YValues[0], 3); // Giả sử chỉ có một giá trị Y
            point_Load.Label = $"(P= {y},Q= {x})";
            point_Load.IsValueShownAsLabel = true;

            //set type seri
            this.chartCurveLimted.Series[nameSeri].ChartType = SeriesChartType.Line;
        }


        #endregion Drawn_Chart_Curve

        protected virtual void ProcessingCompletedEvent(Dictionary<string, PowerSystem> Dic_PQ_Old)
        {
            this.pnlProgress.Visible = false;

            //Save Old Power Load
            this._allEPowers = DAOCalculateManyCurve.Instance.ReturnAllPowerSystemLoadOrigin(this._allEPowers, Dic_PQ_Old);
            //Add point P, Q at Load connect bus considered
            if (!this.isOneCurve) this.AddPointLoadOnChart();

            // Initialize SoundPlayer
            string absolutePath = @"E:/Code_Visual/Experimential_Software/Library/Library_Sound/Sound_Completed.wav";
            string relativePath = Path.Combine(Application.StartupPath, Path.GetFileName(absolutePath));

            SoundPlayer player = new SoundPlayer("");

            //Play Sound
            player.Play();
        }

        protected virtual DTOLoadEPower GetDTOLoadConectWithBusConsider()
        {
            ConnectableE ePower_load = DAOCalculateQLJStepOne.Instance.GetEPowerPLoadFromEPowerBusLoadConsider(this._busLoadExamined);
            return ePower_load.DatabaseE.DataRecordE.DTOLoadEPower;
        }

        //Button Close event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region Print_Click
        private void btnPrint_Click(object sender, EventArgs e)
        {

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
            this.txtCountCurve.Text = (this.isOneCurve) ? "1" : "8760";
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
                MessageBox.Show("Bạn hãy xem xét lại số vừa nhập !", "Số Không Hợp Lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDataChanged.BackColor = Color.Yellow;
            }

            txtDataChanged.BackColor = Color.WhiteSmoke;

        }

        #endregion TextBoxLeave
    }
}
