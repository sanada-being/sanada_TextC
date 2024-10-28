using System;

namespace Chapter5_1_2 {
    class Program {
        /*
        コンソールから入力した数字文字列をint型に変換した後、カンマつきの数字文字列に変換してください。
        入力した文字列は、int.TryParseメソッドで数値に変換してください。
        */
        static void Main(string[] args) {
            Console.WriteLine("数字文字列を入力してください。");
            string wWords = Console.ReadLine();
            if (int.TryParse(wWords, out int wNumbers)) {
                Console.WriteLine(wNumbers.ToString("#,0"));
            } else {
                Console.WriteLine("有効な整数を入力してください。");
            }
        }
    }
}
