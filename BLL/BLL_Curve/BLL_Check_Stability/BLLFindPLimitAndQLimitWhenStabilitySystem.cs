using Experimential_Software.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Experimential_Software.BLL.BLL_Curve.BLL_Check_Stability
{
    public class BLLFindPLimitAndQLimitWhenStabilitySystem
    {
        private static BLLFindPLimitAndQLimitWhenStabilitySystem _instance;
        public static BLLFindPLimitAndQLimitWhenStabilitySystem Instance
        {
            get { if (_instance == null) _instance = new BLLFindPLimitAndQLimitWhenStabilitySystem(); return _instance; }
            private set { }
        }

        private BLLFindPLimitAndQLimitWhenStabilitySystem() { }

        public virtual void FindPLimitAndQLimitWhenStabilitySystem(Chart chartCurveLimted, bool isOneCurve)
        {
            //Check if Count PointSeries < 3 <=> not stability Not Drawn, O, M0, Mlimit
            if (chartCurveLimted.Series["PointLoad"].Points.Count < 3) return;

            string nameSeri = "PointPQLimit";
            chartCurveLimted.Series.Add(nameSeri);
            chartCurveLimted.Series[nameSeri].Color = Color.DarkOrange;
            //set type seri
            chartCurveLimted.Series[nameSeri].ChartType = SeriesChartType.Line;

            //Find Qgh
            PointF? qGH_SectionLimit = BLLCheckStability.Instance.FindInterSectionQGHLimtOnCurve(chartCurveLimted.Series["Data1"], chartCurveLimted.Series["PointLoad"], isOneCurve);
            if (qGH_SectionLimit != null)
            {
                PowerSystem pointQGHLimit = new PowerSystem(qGH_SectionLimit.Value.Y, qGH_SectionLimit.Value.X);
                BLLDrawnChartCurveLimited.Instance.AddPointCircleOnChart(chartCurveLimted, pointQGHLimit, "PointPQLimit", isOneCurve);
                chartCurveLimted.Series["PointPQLimit"].Points[0].Label = $"(Qgh = {qGH_SectionLimit.Value.X})";
            }
            //Add M(p0,Q0)
            DataPoint dataM0 = chartCurveLimted.Series["PointLoad"].Points[1];
            PowerSystem pointM0 = new PowerSystem(dataM0.YValues[0], dataM0.XValue);
            BLLDrawnChartCurveLimited.Instance.AddPointCircleOnChart(chartCurveLimted, pointM0, "PointPQLimit", isOneCurve);
            int numberM0 = chartCurveLimted.Series["PointPQLimit"].Points.Count - 1;
            chartCurveLimted.Series["PointPQLimit"].Points[numberM0].Label = $"M0";

            //Find Pgh
            PointF? pGH_SectionLimit = BLLCheckStability.Instance.FindInterSectionPGHLimtOnCurve(chartCurveLimted.Series["Data1"], chartCurveLimted.Series["PointLoad"], isOneCurve);
            if (pGH_SectionLimit != null)
            {
                PowerSystem pointPGHLimit = new PowerSystem(pGH_SectionLimit.Value.Y, pGH_SectionLimit.Value.X);
                BLLDrawnChartCurveLimited.Instance.AddPointCircleOnChart(chartCurveLimted, pointPGHLimit, "PointPQLimit", isOneCurve);
                int numberPgh = chartCurveLimted.Series["PointPQLimit"].Points.Count - 1;
                chartCurveLimted.Series["PointPQLimit"].Points[numberPgh].Label = $"(Pgh = {pGH_SectionLimit.Value.Y})";

            }

        }
    }
}
