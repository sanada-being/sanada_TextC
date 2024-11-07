using System;
using System.Globalization;
namespace Chapter8_1_1 {
    class Program {
        /*
        現在の日時を以下のような3種類の書式でコンソールに出力してください。
        2019/1/15 19:48
        2019年01月15日 19時48分32秒
        平成31年 1月15日(火曜日)
        */
        static void Main(string[] args) {
            var wNow = new DateTime(2024,1,5);
            // 1. 
            Console.WriteLine(wNow.ToString("yyyy/M/d HH:mm"));
            // 2. 
            Console.WriteLine(wNow.ToString("yyyy年MM月dd日 HH時mm分ss秒"));
            // 3.
            var wCulture = new CultureInfo("ja-JP");
            wCulture.DateTimeFormat.Calendar = new JapaneseCalendar();
            Console.WriteLine(wNow.ToString($"ggyy年{wNow.Month,2}月d日(dddd)", wCulture));
        }
    }
}

