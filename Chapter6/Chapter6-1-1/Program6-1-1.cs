using System;
using System.Linq;

namespace Chapter6_1_1 {
    internal class Program {
        /*
        次のような配列が定義されています。
        var wNumbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 }
        この配列に対して、以下のコードを書いてください。

        1. 最大値を求め、結果を表示してください。

        2. 最後から2個目の要素を取り出してください。

        3. それぞれの数値を文字列に変換し、結果を表示してください。

        4. 数の小さい順に並べ、先頭から3つを取り出し、結果を表示してください。

        5. 重複を排除した後、10より大きい値がいくつあるのかをカウントし、結果を表示してください。
        */
        static void Main(string[] args) {
            // 1.
            Console.WriteLine("問題1");
            var wNumbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };
            Console.WriteLine(wNumbers.Where(x => x > 0).Max());

            // 2.
            Console.WriteLine("問題2");
            Console.WriteLine(wNumbers.Skip(wNumbers.Length - 2).FirstOrDefault());

            // 3.
            Console.WriteLine("問題3");
            var wStringNumbers = wNumbers.Select(x => x.ToString()).ToArray();
            Console.WriteLine(string.Join(", ", wStringNumbers));

            // 4.
            Console.WriteLine("問題4");
            var wThreeNumber = wNumbers.OrderBy(x => x).Where(y => y > 0).Take(3).ToArray();
            Console.WriteLine(string.Join(",", wThreeNumber));

            // 5.
            Console.WriteLine("問題5");
            var wBigerThanTen = wNumbers.Distinct().Count(x => x > 10);
            Console.WriteLine(wBigerThanTen);
        }
    }
}