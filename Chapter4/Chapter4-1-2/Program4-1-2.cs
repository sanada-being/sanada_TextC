using System;
using System.Linq;

namespace Chapter4_1_2 {
    internal class Program {
        /*
        問題4.1で定義したYearMonthクラスを使って、次のコードを書いてください。
        本章で学んだイディオムが使えるところは、イディオムを使ってください。

        1. YearMonthを要素に持つ配列を定義し、初期値として5つのYearMonthを定義してください。

        2. この配列の要素（YearMonthオブジェクトを全て列挙し、その値をコンソールに出力してください。

        3. 配列の中の最初に見つかった21世紀のyearMonthオブジェクトを返すメソッドを書いてください。
           見つからなかった場合は、nullを返してください。foreach文を使って実装してください。

        4. 3で作成したメソッドを呼び出し、最初に見つかった21世紀のデータの年を表示してください。
           見つからなければ、"21世紀のデータはありません"を表示してください。

        5. 配列に格納されているすべてのYearMonthの1ヶ月後を求め、その結果を新たな配列に表示してください。
           その後、その配列の要素の内容（年月）を順に表示してください。
           LINQを使えるところはLINQを使って実装してください。
        */
        static void Main(string[] args) {

            // 1.
            YearMonth[] wYearMonths1 = {
              new YearMonth(2001, 1),
              new YearMonth(2010, 3),
              new YearMonth(2090, 5),
              new YearMonth(2150, 8),
              new YearMonth(2024, 12),
            };
            // 2.
            Console.WriteLine("問題2");
            foreach (var wYear1Month in wYearMonths1) {
                Console.WriteLine(wYear1Month);
            }
            // 4.
            Console.WriteLine("問題4");
            YearMonth wFirst21Century = FindFirst21Century(wYearMonths1);
            if (wFirst21Century == null) {
                Console.WriteLine("21世紀のデータはありません");
            } else {
                Console.WriteLine(wFirst21Century);
            }
            // 5.
            Console.WriteLine("問題5");
            YearMonth[] wNextMonthYearMonths = wYearMonths1
                .Select(yearMonth => yearMonth.AddOneMonth())
                .ToArray();

            foreach (var wAdd1Month in wNextMonthYearMonths) {
                Console.WriteLine(wAdd1Month);
            }
        }
        // 3.
        /// <summary>
        /// 最初の21世紀のオブジェクトを探す
        /// </summary>
        /// <param name="vYearMonths">YearMonthの配列</param>
        /// <returns>最初の21世紀のオブジェクト</returns>
        static YearMonth FindFirst21Century(YearMonth[] vYearMonths) {
            foreach (var w21YearMonth in vYearMonths) {
                if (w21YearMonth.Is21Century) {
                    return w21YearMonth;
                }
            }
            return null;
        }
    }
}
