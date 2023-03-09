using CustomDrawMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmallestEnclosingCircle;


namespace Curs2
{
    public partial class Ex3Form : Form
    {
        public Ex3Form()
        {
            InitializeComponent();
        }

        #region Welzl Algorithm
        //const double INF = 1e18;

        //struct Circle
        //{
        //    public PointF C;
        //    public double Radius;
        //};

        //double GetDistance(ref PointF a, ref PointF b)
        //{
        //    return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        //}

        //bool isInside(ref Circle c, PointF p)
        //{
        //    return GetDistance(ref c.C, ref p) <= c.Radius;
        //}

        //PointF GetCircleCenter(double bx, double by, double cx, double cy)
        //{
        //    double B = bx * bx + by * by;
        //    double C = cx * cx + cy * cy;
        //    double D = bx * cy - by * cx;
        //    PointF ret = new PointF();
        //    ret.X = Convert.ToSingle((cy * B - by * C) / (2 * D));
        //    ret.Y = Convert.ToSingle((bx * C - cx * B) / (2 * D));
        //    return ret;
        //}

        //Circle CircleFrom(ref PointF A, ref PointF B, ref PointF C)
        //{
        //    PointF I = GetCircleCenter(B.X - A.X, B.Y - A.Y,
        //                        C.X - A.X, C.Y - A.Y);

        //    I.X += A.X;
        //    I.Y += A.Y;
        //    Circle ret = new Circle
        //    {
        //        C = I,
        //        Radius = GetDistance(ref I, ref A)
        //    };
        //    return ret;
        //}

        //Circle CircleFrom(ref PointF A, ref PointF B)
        //{
        //    PointF C = new PointF((A.X + B.X) / 2, (A.Y + B.Y) / 2);
        //    Circle ret = new Circle
        //    {
        //        C = C,
        //        Radius = GetDistance(ref A, ref B) / 2
        //    };
        //    return ret;
        //}

        //bool IsValidCircle(Circle c, List<PointF> P)
        //{
        //    for (int i = 0; i < P.Count; i++)
        //    {
        //        if (!isInside(ref c, P[i]))
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        //Circle MinCircleTrivial(List<PointF> P)
        //{
        //    if (P.Count == 0)
        //    {
        //        Circle ret = new Circle
        //        {
        //            C = new PointF(0, 0),
        //            Radius = 0
        //        };
        //        return ret;
        //    }
        //    else if (P.Count == 1)
        //    {
        //        Circle ret = new Circle
        //        {
        //            C = P[0],
        //            Radius = 0
        //        };
        //        return ret;
        //    }
        //    else if (P.Count == 2)
        //    {
        //        return CircleFrom(P[0], P[1]);
        //    }

        //    for (int i = 0; i < 3; i++)
        //    {
        //        for (int j = i + 1; j < 3; j++)
        //        {

        //            Circle c = CircleFrom(P[i], P[j]);
        //            if (IsValidCircle(c, P))
        //                return c;
        //        }
        //    }
        //    return CircleFrom(P[0], P[1], P[2]);
        //}

        //Circle WelzlHelper(ref List<PointF> P, List<PointF> R, int n)
        //{
        //    if (n == 0 || R.Count == 3)
        //    {
        //        return MinCircleTrivial(R);
        //    }
        //    Random rand = new Random();
        //    int idx = rand.Next(0, n);
        //    PointF p = P[idx];

        //    (P[idx], P[n - 1]) = (P[n - 1], P[idx]);

        //    Circle d = WelzlHelper(ref P, R, n - 1);

        //    if (isInside(d, p))
        //    {
        //        return d;
        //    }

        //    R.Add(p);

        //    return WelzlHelper(ref P, R, n - 1);
        //}

        //Circle Welzl(List<PointF> P)
        //{
        //    List<PointF> P_copy = P;
        //    List<PointF> R = new List<PointF>();
        //    return WelzlHelper(ref P_copy, R, P_copy.Count);
        //}
#endregion

        private void Ex3Form_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Operations(g);
        }

        private void Operations(Graphics g)
        {
            Random rnd = new Random();
            CustomGraphics customGraphics = new CustomGraphics(g);

            Pen pointPen = new Pen(Color.Black, 2);
            Pen trianglePen = new Pen(Color.Green, 1);

            int n = rnd.Next(50, 100);
            int x, y;
            IList<SmallestEnclosingCircle.Point> points = new List<SmallestEnclosingCircle.Point>();

            for (int i = 0; i < n; i++)
            {
                x = rnd.Next(150, this.ClientSize.Width - 150);
                y = rnd.Next(100, this.ClientSize.Height - 100);
                points.Add(new SmallestEnclosingCircle.Point(x, y));
                customGraphics.DrawPoint(pointPen, x, y);
            }

            Circle result = SmallestEnclosingCircleMethods.MakeCircle(points);
            PointF rectOrigin = new PointF(Convert.ToSingle(result.c.x - result.r), Convert.ToSingle(result.c.y - result.r));
            SizeF rectSize = new SizeF(Convert.ToSingle(2 * result.r), Convert.ToSingle(2 * result.r));

            RectangleF rect = new RectangleF(rectOrigin, rectSize);

            g.DrawEllipse(trianglePen, rect);
        }
    }
}
