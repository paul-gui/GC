using CustomCGMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs2
{
    public partial class Ex2Form : Form
    {
        public Ex2Form()
        {
            InitializeComponent();
        }

        private void Ex2Form_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Operations(g);
        }

        private void Operations(Graphics g)
        {
            Random rnd = new Random();

            Pen pointPen = new Pen(Color.Black, 2);
            Pen trianglePen = new Pen(Color.Blue, 1);

            int n = rnd.Next(50, 100);
            int x, y;
            Point[] points = new Point[n];

            for (int i = 0; i < n; i++)
            {
                x = rnd.Next(10, this.ClientSize.Width - 10);
                y = rnd.Next(10, this.ClientSize.Height - 10);
                points[i] = new Point(x, y);
                CustomGraphics.DrawPoint(g, pointPen, x, y);
            }

            bool sorted;
            do
            {
                sorted = true;
                for (int i = 0; i < n - 1; i++)
                {
                    if (points[i].X * points[i + 1].Y > points[i + 1].X * points[i].Y)
                    {
                        (points[i], points[i + 1]) = (points[i + 1], points[i]);
                        sorted = false;
                    }
                }
            } while (!sorted);

            float minArea = AreaOfTrangle(points[0], points[1], points[2]);
            Point a = new Point();
            Point b = new Point();
            Point c = new Point();
            for (int i = 1; i < n - 2; i++)
            {
                float currentArea = AreaOfTrangle(points[i], points[i + 1], points[i + 2]);
                if (currentArea < minArea)
                {
                    minArea = currentArea;
                    a = points[i];
                    b = points[i + 1];
                    c = points[i + 2];
                }
            }
            CustomGraphics.DrawTriangle(g, trianglePen, a, b, c);

        }

        private float AreaOfTrangle(Point a, Point b, Point c)
        {
            float d_ab, d_bc, d_ac;
            d_ab = (float)Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
            d_bc = (float)Math.Sqrt(Math.Pow(b.X - c.X, 2) + Math.Pow(b.Y - c.Y, 2));
            d_ac = (float)Math.Sqrt(Math.Pow(a.X - c.X, 2) + Math.Pow(a.Y - c.Y, 2));

            float p = d_ab + d_bc + d_ac;
            float sp = p / 2;

            float areaOfTriangle = (float)Math.Sqrt(sp * (sp - d_ab) * (sp - d_bc) * (sp - d_ac));

            return areaOfTriangle;
        }
    }
}
