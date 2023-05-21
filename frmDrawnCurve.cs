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

        public frmDrawnCurve()
        {
            InitializeComponent();
        }

        private void frmDrawnCurve_Load(object sender, EventArgs e)
        {
            if (this._busLoadExamined != null)
            {
                this.ShowDataOnForm();
                this.SetValueStartForChart();
            }
        }

        protected virtual void ShowDataOnForm()
        {
            lblNumberBusLoad.Text = (this._busLoadExamined.DatabaseE.DataRecordE.DTOBusEPower.ObjectNumber - 100 * (int)ObjectType.Bus) + "";

            this.lblCmdReset.Visible = true;
            this.lblProgress.Visible = false;

        }

        protected virtual void SetValueStartForChart()
        {
            this.chartCurveLimted.Titles.Add("Miền làm việc ổn định trong mặt phẳng công suất P-Q");
            this.chartCurveLimted.Titles[0].Font = new Font("Tohoma", 11, FontStyle.Bold);
            this.chartCurveLimted.Titles[0].ForeColor = Color.Black;

            // Ẩn phần chú thích mặc định của Chart
            this.chartCurveLimted.Legends.Clear();
        }

        #region Button_Reset_Event

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (this._busLoadExamined == null)
            {
                MessageBox.Show("You must select one Bus is considered!");
                this.Close();
                return;
            }

            //Process Chart and ListBox
            this.ProcessDrawnChartCurveLimited();

            //Processing completed event
            this.ProcessingCompletedEvent();


        }

        private void btnReset_MouseDown(object sender, MouseEventArgs e)
        {
            this.pnlProgress.Visible = true;
            this.lblCmdReset.Visible = false;

            this.lblProgress.Text = "Program is Processing ...";
            this.lblProgress.Visible = true;
        }
        #endregion Button_Reset_Event


        protected virtual void ProcessDrawnChartCurveLimited()
        {
            List<PowerSystem> List_PS_Point = DAOGenerateListPoints.Instance.GenerateListPointStabilityLimitCurve(this._allEPowers, this._busLoadExamined);
            if (List_PS_Point.Count == 0)
            {
                MessageBox.Show("Please consider this Database !", "Remider notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.ProcessPowerLimitOnListBox(List_PS_Point);

            //Drawn Curve
            this.DrawnChartCurveLimited(List_PS_Point);

            //Find Point Limit On Curve
            this.CheckStabilitySystem();

        }

        protected virtual void CheckStabilitySystem()
        {
            PointF? pSectionLimit = DAOCheckStability.Instance.FindIntersection(this.chartCurveLimted.Series["Data"], this.chartCurveLimted.Series["PointLoad"]);
            if (pSectionLimit == null)
            {
                this.lblStateSystem.Text = "Hệ thống không ổn định";
                return;
            }

            PowerSystem pointLimitOnCurve = new PowerSystem(pSectionLimit.Value.Y, pSectionLimit.Value.X);
            this.AddPointCircleOnChart(pointLimitOnCurve, "PointLoad");
            this.lblStateSystem.Text = "Hệ thống dang làm việc ổn định";

        }


        //ListBox P, Q
        protected virtual void ProcessPowerLimitOnListBox(List<PowerSystem> List_PS_Point)
        {

            foreach (PowerSystem ps in List_PS_Point)
            {
                this.lstBoxExperPoint.Items.Add("(P =  " + Math.Round(ps.P_ActivePower, 4) + ", Q = " + Math.Round(ps.Q_ReactivePower, 4));
            }
        }

        #region Drawn_Chart_Curve
        //Drawn
        private void DrawnChartCurveLimited(List<PowerSystem> list_PS_Point)
        {
            this.SetLimtValueChartAndPerUnit(list_PS_Point);

            //Add list point on Chart
            this.AddListPointPowerSystemFoundOnChart(list_PS_Point);
            //Add point P, Q at Load connect bus considered
            this.AddPointLoadOnChart();
        }

        //limte value and per unit value
        protected virtual void SetLimtValueChartAndPerUnit(List<PowerSystem> list_PS_Point)
        {
            double Pmax = list_PS_Point.Max(P => P.P_ActivePower);
            double Qmax = list_PS_Point.Max(Q => Q.Q_ReactivePower);
            // Thiết lập giới hạn của trục X từ 0 đến max + 10
            this.chartCurveLimted.ChartAreas[0].AxisX.Minimum = 0;
            this.chartCurveLimted.ChartAreas[0].AxisX.Maximum = Qmax + 50;

            // Thiết lập giới hạn của trục Y từ -5 đến 5
            this.chartCurveLimted.ChartAreas[0].AxisY.Minimum = 0;
            this.chartCurveLimted.ChartAreas[0].AxisY.Maximum = Pmax + 100;

            // Thiết lập khoảng cách giữa các ô chia trên trục X là 1 đơn vị
            this.chartCurveLimted.ChartAreas[0].AxisX.Interval = 50;

            // Thiết lập khoảng cách giữa các ô chia trên trục Y là 0.5 đơn vị
            this.chartCurveLimted.ChartAreas[0].AxisY.Interval = 50;

        }

        protected void AddListPointPowerSystemFoundOnChart(List<PowerSystem> list_PS_Point)
        {
            this.chartCurveLimted.Series.Clear(); // Xóa hết các chuỗi dữ liệu có sẵn trên Chart
            this.chartCurveLimted.Series.Add("Data"); // Thêm một chuỗi dữ liệu mới với tên là "Data"

            foreach (PowerSystem point in list_PS_Point)
            {
                this.chartCurveLimted.Series["Data"].Points.AddXY(point.Q_ReactivePower, point.P_ActivePower); // Thêm từng điểm vào chuỗi dữ liệu "Data"
            }

            this.chartCurveLimted.ChartAreas[0].AxisX.Title = "Q (Mvar)"; // Đặt tên cho trục X
            this.chartCurveLimted.ChartAreas[0].AxisY.Title = "P (MW)"; // Đặt tên cho trục Y

            this.chartCurveLimted.Series["Data"].ChartType = SeriesChartType.Line;
        }

        //Add point P, Q at Load connect bus considered
        protected virtual void AddPointLoadOnChart()
        {
            string nameSeri = "PointLoad";
            this.chartCurveLimted.Series.Add(nameSeri);
            this.chartCurveLimted.Series[nameSeri].Color = Color.Black;
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

        protected virtual void ProcessingCompletedEvent()
        {
            this.pnlProgress.Visible = false;

            // Initialize SoundPlayer
            SoundPlayer player = new SoundPlayer("E:/Code_Visual/Sound/Sound_Completed.wav");

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


        //*********Experimental => Remove when complete**************
        private string ExperimentalYState(List<ConnectableE> allEPowers)
        {
            //Get List All Bus from AllEPowers
            List<ConnectableE> allBus = allEPowers.FindAll(x => x.DatabaseE.ObjectType == ObjectType.Bus);
            //Sort List All Bus by ObjNumber
            allBus.Sort(new BusEPowerComparer());

            string s = "";
            Complex[,] YState = DAOGenerateYState.Instance.CalculateMatrixYState(allBus);
            for (int i = 0; i < YState.GetLength(0); i++)
            {
                for (int j = 0; j < YState.GetLength(1); j++)
                {
                    s += YState[i, j] + new string(' ', 5);
                }
                s += "\n";
            }
            return s;

        }


    }
}
