﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomCGMethods
{
    public static class CustomGraphics
    {
        public static void DrawPoint(Graphics g, Pen p, int x, int y)
        {
            g.DrawLine(p, x - 3, y - 3, x + 3, y + 3);
            g.DrawLine(p, x - 3, y + 3, x + 3, y - 3);
        }

        public static void DrawPoint(Graphics g, Pen p, Point pt)
        {
            g.DrawLine(p, pt.X - 3, pt.Y - 3, pt.X + 3, pt.Y + 3);
            g.DrawLine(p, pt.X - 3, pt.Y + 3, pt.X + 3, pt.Y - 3);
        }

        public static void DrawTriangle(Graphics g, Pen p, Point a, Point b, Point c)
        {
            g.DrawLine(p, a, b);
            g.DrawLine(p, b, c);
            g.DrawLine(p, a, c);
        }

        public static Point[] DrawRandomPoints(Graphics g, Pen p, int n, int minWidth, int minHeight, int maxWidth, int maxHeight)
        {
            Random rnd = new Random();
            int x, y;
            Point[] points = new Point[n];
            for (int i = 0; i < n; i++)
            {
                x = rnd.Next(minWidth, maxWidth);
                y = rnd.Next(minHeight, maxHeight);
                points[i] = new Point(x, y);
                DrawPoint(g, p, x, y);
            }
            return points;
        }
    }
}
