using System;
using System.Linq;

namespace Chapter5_1_4 {
    class Program {
        /*
        "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886"という文字列から以下の出力を得る
        コンソールアプリケーションを作成して下さい。

        作家　: 谷崎潤一郎
        代表作: 春琴抄
        誕生年: 1886
        */
        static void Main(string[] args) {
            string wNovelistInformation = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            var wNovelistInfoDict = wNovelistInformation.Split(';').Select(x => x.Split('=')).ToDictionary(y => y[0], y => y[1]);

            Console.WriteLine($"作家　: {wNovelistInfoDict["Novelist"]}{Environment.NewLine}代表作: {wNovelistInfoDict["BestWork"]}{Environment.NewLine}誕生年: {wNovelistInfoDict["Born"]}");
        }
    }
}
