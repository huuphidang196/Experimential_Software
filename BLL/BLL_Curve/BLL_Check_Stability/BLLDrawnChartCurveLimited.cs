
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using Experimential_Software.DTO;
using Experimential_Software.DAO.DAO_Curve;

namespace Experimential_Software.BLL.BLL_Curve.BLL_Check_Stability
{
    public class BLLDrawnChartCurveLimited
    {
        private static BLLDrawnChartCurveLimited _instance;
        public static BLLDrawnChartCurveLimited Instance
        {
            get { if (_instance == null) _instance = new BLLDrawnChartCurveLimited(); return _instance; }
            private set { }
        }

        private BLLDrawnChartCurveLimited() { }

        public void AddListPointPowerSystemFoundOnChart(Chart chartCurveLimted, List<PowerSystem> list_PS_Point, int numberSeries, bool isOneCurve, ConnectableE busLoadExamined)
        {
            string nameData = "Data" + numberSeries;
            chartCurveLimted.Series.Add(nameData); // Thêm một chuỗi dữ liệu mới với tên là "Data"

            foreach (PowerSystem point in list_PS_Point)
            {
                chartCurveLimted.Series[nameData].Points.AddXY(point.Q_ReactivePower, point.P_ActivePower); // Thêm từng điểm vào chuỗi dữ liệu "Data"
            }

            chartCurveLimted.Series[nameData].ChartType = SeriesChartType.Line;
            chartCurveLimted.Series[nameData].Color = Color.Blue;

            //Add point P, Q at Load connect bus considered
            if (isOneCurve)
            {
                PowerSystem power_Load = this.GetPowerSystemFromRandomValueLoad(busLoadExamined);
                this.AddPointLoadOnChart(chartCurveLimted, power_Load, isOneCurve);
            }
        }


        //Add point P, Q at Load connect bus considered
        public virtual void AddPointLoadOnChart(Chart chartCurveLimted, PowerSystem power_Load, bool isOneCurve)
        {
            string nameSeri = "PointLoad";
            chartCurveLimted.Series.Add(nameSeri);
            chartCurveLimted.Series[nameSeri].Color = Color.Red;
            //set type seri
            chartCurveLimted.Series[nameSeri].ChartType = SeriesChartType.Line;

            //Add O Point
            chartCurveLimted.Series[nameSeri].Points.Add(new DataPoint(0, 0));
            //Ad Point Circle
            this.AddPointCircleOnChart(chartCurveLimted, power_Load, nameSeri, isOneCurve);

        }

        public virtual void AddPointCircleOnChart(Chart chartCurveLimted, PowerSystem power_Load, string nameSeri, bool isOnCurve)
        {
            //Set Color Point and Radius point display
            DataPoint point_Load = new DataPoint(power_Load.Q_ReactivePower, power_Load.P_ActivePower);
            chartCurveLimted.Series[nameSeri].Points.Add(point_Load);

            //Many Curve Mode and Seri count point > 2 (O, M3) return
            if (!isOnCurve && chartCurveLimted.Series[nameSeri].Points.Count > 2) return;

            point_Load.MarkerColor = Color.Red;
            point_Load.MarkerStyle = MarkerStyle.Circle;
            point_Load.MarkerSize = 10;

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

        }

        public virtual PowerSystem GetPowerSystemFromRandomValueLoad(ConnectableE busLoadExamined)
        {
            double PLoad = this.GetDTOLoadConectWithBusConsider(busLoadExamined).PLoad;
            double QLoad = this.GetDTOLoadConectWithBusConsider(busLoadExamined).QLoad;
            return new PowerSystem(PLoad, QLoad);
        }

        protected virtual DTOLoadEPower GetDTOLoadConectWithBusConsider(ConnectableE busLoadExamined)
        {
            ConnectableE ePower_load = DAOGetDataOfEPower.Instance.GetEPowerPLoadFromEPowerBusLoadConsider(busLoadExamined);
            return ePower_load.DatabaseE.DataRecordE.DTOLoadEPower;
        }


    }
}
