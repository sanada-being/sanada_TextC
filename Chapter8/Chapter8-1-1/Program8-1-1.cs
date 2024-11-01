using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter8_1_1 {
    internal class Program {
        static void Main(string[] args) {
            

            var wToday = DateTime.Today;

            int wDayOfYear = wToday.DayOfYear;
            Console.WriteLine(wDayOfYear);

            int wDay = DateTime.DaysInMonth(wToday.Year, wToday.Month);
            var wEndOfMonth = new DateTime(wToday.Year,wToday.Month,wDay);
            Console.WriteLine(wEndOfMonth);

        }
    }
}

