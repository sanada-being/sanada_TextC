using System.Collections.Generic;
using System.IO;
namespace Chapter2_1_3 {
    //売上集計クラス
    public class SalesCounter {
        private IEnumerable<Sale> _sales;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vFilepath">ファイルのパス</param>
        public SalesCounter(string vFilepath) {
            _sales = ReadSales(vFilepath);
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
                var wSale = new Sale {
                    ShopName = wItems[0],
                    ProductCategory = wItems[1],
                    Amount = int.Parse(wItems[2])
                };
                wSales.Add(wSale);
            }
            return wSales;
        }

        /// <summary>
        /// 商品別の売上を求めて返す
        /// </summary>
        /// <returns>商品別の売上を返す</returns>
        public IDictionary<string, int> GetPerProductCategorySales() {
            var wDict = new Dictionary<string, int>();
            foreach (var wSale in _sales) {
                if (wDict.ContainsKey(wSale.ProductCategory))
                    wDict[wSale.ProductCategory] += wSale.Amount;
                else wDict[wSale.ProductCategory] = wSale.Amount;
            }
            return wDict;
        }
    }
}
