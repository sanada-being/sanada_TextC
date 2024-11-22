using System;

namespace Chapter14_1_6 {
    // 日本（東京)の現地時間（2020/8/10/16:32:20)から、対応する協定世界時とシンガポールの現地時間を表示するコードを書いてください。
    class Program {
        static void Main(string[] args) {
            var wTimeZones = TimeZoneInfo.GetSystemTimeZones();
            foreach (var wTimeZone in wTimeZones) {
                Console.WriteLine($"{wTimeZone.Id},{wTimeZone.DisplayName}");
            }

            var wTokyoDate = new DateTimeOffset(new DateTime(2020, 8, 10, 16, 32, 20));
            Console.WriteLine("問題1");
            Console.WriteLine(TimeZoneInfo.ConvertTimeBySystemTimeZoneId(wTokyoDate, "UTC-11"));
            Console.WriteLine(TimeZoneInfo.ConvertTimeBySystemTimeZoneId(wTokyoDate, "Singapore Standard Time"));


        }
    }
}

