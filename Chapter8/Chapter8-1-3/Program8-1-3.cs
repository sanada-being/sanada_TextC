using System;

namespace Chapter8_1_3 {
    class Program {
        /*
         ある時間処理を計測するTimeWatchクラスを定義してください。
         TimeWatchの使い方の例を以下に示します。
         var wTw = new TimeWatch();
         wTw.Start();
         //処理
         TimeSpan wDuration = wTw.Stop();
         Console.WriteLine($"処理時間は{wDuration}ミリ秒でした");
        */
        static void Main(string[] args) {
            var wStartTime = new TimeWatch();
            wStartTime.Start();

            System.Threading.Thread.Sleep(2000);

            TimeSpan wDuration = wStartTime.Stop();
            Console.WriteLine($"処理時間は{wDuration.TotalSeconds:F3}ミリ秒でした");
        }
    }
}
