using System.Collections.Generic;
using System.IO;

namespace Chapter2_1_3 {
    /// <summary>
    /// 売上集計クラス
    /// </summary>
    public class SalesCounter {
        private IEnumerable<Sale> FSales;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vFilepath">ファイルのパス</param>
        public SalesCounter(string vFilepath) {
            FSales = ReadSales(vFilepath);
        }

        /// <summary>
        /// Saleオブジェクトのリストを返す
        /// </summary>
        /// <param name="vFilepath">ファイルパス</param>
        /// <returns>Saleオブジェクトのリスト</returns>
        private static IEnumerable<Sale> ReadSales(string vFilepath) {
            var wSales = new List<Sale>();
            var wLines = File.ReadAllLines(vFilepath);
            foreach (var wLine in wLines) {
                var wItems = wLine.Split(',');
                var wSale = new Sale(wItems[0], wItems[1], int.Parse(wItems[2]));
                wSales.Add(wSale);
            }
            return wSales;
        }

        /// <summary>
        /// 商品別の売上を求めて返す
        /// </summary>
        /// <returns>商品別の売上を返す</returns>
        public IDictionary<string, int> GetPerProductCategorySales() {
            var wProductCategorySales = new Dictionary<string, int>();
            foreach (var wSale in FSales) {
                if (wProductCategorySales.ContainsKey(wSale.ProductCategory))
                    wProductCategorySales[wSale.ProductCategory] += wSale.Amount;
                else wProductCategorySales[wSale.ProductCategory] = wSale.Amount;
            }
            return wProductCategorySales;
        }
    }
}
