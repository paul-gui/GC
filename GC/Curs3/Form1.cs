using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomCGMethods;

namespace Curs3
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pcbDisplay.Width, pcbDisplay.Height);
            g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void btnEx1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);

            Random rnd = new Random();
            int n = rnd.Next(70, 100);
            Pen pointsPen = new Pen(Color.Black, 2);
            Pen linePen = new Pen(Color.Red, 1);

            Point[] points = CustomGraphics.DrawRandomPoints(g, pointsPen, 2 * n, 0, 0, pcbDisplay.Width, pcbDisplay.Height);

            SortedList<int, IndexPair> distances = new SortedList<int, IndexPair>(new DuplicateKeyComparer<int>());


            #region Varianta 1
            int i, j;
            bool sorted;
            do
            {
                sorted = true;
                for (i = 0; i < points.Length - 1; i++)
                {
                    if (points[i].X > points[i + 1].X)
                    {
                        (points[i], points[i + 1]) = (points[i + 1], points[i]);
                        sorted = false;
                    }
                }
            }
            while (!sorted);

            bool[] used = new bool[points.Length];

            int pozA = new int();
            int pozB = new int();

            i = 0;
            while (i < points.Length - 1)
            {
                j = i + 1;
                int min = this.ClientSize.Width;

                while (j < points.Length)
                {
                    if (!(used[i] || used[j]))
                    {
                        int distance = GeometricMath.GetDistance(points[i], points[j]);

                        if (distance < min)
                        {
                            min = distance;
                            pozA = i;
                            pozB = j;
                        }
                    }
                    j++;
                }
                g.DrawLine(linePen, points[pozA], points[pozB]);
                used[pozA] = true;
                used[pozB] = true;
                i++;
            }
            #endregion

            #region Varianta 2
            //for (int i = 0; i < points.Length; i++)
            //{
            //    for (int j = 0; j < points.Length; j++)
            //    {
            //        if (i != j)
            //        {
            //            distances.Add(GeometricMath.GetDistance(points[i], points[j]), new IndexPair(i, j));
            //        }
            //    }
            //}

            //bool[] used = new bool[points.Length];
            //bool finished;

            //foreach (var item in distances)
            //{
            //    finished = true;
            //    int i = item.Value.I;
            //    int j = item.Value.J;
            //    if (!(used[i] || used[j]))
            //    {
            //        g.DrawLine(linePen, points[i], points[j]);
            //        used[i] = true;
            //        used[j] = true;
            //    }
            //    for (int k = 0; k < used.Length; k++)
            //    {
            //        if (!used[k])
            //        {
            //            finished = false;
            //            break;
            //        }
            //    }
            //    if (finished)
            //    {
            //        break;
            //    }
            //}
            #endregion

            #region Varianta 3
            //bool sorted;
            //Point[] leftPoints = new Point[n];
            //Point[] rightPoints = new Point[n];

            //for (int i = 0; i < points.Length / 2; i++)
            //{
            //    leftPoints[i] = points[i];
            //    rightPoints[i] = points[i + points.Length / 2];
            //}

            //do
            //{
            //    sorted = true;
            //    for (int i = 0; i < n - 1; i++)
            //    {
            //        if (leftPoints[i].Y > leftPoints[i + 1].Y)
            //        {
            //            (leftPoints[i], leftPoints[i + 1]) = (leftPoints[i + 1], leftPoints[i]);
            //            sorted = false;
            //        }
            //    }
            //}
            //while (!sorted);

            //do
            //{
            //    sorted = true;
            //    for (int i = 0; i < n - 1; i++)
            //    {
            //        if (rightPoints[i].Y > rightPoints[i + 1].Y)
            //        {
            //            (rightPoints[i], rightPoints[i + 1]) = (rightPoints[i + 1], rightPoints[i]);
            //            sorted = false;
            //        }
            //    }
            //}
            //while (!sorted);

            //for (int i = 0; i < n; i++)
            //{
            //    g.DrawLine(linePen, leftPoints[i], rightPoints[i]);
            //}
            #endregion

            RefreshImage();
        }

        private void btnEx2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);

            Random rnd = new Random();
            int n = rnd.Next(10, 15);
            Pen pointsPen = new Pen(Color.Black, 2);
            Pen linePen = new Pen(Color.Red, 1);
            Pen interPointsPen = new Pen(Color.Green);

            Point[] points = CustomGraphics.DrawRandomPoints(g, pointsPen, 2 * n, 0, 0, pcbDisplay.Width, pcbDisplay.Height);

            Segment[] segments = new Segment[n];

            int k = 0;
            for (int i = 0; i < 2 * n - 1; i += 2)
            {
                segments[k] = new Segment(points[i], points[i + 1]);
                g.DrawLine(linePen, points[i], points[i + 1]);
                k++;
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    float? x, y;
                    if (get_line_intersection(segments[i].A.X, segments[i].A.Y, segments[i].B.X, segments[i].B.Y, segments[j].A.X, segments[j].A.Y, segments[j].B.X, segments[j].B.Y,out x, out y))
                    {
                        g.DrawEllipse(interPointsPen, (float)x - 5, (float)y - 5, 10, 10);
                    }
                }
            }

            RefreshImage();
        }

        bool get_line_intersection(float p0_x, float p0_y, float p1_x, float p1_y,
    float p2_x, float p2_y, float p3_x, float p3_y, out float? i_x, out float? i_y)
        {
            i_x = 0;
            i_y = 0;
            float s1_x, s1_y, s2_x, s2_y;
            s1_x = p1_x - p0_x; s1_y = p1_y - p0_y;
            s2_x = p3_x - p2_x; s2_y = p3_y - p2_y;

            float s, t;
            s = (-s1_y * (p0_x - p2_x) + s1_x * (p0_y - p2_y)) / (-s2_x * s1_y + s1_x * s2_y);
            t = (s2_x * (p0_y - p2_y) - s2_y * (p0_x - p2_x)) / (-s2_x * s1_y + s1_x * s2_y);

            if (s >= 0 && s <= 1 && t >= 0 && t <= 1)
            {
                // Collision detected
                if (i_x != null)
                    i_x = (p0_x + (t * s1_x));
                if (i_y != null)
                    i_y = (p0_y + (t * s1_y));
                return true;
            }

            return false; // No collision
        }

        private void RefreshImage()
        {
            pcbDisplay.Image = bmp;
        }

        public struct Segment
        {
            public Point A, B;

            public Segment (Point a, Point b)
            {
                A = a;
                B = b;
            }
        }

        struct IndexPair
        {
            public int I;
            public int J;
            public IndexPair(int i, int j)
            {
                I = i;
                J = j;
            }
        }

        class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
        {
            public int Compare(TKey x, TKey y)
            {
                int result = x.CompareTo(y);

                if (result == 0)
                    return 1;
                else
                    return result;
            }
        }
    }
}
