using System;

namespace Chapter8_1_2 {
    class Program {

        // 1.
        // p.215「8.5.1:次の指定曜日を求める」のメソッドを参考に、次の週の指定曜日を求めるメソッドを定義してください

        // 1. メソッド呼び出し
        static void Main(string[] args) {
            var wToday = DateTime.Today;
            DateTime wNextWednesDay = NextDay(wToday, DayOfWeek.Wednesday);
            Console.WriteLine(wNextWednesDay.ToString("d"));
        }

        // 1. メソッド
        public static DateTime NextDay(DateTime vDate, DayOfWeek vDayOfWeek) {
            var wDays = (int)vDayOfWeek - (int)(vDate.DayOfWeek) + 7;
            return vDate.AddDays(wDays);
        }
    }
}
