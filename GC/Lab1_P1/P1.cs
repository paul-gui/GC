using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_P1
{
    internal class HelloClass
    {
        public static int ID = 0;

        static HelloClass()
        {
            ID++;
        }

        public HelloClass()
        {
            ID++;
        }

        ~HelloClass()
        {
            Console.WriteLine("Goodbye World!");
        }
    }
}
