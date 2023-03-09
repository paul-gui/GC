using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomDrawMethods
{
    public class CustomGraphics
    {
        Graphics g;
        public CustomGraphics(Graphics graphics)
        {
            g = graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }
        public void DrawPoint(Pen p, int x, int y)
        {
            g.DrawLine(p, x - 3, y - 3, x + 3, y + 3);
            g.DrawLine(p, x - 3, y + 3, x + 3, y - 3);
        }

        public void DrawPoint(Pen p, Point pt)
        {
            g.DrawLine(p, pt.X - 3, pt.Y - 3, pt.X + 3, pt.Y + 3);
            g.DrawLine(p, pt.X - 3, pt.Y + 3, pt.X + 3, pt.Y - 3);
        }

        public void DrawTriangle(Pen p, Point a, Point b, Point c)
        {
            g.DrawLine(p, a, b);
            g.DrawLine(p, b, c);
            g.DrawLine(p, a, c);
        }
    }
}
