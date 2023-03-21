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

            Point[] points = CustomGraphics.DrawRandomPoints(g, pointsPen, 2 * n, 0, 0, pcbDisplay.Width, pcbDisplay.Height);
            SortedList<int, Line> lines = new SortedList<int, Line>(new DuplicateKeyComparer<int>());

            for (int i = 0; i < points.Length - 1; i += 2)
            {
                g.DrawLine(linePen, points[i], points[i + 1]);
                int x = points[i].X < points[i + 1].X ? points[i].X : points[i + 1].X;
                lines.Add(x, new Line(points[i], points[i + 1]));
            }


            RefreshImage();
        }

        private void RefreshImage()
        {
            pcbDisplay.Image = bmp;
        }

        public struct Line
        {
            public Point A, B;
            public Line(Point a, Point b)
            {
                if (a.X < b.X)
                {
                    A = a;
                    B = b;
                }
                else
                {
                    A = b;
                    B = a;
                }
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
