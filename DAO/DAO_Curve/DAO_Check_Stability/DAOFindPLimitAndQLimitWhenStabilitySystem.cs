using Experimential_Software.Class_Database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Experimential_Software.DAO.DAO_Curve.DAO_Check_Stability
{
    public class DAOFindPLimitAndQLimitWhenStabilitySystem
    {
        private static DAOFindPLimitAndQLimitWhenStabilitySystem _instance;
        public static DAOFindPLimitAndQLimitWhenStabilitySystem Instance
        {
            get { if (_instance == null) _instance = new DAOFindPLimitAndQLimitWhenStabilitySystem(); return _instance; }
            private set { }
        }

        private DAOFindPLimitAndQLimitWhenStabilitySystem() { }

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
            PointF? qGH_SectionLimit = DAOCheckStability.Instance.FindInterSectionQGHLimtOnCurve(chartCurveLimted.Series["Data1"], chartCurveLimted.Series["PointLoad"], isOneCurve);
            if (qGH_SectionLimit != null)
            {
                PowerSystem pointQGHLimit = new PowerSystem(qGH_SectionLimit.Value.Y, qGH_SectionLimit.Value.X);
                DAODrawnChartCurveLimited.Instance.AddPointCircleOnChart(chartCurveLimted, pointQGHLimit, "PointPQLimit", isOneCurve);
                chartCurveLimted.Series["PointPQLimit"].Points[0].Label = $"(Qgh = {qGH_SectionLimit.Value.X})";
            }
            //Add M(p0,Q0)
            DataPoint dataM0 = chartCurveLimted.Series["PointLoad"].Points[1];
            PowerSystem pointM0 = new PowerSystem(dataM0.YValues[0], dataM0.XValue);
            DAODrawnChartCurveLimited.Instance.AddPointCircleOnChart(chartCurveLimted, pointM0, "PointPQLimit", isOneCurve);
            int numberM0 = chartCurveLimted.Series["PointPQLimit"].Points.Count - 1;
            chartCurveLimted.Series["PointPQLimit"].Points[numberM0].Label = $"M0";

            //Find Pgh
            PointF? pGH_SectionLimit = DAOCheckStability.Instance.FindInterSectionPGHLimtOnCurve(chartCurveLimted.Series["Data1"], chartCurveLimted.Series["PointLoad"], isOneCurve);
            if (pGH_SectionLimit != null)
            {
                PowerSystem pointPGHLimit = new PowerSystem(pGH_SectionLimit.Value.Y, pGH_SectionLimit.Value.X);
                DAODrawnChartCurveLimited.Instance.AddPointCircleOnChart(chartCurveLimted, pointPGHLimit, "PointPQLimit", isOneCurve);
                int numberPgh = chartCurveLimted.Series["PointPQLimit"].Points.Count - 1;
                chartCurveLimted.Series["PointPQLimit"].Points[numberPgh].Label = $"(Pgh = {pGH_SectionLimit.Value.Y})";

            }

        }
    }
}
