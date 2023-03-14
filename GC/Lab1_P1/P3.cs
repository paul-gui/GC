using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_P1
{
    //Se considera clasa dreptunghi avand caracteristicile lungime si latime. Sa aiba un constructor, o proprietate si o autoproprietate.
    internal class Dreptunghi
    {
        public double Lungime { get; set; }

        private double latime;
        public double Latime
        {
            get
            {
                return latime;
            }

            set
            {
                latime = value;
            }
        }

        public Dreptunghi(double lungime = 0, double latime = 0)
        {
            Console.WriteLine("Dreptunghi creat!");
            Lungime = lungime;
            Latime = latime;
        }
    }
}
