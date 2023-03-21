using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Time
    {
        public int Ore { get; set; }
        public int Minute { get; set; }
        public int Secunde { get; set; }
        public int Sutimi { get; set; }

        public Time(int ore, int minute, int secunde = 0, int sutimi = 0)
        {
            Ore = ore;
            Minute = minute;
            Secunde = secunde;
            Sutimi = sutimi;
        }

        public Time(string time)
        {
            string[] tokens = time.Split(':');
            if (tokens.Length != 4)
            {
                Console.WriteLine("Time not in a correct format. Use HH:MM:SS:ss!");
            }
            else
            {
                Ore = Convert.ToInt32(tokens[0]);
                Minute = Convert.ToInt32(tokens[1]);
                Secunde = Convert.ToInt32(tokens[2]);
                Sutimi = Convert.ToInt32(tokens[3]);
            }
        }

        public override string ToString()
        {
            string output = $"{Ore}:{Minute}:{Secunde}:{Sutimi}";
            return output;
        }

        public static Time operator + (Time t1, Time t2)
        {
            int Ora = 0, Minut = 0, Secunda = 0, Sutime;
            Sutime = t1.Sutimi + t2.Sutimi;
            if (Sutime > 99) { Sutime -= 100; Secunda += 1; }

            Secunda += t1.Secunde + t2.Secunde;
            if (Secunda > 59) { Secunda -= 60; Minut += 1; }

            Minut += t1.Minute + t2.Minute;
            if (Minut > 59) { Minut -= 60; Ora += 1; }

            Ora += t1.Ore + t2.Ore;
            if (Ora > 23) { Ora -= 24;}

            return new Time(Ora, Minut, Secunda, Sutime);
        }

        public static Time operator - (Time t1, Time t2)
        {
            int Ora = 0; int Minut = 0; int Secunda = 0; int Sutime = 0;
            if (t1 < t2)
            {
                (t1, t2) = (t2, t1);
            }
            if (t1.Sutimi < t2.Sutimi) { t1.Sutimi += 100; t1.Secunde -= 1; }
            Sutime = t1.Sutimi - t2.Sutimi;

            if (t1.Secunde < t2.Secunde) { t1.Secunde += 60; t1.Minute -= 1; }
            Secunda = t1.Secunde - t2.Secunde;

            if (t1.Minute < t2.Minute) { t1.Minute += 60; t1.Ore -= 1; }
            Minut = t1.Minute - t2.Minute;

            Ora = t1.Ore - t2.Ore;

            return new Time(Ora, Minut, Secunda, Sutime);
        }

        public static bool operator > (Time t1, Time t2)
        {
            if (t1.Ore > t2.Ore)
            {
                return true;
            }
            else if (t1.Ore == t2.Ore)
            {
                if (t1.Minute > t2.Minute)
                {
                    return true;
                }
                else if (t1.Minute == t2.Minute)
                {
                    if (t1.Secunde > t2.Secunde)
                    {
                        return true;
                    }
                    else if (t1.Secunde == t2.Secunde)
                    {
                        if (t1.Sutimi > t2.Sutimi)
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
            else
            {
                return false;
            }
        }

        public static bool operator <(Time t1, Time t2)
        {
            if (t1.Ore < t2.Ore)
            {
                return true;
            }
            else if (t1.Ore == t2.Ore)
            {
                if (t1.Minute < t2.Minute)
                {
                    return true;
                }
                else if (t1.Minute == t2.Minute)
                {
                    if (t1.Secunde < t2.Secunde)
                    {
                        return true;
                    }
                    else if (t1.Secunde == t2.Secunde)
                    {
                        if (t1.Sutimi < t2.Sutimi)
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
            else
            {
                return false;
            }
        }

        public static bool operator >=(Time t1, Time t2)
        {
            if (t1.Ore > t2.Ore)
            {
                return true;
            }
            else if (t1.Ore == t2.Ore)
            {
                if (t1.Minute > t2.Minute)
                {
                    return true;
                }
                else if (t1.Minute == t2.Minute)
                {
                    if (t1.Secunde > t2.Secunde)
                    {
                        return true;
                    }
                    else if (t1.Secunde == t2.Secunde)
                    {
                        if (t1.Sutimi >= t2.Sutimi)
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
            else
            {
                return false;
            }
        }

        public static bool operator <=(Time t1, Time t2)
        {
            if (t1.Ore < t2.Ore)
            {
                return true;
            }
            else if (t1.Ore == t2.Ore)
            {
                if (t1.Minute < t2.Minute)
                {
                    return true;
                }
                else if (t1.Minute == t2.Minute)
                {
                    if (t1.Secunde < t2.Secunde)
                    {
                        return true;
                    }
                    else if (t1.Secunde == t2.Secunde)
                    {
                        if (t1.Sutimi <= t2.Sutimi)
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
            else
            {
                return false;
            }
        }

        public static bool operator == (Time t1, Time t2)
        {
            if (t1.Ore != t2.Ore || t1.Minute != t2.Minute || t1.Secunde != t2.Secunde || t1.Sutimi != t2.Sutimi)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool operator !=(Time t1, Time t2)
        {
            if (t1.Ore == t2.Ore && t1.Minute == t2.Minute && t1.Secunde == t2.Secunde && t1.Sutimi == t2.Sutimi)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
