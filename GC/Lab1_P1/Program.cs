using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1_P1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region P1
            //HelloClass hello1 = new HelloClass();
            //HelloClass hello2 = new HelloClass();
            //Console.WriteLine(HelloClass.ID);
            #endregion

            #region P2
            //OperationsClass operations = new OperationsClass(7, 2);
            //Console.WriteLine(operations.Add());
            //Console.WriteLine(operations.Substract());
            //Console.WriteLine(operations.Multiply());
            //Console.WriteLine(operations.Divide());
            #endregion

            #region P3
            //Dreptunghi dreptunghi = new Dreptunghi();
            //dreptunghi.Latime = 6;
            //dreptunghi.Lungime = 10;
            //double arie = dreptunghi.Lungime * dreptunghi.Latime;
            //Console.WriteLine(arie);
            #endregion

            #region P4
            //Stars stars = new Stars(5);
            //stars.ShowStars();
            #endregion

            #region Bonus
            //MatrixEffect matrix = new MatrixEffect();
            //matrix.ArrangeCanvas();
            //matrix.StartEffect();
            #endregion
        }

        class MatrixEffect
        {
            Random rnd;
            public bool Enabled { get; set; }

            public MatrixEffect()
            {
                rnd = new Random();
            }

            public void StartEffect()
            {
                Enabled = true;
                while (Enabled)
                {
                    char c = (char)rnd.Next(50, 256);
                    Console.Write(c);
                }
            }
            public void ArrangeCanvas()
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
        }
    }
}