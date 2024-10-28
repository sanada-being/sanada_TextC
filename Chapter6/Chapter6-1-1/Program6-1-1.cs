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

            if (wNumbers == null) {
                Console.WriteLine("配列が存在しません");
            } else if (wNumbers.Length == 0 || !wNumbers.Any(x => x > 0)) {
                Console.WriteLine("要素がありません");
            } else {
                Console.WriteLine(wNumbers.Where(x => x > 0).Max());
            }

            // 2.
            Console.WriteLine("問題2");
            if (wNumbers == null) {
                Console.WriteLine("配列が存在しません");
            } else if (wNumbers.Length == 0) {
                Console.WriteLine("配列の要素はありません");
            } else if (wNumbers.Length <= 2) {
                Console.WriteLine("配列の要素は2以下なので、最初の要素が出力されます");
                Console.WriteLine(wNumbers.FirstOrDefault());
            } else {
                Console.WriteLine("最後から2個目の要素は" + wNumbers.Skip(wNumbers.Length - 2).FirstOrDefault());
            }
            // 3.

            Console.WriteLine("問題3");
            if (wNumbers == null) {
                Console.WriteLine("配列が null です");
            } else if (wNumbers.Length == 0) {
                Console.WriteLine("配列に要素がありません");
            } else {
                var wStringNumbers = wNumbers.Select(x => x.ToString());
                Console.WriteLine(string.Join(", ", wStringNumbers));
            }

            // 4.
            Console.WriteLine("問題4");
            if (wNumbers == null) {
                Console.WriteLine("配列が null です");
            } else if (wNumbers.Length == 0) {
                Console.WriteLine("配列に要素がありません");
            } else {
                var wThreeNumber = wNumbers.OrderBy(x => x).Where(y => y > 0).Take(3);
                Console.WriteLine(string.Join(",", wThreeNumber));
            }

            // 5.
            Console.WriteLine("問題5");
            if (wNumbers == null) {
                Console.WriteLine("配列が null です");
            } else if (wNumbers.Length == 0) {
                Console.WriteLine("配列に要素がありません");
            } else {
                var wBigerThanTen = wNumbers.Distinct().Count(x => x > 10);
                Console.WriteLine(wBigerThanTen);
            }
        }
    }
}