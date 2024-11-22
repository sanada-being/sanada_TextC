using System;
using System.Configuration;
namespace Chapter14_1_3 {
    /*
    myAppSetting要素に以下のセクションを追加し、プログラムから参照できるようにしてください。
     <CalendarOption StringFormat="yyyy年MM月dd日(ddd)"
                            Minimum ="1900/1/1"
                            Maximum="2100/12/31"
                            MondayIsFirstDay="True" />

    */
    class Program {
        static void Main(string[] args) {
            var wCalendarOption = ConfigurationManager.GetSection("myAppSetting") as CalendarOptionSection;

            if (wCalendarOption != null && wCalendarOption.CalendarOption != null) {
                Console.WriteLine($"StringFormat: {wCalendarOption.CalendarOption.StringFormat}");
                Console.WriteLine($"Minimum: {wCalendarOption.CalendarOption.Minimum}");
                Console.WriteLine($"Maximum: {wCalendarOption.CalendarOption.Maximum}");
                Console.WriteLine($"MondayIsFirstDay: {wCalendarOption.CalendarOption.MondayIsFirstDay}");
            } else {
                Console.WriteLine("設定情報が見つかりませんでした。");
            }
        }
    }
}
