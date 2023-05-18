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


        private PointF? FindIntersection(Series series1, Series series2)
        {
            for (int i = 0; i < series1.Points.Count - 1; i++)
            {
                PointF p1 = new PointF((float)series1.Points[i].XValue, (float)series1.Points[i].YValues[0]);
                PointF p2 = new PointF((float)series1.Points[i + 1].XValue, (float)series1.Points[i + 1].YValues[0]);

                for (int j = 0; j < series2.Points.Count - 1; j++)
                {
                    PointF p3 = new PointF((float)series2.Points[j].XValue, (float)series2.Points[j].YValues[0]);
                    PointF p4 = new PointF((float)series2.Points[j + 1].XValue, (float)series2.Points[j + 1].YValues[0]);

                    // Sử dụng phương trình đường thẳng để kiểm tra xem hai đường thẳng có giao nhau không
                    PointF? intersection = GetIntersection(p1, p2, p3, p4);
                    if (intersection.HasValue)
                    {
                        return intersection.Value;
                    }
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

            // Kiểm tra xem điểm giao nằm trong đoạn thẳng hay không
            if (ua >= 0 && ua <= 1 && ub >= 0 && ub <= 1)
            {
                float intersectionX = p1.X + ua * (p2.X - p1.X);
                float intersectionY = p1.Y + ua * (p2.Y - p1.Y);
                return new PointF(intersectionX, intersectionY);
            }

            return null; // Hai đường thẳng không giao nhau
        }

    }
}
