using System;
namespace Chapter2_1_3 {
    internal class Program {
        // 3. 「2.2:売り上げ集計プログラム」で作成したプログラムを変更し、
        //     商品カテゴリ別の売上高を求めるプログラムを作成してください。

        static void Main(string[] args) {
            var wSales = new SalesCounter("..\\..\\sales.csv");
            var wAmountPerStore = wSales.GetPerProductCategorySales();
            foreach (var wObj in wAmountPerStore) {
                Console.WriteLine($"{wObj.Key}{wObj.Value}");
            }
        }
    }
}
