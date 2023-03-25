using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using C5;

namespace CustomCGMethods
{
    public class SweepLine
    {
        //    static Dictionary<Point, Segment> L = new Dictionary<Point, Segment>();
        //    static Dictionary<Point, Segment> U = new Dictionary<Point, Segment>();
        //    static Dictionary<Point, Segment> C = new Dictionary<Point, Segment>();

        //    public static void FindIntersections(SortedSet<Segment> S)
        //    {
        //        Queue<Point> pointQueue = new Queue<Point>();

        //        foreach (Segment s in S)
        //        {
        //            foreach (PropertyInfo prop in typeof(Segment).GetProperties())
        //            {
        //                Point p = (Point)prop.GetValue(s, null);
        //                if (!pointQueue.Contains(p))
        //                {
        //                    pointQueue.Enqueue(p);
        //                    if (prop.Name == "LowerPoint")
        //                    {
        //                        L.Add(p, s);
        //                    }
        //                    if (prop.Name == "UpperPoint")
        //                    {
        //                        U.Add(p, s);
        //                    }
        //                }
        //            }
        //        }

        //        while (pointQueue.Count > 0)
        //        {
        //            Point p = pointQueue.Dequeue();
        //        }
        //    }

        //    static void HandleEvent()
        //    {

        //    }




        public struct Segment
        {
            public Point LeftPoint { get; set; }
            public Point RightPoint { get; set; }

            public Segment(Point a, Point b)
            {
                LeftPoint = a;
                RightPoint = b;
            }
        }

        struct Event : IComparable<Event>
        {
            public int X, Y;
            public bool isLeft;
            public int index;
            public Segment segment;

            public Event(int x, int y, bool l, int i, Segment s)
            {
                X = x;
                Y = y;
                isLeft = l;
                index = i;
                segment = s;
            }

            public int CompareTo(Event other)
            {
                if (this.Y < other.Y)
                {
                    return -1;
                }
                else if (this.Y > other.Y)
                {
                    return 1;
                }
                else
                {
                    if (this.X < other.X)
                    {
                        return -1;
                    }
                    else if (this.X > other.X)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            //public static bool operator <(Event e1, Event e2)
            //{
            //    if (e1.Y == e2.Y)
            //    {
            //        return e1.X < e2.X;
            //    }
            //    return e1.Y < e2.Y;
            //}

            //public static bool operator >(Event e1, Event e2)
            //{
            //    if (e1.Y == e2.Y)
            //    {
            //        return e1.X > e2.X;
            //    }
            //    return e1.Y > e2.Y;
            //}
        }

        static bool onSegment(Point p, Point q, Point r)
        {
            if (Math.Min(p.X, r.X) < q.X && q.X < Math.Max(p.X, q.X) && Math.Min(p.Y, r.Y) < q.Y && q.Y < Math.Max(p.Y, r.Y))
            {
                return true;
            }
            return false;
        }

        //orientarea tripletului p, q, r
        //0 --> coliniare
        //1 --> in sensul acelor de ceas
        //2 --> invers sensului acelor de ceas
        static int orientation(Point p, Point q, Point r)
        {
            int val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);

            if (val == 0)
            {
                return 0;
            }

            return (val > 0) ? 1 : 2;
        }

        public static bool doIntersect(Segment s1, Segment s2)
        {
            Point p1 = s1.LeftPoint, q1 = s1.RightPoint, p2 = s2.LeftPoint, q2 = s2.RightPoint;

            // Find the four orientations needed for general and
            // special cases
            int o1 = orientation(p1, q1, p2);
            int o2 = orientation(p1, q1, q2);
            int o3 = orientation(p2, q2, p1);
            int o4 = orientation(p2, q2, q1);

            // General case
            if (o1 != o2 && o3 != o4)
                return true;

            // Special Cases
            // p1, q1 and p2 are collinear and p2 lies on segment p1q1
            if (o1 == 0 && onSegment(p1, p2, q1)) return true;

            // p1, q1 and q2 are collinear and q2 lies on segment p1q1
            if (o2 == 0 && onSegment(p1, q2, q1)) return true;

            // p2, q2 and p1 are collinear and p1 lies on segment p2q2
            if (o3 == 0 && onSegment(p2, p1, q2)) return true;

            // p2, q2 and q1 are collinear and q1 lies on segment p2q2
            if (o4 == 0 && onSegment(p2, q1, q2)) return true;

            return false; // Doesn't fall in any of the above cases
        }


        //static List<Point> findIntersections(List<Segment> segments)
        //{
        //    Dictionary<string, int> usedPairs = new Dictionary<string, int>();
        //    List<Event> e = new List<Event>();

        //    for (int i = 0; i < segments.Count; i++)
        //    {
        //        e.Add(new Event(segments[i].LeftPoint.X, segments[i].LeftPoint.Y, true, i, segments[i]));
        //        e.Add(new Event(segments[i].RightPoint.X, segments[i].RightPoint.Y, false, i, segments[i]));
        //    }

        //    e.Sort();

        //    //SortedSet<Event> T = new SortedSet<Event>();
        //    List<Point> result = new List<Point>();
        //    C5.TreeSet<Event> T = new C5.TreeSet<Event>();
           
        //    for (int i = 0; i < e.Count; i++)
        //    {
        //        Event curr = e[i];
        //        if (curr.isLeft)
        //        {
        //            T.Add(curr);

        //            Event pred, succ;
        //            T.TryPredecessor(curr, out pred);
        //            T.TrySuccessor(curr, out succ);

        //            if (doIntersect(curr.segment, pred.segment))
        //            {
        //                result.Add();
        //            }
        //        }
        //    }
        //}
    }


    //public class SegmentComparerByLeftPoint : IComparer<Segment>
    //{
    //    public int Compare(Segment x, Segment y)
    //    {
    //        if (x.UpperPoint.X > y.UpperPoint.X)
    //        {
    //            return 1;
    //        }
    //        else if (x.UpperPoint.X < y.UpperPoint.X)
    //        {
    //            return -1;
    //        }
    //        else return 0;
    //    }
    //}
}
