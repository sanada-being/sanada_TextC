using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter3_1_1 {
    internal class Program {
        /*
           以下のリストが定義してあります。
           var wNumbers = new List<int> { 12,87,94,14,53,20,40,35,76,91,31,17,48};
           このリストに対してラムダ式を使い、次のコードを書いてください。

        1. List<T>のExistsメソッドを使い、8か9で割り切れる数があるかどうかを調べ、その結果をコンソールに出力してください。

        2. List<T>のForEachメソッドを使い、各要素を2.0で割った値をコンソールに出力してください。

        3. LINQのWhereメソッドを使い、値が50以上の要素を列挙し、その結果をコンソールに出力してください。

        4. LINQのSelectメソッドを使い、それぞれの値を2倍し、その結果をList<int>に格納してください。
           その後、List<int>の各要素をコンソールに出力してください。
        */
        static void Main(string[] args) {
            var wNumbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            // 1.Exsitsメソッドを使い、8か9で割り切れる数があるかを調べる
            Console.WriteLine("問題1");
            var wContainsMultiple8or9 = wNumbers.Exists(s => s % 8 == 0 || s % 9 == 0);
            Console.WriteLine(wContainsMultiple8or9);

            // 2.ForEachメソッドを使い、各要素を2.0で割った値をコンソールに出力
            Console.WriteLine("問題2");
            wNumbers.ForEach(s => Console.WriteLine(s / 2.0));

            // 3.LINQのWhereメソッドを使い、値が50以上の要素を列挙し、その結果をコンソールに出力
            Console.WriteLine("問題3");
            var wNumbersOver50 = wNumbers.Where(s => s >= 50);
            foreach (var wNumber in wNumbersOver50) {
                Console.WriteLine(wNumber);
            }

            // 4.LINQのSelectメソッドを使い、それぞれの値を2倍し、その結果をList<int>に格納
            // その後、List<int>の各要素をコンソールに出力
            Console.WriteLine("問題4");
            var wDoubleNumber = wNumbers.Select(s => s * 2).ToList();
            foreach (var wNumber in wDoubleNumber) {
                Console.WriteLine(wNumber);
            }
        }
    }
}
