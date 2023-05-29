using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Experimential_Software.DAO.DAO_Curve.DAO_Check_Stability
{
    public class DAOCheckStability
    {
        private static DAOCheckStability _instance;
        public static DAOCheckStability Instance
        {
            get { if (_instance == null) _instance = new DAOCheckStability(); return _instance; }
            private set { }
        }

        private DAOCheckStability() { }

        public virtual PointF? FindInterSectionPQLimtOnCurve(Series series_Curve, Series Series_PointM)
        {
            //Get Intersect M' On curve
            PointF p1 = new PointF(0, 0);
            PointF p2 = new PointF((float)Series_PointM.Points[1].XValue, (float)Series_PointM.Points[1].YValues[0]);

            return this.FindIntersection(series_Curve, p1, p2);
        }

        //PGh
        public virtual PointF? FindInterSectionPGHLimtOnCurve(Series series_Curve, Series Series_PointM)
        {
            //Get Intersect M' On curve
            PointF p1 = new PointF((float)Series_PointM.Points[1].XValue, 0);//Qo
            PointF p2 = new PointF((float)Series_PointM.Points[1].XValue, (float)Series_PointM.Points[1].YValues[0]);//M(P0,Q0)

            return this.FindIntersection(series_Curve, p1, p2);
        }

        //QGH
        public virtual PointF? FindInterSectionQGHLimtOnCurve(Series series_Curve, Series Series_PointM)
        {
            //Get Intersect M' On curve
          //  PointF p1 = new PointF(0, (float)Series_PointM.Points[1].YValues[0]);//Po
            PointF p1 = new PointF((float)Series_PointM.Points[1].XValue, (float)Series_PointM.Points[1].YValues[0]);//M(P0,Q0)
            PointF p2 = new PointF((float)Series_PointM.Points[1].XValue + 0.001f, (float)Series_PointM.Points[1].YValues[0]);//M(P0,Q0)
            return this.FindIntersection(series_Curve, p1, p2);
        }
        public virtual PointF? FindIntersection(Series series_Curve, PointF p1, PointF p2)
        {
            for (int i = series_Curve.Points.Count - 1; i > 0; i--)
            {
                PointF p3 = new PointF((float)series_Curve.Points[i].XValue, (float)series_Curve.Points[i].YValues[0]);
                PointF p4 = new PointF((float)series_Curve.Points[i - 1].XValue, (float)series_Curve.Points[i - 1].YValues[0]);

                // Sử dụng phương trình đường thẳng để kiểm tra xem hai đường thẳng có giao nhau không
                PointF? intersection = GetIntersection(p1, p2, p3, p4);
                if (intersection.HasValue)
                {
                    float roundedX = (float)Math.Round(intersection.Value.X, 2);
                    float roundedY = (float)Math.Round(intersection.Value.Y, 2);
                    PointF? roundedIntersection = new PointF(roundedX, roundedY);

                    return roundedIntersection.Value;
                }
            }

            return null;
        }

        private PointF? GetIntersection(PointF p1, PointF p2, PointF p3, PointF p4)
        {
            float denominator = (p4.Y - p3.Y) * (p2.X - p1.X) - (p4.X - p3.X) * (p2.Y - p1.Y);

            // Kiểm tra xem hai đường thẳng có song song hay không
            if (denominator == 0)
            {
                return null; // Hai đường thẳng không giao nhau
            }

            float ua = ((p4.X - p3.X) * (p1.Y - p3.Y) - (p4.Y - p3.Y) * (p1.X - p3.X)) / denominator;
            float ub = ((p2.X - p1.X) * (p1.Y - p3.Y) - (p2.Y - p1.Y) * (p1.X - p3.X)) / denominator;

            // Kiểm tra xem điểm giao nằm trong đoạn thẳng hay không, Dối với OM thì nếu ổn đinh giao sẽ nẳm ngoài OM <=> ua > 1. <1 tức ko ổn định vì 
            //giao điểm nằm trong OM hoặc dưỡi OM tức M > limit Value
            if ( ub >= 0 && ub <= 1)
            {
                if (ua <= 0) return null;

                float intersectionX = p1.X + ua * (p2.X - p1.X);
                float intersectionY = p1.Y + ua * (p2.Y - p1.Y);
                return new PointF(intersectionX, intersectionY);
            }

            return null; // Hai đường thẳng không giao nhau
        }

    }
}
