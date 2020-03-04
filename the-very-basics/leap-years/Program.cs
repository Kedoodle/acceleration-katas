using System;
using System.Collections.Generic;
using System.Linq;

namespace leap_years
{
    class Program
    {
        static void Main(string[] args)
        {
            var startYear = DateTime.Now.Month > 2 ? DateTime.Now.Year + 1 : DateTime.Now.Year;
            while (!DateTime.IsLeapYear(startYear))
            {
                startYear++;
            }
            var leapYears = new List<int>();
            leapYears.AddRange(Enumerable.Range(startYear, 20*4).Where(x => x % 4 == 0));
            Console.WriteLine("The next 20 leap years are: " + string.Join(", ", leapYears));
        }
    }
}