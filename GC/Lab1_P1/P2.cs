using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_P1
{
    //Adunare scadere inmultire impartine - metode fara parametrii - constructor cu 2 parametrii care init membrii data din clasa
    internal class OperationsClass
    {
        double a, b;

        public OperationsClass(int a = 0, int b = 0)
        {
            this.a = a;
            this.b = b;
        }

        public double Add()
        {
            return a + b;
        }

        public double Substract()
        {
            return a - b;
        }

        public double Multiply()
        {
            return a * b;
        }

        public double Divide()
        {
            return a / b;
        }
    }
}
