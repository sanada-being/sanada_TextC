using System;

namespace Chapter2_1_2 {
    internal class Program {
        /* 2. インチからメートルへの変換表を1インチ刻みでコンソールに表示するプログラムを作成してください。
           この時、インチの範囲は、1インチから10インチまでとしてください。
           1インチは0.0254メートルです。
        */

        static void Main(string[] args) {
            for (int wInch = 1; wInch <= 10; wInch++) {
                double wMeter = wInch * 0.0254;
                Console.WriteLine($"{wInch}inch = {wMeter:0.0000}m");
            }
        }
    }
}
