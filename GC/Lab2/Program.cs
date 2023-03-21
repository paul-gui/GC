using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Ex1
            //sa se creeze un tip de date def de utilizator numit Date
            //  -implementati operatori relationali
            //  -o operatie pt determimnarea numarului de zile dintre doua date
            //  -se vor utiliza doua moduri de initializare  unui obiect de tip Date:
            //          -Date(zi, luna, an)
            //          -Date("zi.luna.an")

            //Date d1 = new Date(Console.ReadLine());
            //Date d2 = new Date(Console.ReadLine());
            //Console.WriteLine(Date.GetDifference(d1, d2));

            //DateTime d1p = new DateTime(d1.An, d1.Luna, d1.Zi);
            //DateTime d2p = new DateTime(d2.An, d2.Luna, d2.Zi);
            //Console.WriteLine((d1p - d2p).Days);
            #endregion

            #region Ex2
            //clasa Time (ore, minute, secunde, sutimi)
            //  -implementati operatorii +, - si cei relationali
            //  -4 moduri de initializare
            //          -Time(ore, min)
            //          -Time(ore, min, sec)
            //          -Time(ore, min, sec, sutimi)
            //          -Time("ore:min:sec:sutimi")

            Time t1 = new Time(Console.ReadLine());
            Time t2 = new Time(Console.ReadLine());
            Console.WriteLine((t1 - t2).ToString());
            #endregion
        }
    }
}
