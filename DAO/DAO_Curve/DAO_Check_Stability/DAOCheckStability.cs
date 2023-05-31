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

        public virtual PointF? FindInterSectionPQLimtOnCurve(Series series_Curve, Series Series_PointM, bool isOneCurve)
        {
            //Get Intersect M' On curve
            PointF p1 = new PointF(0, 0);
            PointF p2 = new PointF((float)Series_PointM.Points[1].XValue, (float)Series_PointM.Points[1].YValues[0]);

            return this.FindIntersection(series_Curve, p1, p2, isOneCurve);
        }

        //PGh
        public virtual PointF? FindInterSectionPGHLimtOnCurve(Series series_Curve, Series Series_PointM, bool isOneCurve)
        {
            //Get Intersect M' On curve
            PointF p1 = new PointF((float)Series_PointM.Points[1].XValue, 0);//Qo
            PointF p2 = new PointF((float)Series_PointM.Points[1].XValue, (float)Series_PointM.Points[1].YValues[0]);//M(P0,Q0)

            return this.FindIntersection(series_Curve, p1, p2, isOneCurve);
        }

        //QGH
        public virtual PointF? FindInterSectionQGHLimtOnCurve(Series series_Curve, Series Series_PointM, bool isOneCurve)
        {
            //Get Intersect M' On curve
            //  PointF p1 = new PointF(0, (float)Series_PointM.Points[1].YValues[0]);//Po
            PointF p1 = new PointF((float)Series_PointM.Points[1].XValue, (float)Series_PointM.Points[1].YValues[0]);//M(P0,Q0)
            PointF p2 = new PointF((float)Series_PointM.Points[1].XValue + 0.001f, (float)Series_PointM.Points[1].YValues[0]);//M(P0,Q0)
            return this.FindIntersection(series_Curve, p1, p2, isOneCurve);
        }


        public virtual PointF? FindIntersection(Series series_Curve, PointF p1, PointF p2, bool isOneCurve)
        {
            for (int i = series_Curve.Points.Count - 1; i > 0; i--)
            {
                PointF p3 = new PointF((float)series_Curve.Points[i].XValue, (float)series_Curve.Points[i].YValues[0]);
                PointF p4 = new PointF((float)series_Curve.Points[i - 1].XValue, (float)series_Curve.Points[i - 1].YValues[0]);

                // Sử dụng phương trình đường thẳng để kiểm tra xem hai đường thẳng có giao nhau không
                PointF? intersection = GetIntersection(p1, p2, p3, p4, isOneCurve);
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

        private PointF? GetIntersection(PointF p1, PointF p2, PointF p3, PointF p4, bool isOneCurve)
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
            if (ub >= 0 && ub <= 1)
            {
                if (ua <= 0) return null;

                if (!isOneCurve && ua > 1) return null; //M3

                float intersectionX = p1.X + ua * (p2.X - p1.X);
                float intersectionY = p1.Y + ua * (p2.Y - p1.Y);
                return new PointF(intersectionX, intersectionY);
            }

            return null; // Hai đường thẳng không giao nhau
        }

        #region Get_String_Label

        #region One_Curve_Mode
        //stability One Curve Mode
        public virtual string GetStringStabilityByOffSetOneCurveMode(PointF? pSectionLimit, Series series_PointLoad)
        {
            string str_Stability = "";

            double _offset = this.GetOffSetOneCurveMode(pSectionLimit, series_PointLoad);

            if (_offset > 0) str_Stability = "Hệ thống đang làm việc ổn định";
            else if (_offset == 0) str_Stability = "Hệ thống đang làm việc trong vùng nguy hiểm";
            else str_Stability = "Hệ thống đã mất ổn định";

            return str_Stability;
        }

        //stability One Curve Mode
        public virtual string GetStringProbilitySystemByOffSetOneCurveMode(PointF? pSectionLimit, Series series_PointLoad)
        {
            string str_Probility = "";

            double _offset = this.GetOffSetOneCurveMode(pSectionLimit, series_PointLoad);

            if (_offset > 0) str_Probility = "0 %";
            else if (_offset == 0) str_Probility = "50%";
            else str_Probility = "100%";

            return str_Probility;
        }

        protected virtual double GetOffSetOneCurveMode(PointF? pSectionLimit, Series series_PointLoad)
        {
            DataPoint pLoad = series_PointLoad.Points[1];
            double _offset = Math.Round(pSectionLimit.Value.Y - pLoad.YValues[0], 0);//Compare P

            return _offset;
        }
        #endregion One_Curve_Mode

        #region Many_Curve_Mode
        //stability Many Curve Mode
        public virtual string GetStringStabilityByCountSectionManyCurveMode(Series series_PointLoad, double TotalCurve)
        {
            string str_Stability = "";
            double k_Stability = this.GetKRationManyCurveMode(series_PointLoad, TotalCurve);

            if (k_Stability == 0) str_Stability = "Hệ thống đang làm việc ổn định";
            else if (k_Stability == 1) str_Stability = "Hệ thống đã mất ổn định";
            else str_Stability = "Hệ thống đang làm việc trong vùng nguy hiểm";

            return str_Stability;
        }

        //Probility Many Curve Mode
        public virtual string GetStringProbilityByCountSectionManyCurveMode(Series series_PointLoad, double TotalCurve)
        {
            double k_Probility = this.GetKRationManyCurveMode(series_PointLoad, TotalCurve);
            string str_Probility = (100 * k_Probility) + " %";
            return str_Probility;
        }

        protected virtual double GetKRationManyCurveMode(Series series_PointLoad, double TotalCurve)
        {
            double countPSec = series_PointLoad.Points.Count - 2;// Subtract O, M3
            double k_Ratio = countPSec / TotalCurve;

            return k_Ratio;
        }
        #endregion Many_Curve_Mode

        #endregion Get_String_Label
    }
}
