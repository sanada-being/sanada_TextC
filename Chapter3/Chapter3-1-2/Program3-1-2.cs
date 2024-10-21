using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter3_1_2 {
    internal class Program {
        /*
        以下のリストが定義してあります。
        var names = new List<string> {
        "Tokyo",New Delhi","Bangkok","London","Paris","Berlin","Canberra","Hongkong",};
        このリストに対して、ラムダ式を使い、次のコードを書いてください。

        1. コンソールから入力した都市名が何番目に格納されているのかList<T>のFindIndexメソッドを使って調べ、
           その結果をコンソールに出力してください。見つからなかったら-1を出力してください。
           なお、コンソールからの出力にはConsole.ReadLineメソッドを利用してください。
           var wLine = Console.ReanLine();

        2. LINQのCountメソッドを使い、小文字の'o'が含まれている都市名がいくつあるかカウントし、
           その結果をコンソールに出力してください。

        3. LINQのWhereメソッドを使い、小文字の'o'が含まれている都市名を抽出し、配列に格納してください。
           その後、配列の各要素をコンソールに出力してください。

        4. LINQのWhereメソッドとSelectメソッドを使い、'B'で始まる都市名の文字数を抽出し、
           その文字数をコンソールに出力してください。都市名を表示する必要はありません。
        */
        static void Main(string[] args) {
            var wNames = new List<string> {
        "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hongkong", };

            // 1.FindIndexメソッドを使い、コンソールに入力した都市名が何番目に格納されているのかを出力
            //   見つからなかったら"その都市名は存在しません"と入力
            Console.WriteLine("問題1  都市名を入力");
            var wLine = Console.ReadLine();
            var wIndex = wNames.FindIndex(x => x == wLine);
            if (wIndex >= 0) {
                Console.WriteLine(wIndex);
            } else {
                Console.WriteLine("その都市名は存在しません");
            }

            // 2.LINQのCountメソッドを使い、小文字の'o'が含まれている都市名がいくつあるかカウントし、
            //   その結果をコンソールに出力
            Console.WriteLine("問題2");
            Console.WriteLine(wNames.Count(x => x.Contains('o')));

            // 3.LINQのWhereメソッドを使い、小文字の'o'が含まれている都市名を抽出し、配列に格納してください。
            //   その後、配列の各要素をコンソールに出力してください。
            Console.WriteLine("問題3");
            foreach (var wContainOCities in wNames.Where(x => x.Contains("o"))) {
                Console.WriteLine(wContainOCities);
            }

            // 4.LINQのWhereメソッドとSelectメソッドを使い、'B'で始まる都市名の文字数を抽出し、
            //   その文字数をコンソールに出力してください。都市名を表示する必要はありません。
            Console.WriteLine("問題4");
            foreach (var wStartedBCities in wNames.Where(x => x.StartsWith("B")).Select(x => x.Length)) {
                Console.WriteLine(wStartedBCities);
            }

            // 追加問題
            // 'n' で終わる都市名を抽出し、アルファベット順にならべたものを出力
            Console.WriteLine("追加問題");
            foreach (var wEndedTCities in wNames.Where(x => x.EndsWith("n")).OrderBy(x => x)) {
                Console.WriteLine(wEndedTCities);
            }
        }
    }
}
