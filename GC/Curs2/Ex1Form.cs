using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomDrawMethods;

namespace Curs2
{
    public partial class Ex1Form : Form
    {
        float d = 200;
        public Ex1Form()
        {
            InitializeComponent();
        }

        private void Ex1Form_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Operations(g);
        }

        private void Operations(Graphics g)
        {
            Random rnd = new Random();
            CustomGraphics customGraphics = new CustomGraphics(g);

            Pen linePen = new Pen(Color.Red, 1);
            Pen pointPen = new Pen(Color.Black, 2);

            int n = rnd.Next(50, 100);
            int x, y;
            float current_d;
            Point[] points = new Point[n];

            for (int i = 0; i < n; i++)
            {
                x = rnd.Next(10, this.ClientSize.Width - 10);
                y = rnd.Next(10, this.ClientSize.Height - 10);
                points[i] = new Point(x, y);
                customGraphics.DrawPoint(pointPen, x, y);
            }

            x = rnd.Next(10, this.ClientSize.Width - 10);
            y = rnd.Next(10, this.ClientSize.Height - 10);
            Point q = new Point(x, y);
            customGraphics.DrawPoint(pointPen, q);

            for (int i = 0; i < n - 1; i++)
            {
                Point a = points[i];
                current_d = (float)Math.Sqrt(Math.Pow(a.X - q.X, 2) + Math.Pow(a.Y - q.Y, 2));
                if (current_d < d)
                {
                    g.DrawLine(linePen, a, q);
                }
            }
        }
    }
}
