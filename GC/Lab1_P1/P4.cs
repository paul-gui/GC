using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_P1
{
    //Sa se scrie o clasa care afiseaza stelute astfel:
    //*
    //**
    //***
    //etc..
    //Clasa sa contina: -un constructor care are ca parametru numarul de linii
    //                  -o metoda care afisieaza liniile
    //                  -un destructor care sa afiseze un mesaj corespunzator
    internal class Stars
    {
        int n;
        public Stars(int n)
        {
            this.n = n;
        }

        public void ShowStars()
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        ~Stars()
        {
            Console.WriteLine("Sfarsitul programului.");
        }
    }
}
