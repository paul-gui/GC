using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Date
    {
        public int Zi { get; set; }
        public int Luna { get; set; }
        public int An { get; set; }

        public Date(int zi, int luna, int an)
        {
            Zi = zi;
            Luna = luna;
            An = an;
        }

        public Date (string date)
        {
            string[] tokens = date.Split('.');
            Zi = Convert.ToInt32(tokens[0]);
            Luna = Convert.ToInt32(tokens[1]);
            An = Convert.ToInt32(tokens[2]);
        }

        public static int GetDifference(Date d1, Date d2)
        {
            if (d1 > d2)
            {
                (d1, d2) = (d2, d1);
            }

            int diff;

            //Pas1: Calculam diferenta de zile dintre ani
            diff = (d2.An - d1.An) * 365 + CatiAniBisecti(d1.An, d2.An);

            //Pas2: Calculam diferenta de zile
            diff = diff - CateZileInLuna(d1) - d1.Zi;
            diff = diff + CateZileInLuna(d2) + d2.Zi;
            return diff;
        }

        public static bool operator > (Date d1, Date d2)
        {
            if (d1.An > d2.An)
            {
                return true;
            }
            else if (d1.An == d2.An)
            {
                if (d1.Luna > d2.Luna)
                {
                    return true;
                }
                else if (d1.Luna == d2.Luna)
                {
                    if (d1.Zi > d2.Zi)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool operator < (Date d1, Date d2)
        {
            if (d1.An < d2.An)
            {
                return true;
            }
            else if (d1.An == d2.An)
            {
                if (d1.Luna < d2.Luna)
                {
                    return true;
                }
                else if (d1.Luna == d2.Luna)
                {
                    if (d1.Zi < d2.Zi)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool operator >=(Date d1, Date d2)
        {
            if (d1.An > d2.An)
            {
                return true;
            }
            else if (d1.An == d2.An)
            {
                if (d1.Luna > d2.Luna)
                {
                    return true;
                }
                else if (d1.Luna == d2.Luna)
                {
                    if (d1.Zi > d2.Zi)
                    {
                        return true;
                    }
                    else if (d1.Zi == d2.Zi)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool operator <= (Date d1, Date d2)
        {
            if (d1.An < d2.An)
            {
                return true;
            }
            else if (d1.An == d2.An)
            {
                if (d1.Luna < d2.Luna)
                {
                    return true;
                }
                else if (d1.Luna == d2.Luna)
                {
                    if (d1.Zi < d2.Zi)
                    {
                        return true;
                    }
                    else if (d1.Zi == d2.Zi)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool operator == (Date d1, Date d2)
        {
            if (d1.An != d2.An)
            {
                return false;
            }
            else if (d1.Luna != d2.Luna)
            {
                return false;
            }
            else if (d1.Zi !=  d2.Zi)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool operator != (Date d1, Date d2)
        {
            if (d1.An == d2.An && d1.Luna == d2.Luna && d1.Zi == d2.Zi)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int CatiAniBisecti(int an1, int an2)
        {
            int cont = 0;
            for (int i = an1; i < an2; i++)
            {
                if (EsteBisect(i))
                {
                    cont++;
                }
            }
            return cont;
        }

        private static bool EsteBisect(int an)
        {

            if (an % 400 == 0)
            {
                return true;
            }
            else if (an % 4 == 0 && an % 100 != 0)
            {
                return true;
            }
            return false;
        }

        private static int CateZileInLuna(Date data)
        {
            int rezultat = 0;
            for (int i = 1; i < data.Luna; i++)
            {
                int nr_zile = 0;
                switch (i)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                        nr_zile = 31;
                        break;
                    case 2:
                        nr_zile = EsteBisect(data.An) ? 29 : 28;
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        nr_zile = 30;
                        break;
                }
                rezultat += nr_zile;
            }
            return rezultat;
        }
    }
}
