using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Chapter4_1_2 {
    internal class Program {
        /*
        問題4.1で定義したYearMonthクラスを使って、次のコードを書いてください。
        本章で学んだイディオムが使えるところは、イディオムを使ってください。

        1. YearMonthを要素に持つ配列を定義し、初期値として5つのYearMonthを定義してください。

        2. この配列の要素（YearMonthオブジェクト)を全て列挙し、その値をコンソールに出力してください。

        3. 配列の中の最初に見つかった21世紀のYearMonthオブジェクトを返すメソッドを書いてください。
           見つからなかった場合は、nullを返してください。foreach文を使って実装してください。

        4. 3で作成したメソッドを呼び出し、最初に見つかった21世紀のデータの年を表示してください。
           見つからなければ、"21世紀のデータはありません"を表示してください。

        5. 配列に格納されているすべてのYearMonthの1ヶ月後を求め、その結果を新たな配列に表示してください。
           その後、その配列の要素の内容（年月）を順に表示してください。
           LINQを使えるところはLINQを使って実装してください。
        */
        static void Main(string[] args) {

            // 1.
            YearMonth[] wYearMonths = {
              new YearMonth(2001, 1),
              new YearMonth(2010, 3),
              new YearMonth(2090, 5),
              new YearMonth(2150, 8),
              new YearMonth(2024, 12),
            };
            // 2.
            Console.WriteLine("問題2");
            foreach (var wYearMonth in wYearMonths) {
                Console.WriteLine(wYearMonth);
            }
            // 4.
            // 三項演算子を使って書き換え
            Console.WriteLine("問題4");
            YearMonth wFirst21Century = FindFirst21Century(wYearMonths);
            Console.WriteLine(wFirst21Century == null ? "21世紀のデータはありません" : wFirst21Century.ToString());

            // 追加修正. 月は使わないように1行で記述
            Console.WriteLine("追加課題");
            Console.WriteLine(FindFirst21Century(wYearMonths)?.Year + "年" ?? "21世紀のデータはありません");

            // 5.
            Console.WriteLine("問題5");
            YearMonth[] wNextMonthYearMonths = wYearMonths.Select(x => x.AddOneMonth()).ToArray();

            foreach (var wOneMonthAfter in wNextMonthYearMonths) {
                Console.WriteLine(wOneMonthAfter);
            }
        }
        // 3.
        /// <summary>
        /// 最初の21世紀のオブジェクトを探す
        /// </summary>
        /// <param name="vYearMonths">YearMonthの配列</param>
        /// <returns>最初の21世紀のオブジェクト</returns>
        static YearMonth FindFirst21Century(IEnumerable<YearMonth> vYearMonths) {
            return vYearMonths.FirstOrDefault(x => x.Is21Century);
        }
    }
}
