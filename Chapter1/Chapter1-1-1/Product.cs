/// 3.で名前空間を変更
namespace Chapter1_1_1change {
    /// <summary>
    /// 商品クラス
    /// </summary>
    internal class Product {

        /// <summary>
        /// 商品コード
        /// </summary>
        public int Code { get; private set; }

        /// <summary>
        /// 商品名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 商品の金額
        /// </summary>
        public int Price { get; private set; }

        ///  <summary>
        /// 商品情報初期化のためのコンストラクタ
        /// </summary>
        /// <param name="vCode">商品コードを示す整数値。</param>
        /// <param name="vName">商品名を表す文字列。</param>
        /// <param name="vPrice">商品名の価格を表す整数値。</param>
        public Product(int vCode, string vName, int vPrice) {
            this.Code = vCode;
            this.Name = vName;
            this.Price = vPrice;
        }

        /// <summary>
        /// 商品価格に対する税額を取得。
        /// 税率は8%で計算。
        /// </summary>
        /// <returns>税額を整数値で返す。</returns>
        public int GetTax() {
            return (int)(Price * 0.08);
        }

        /// <summary>
        /// 商品の税込金額を取得。
        /// </summary>
        /// <returns>税込金額を整数値で返す。</returns>
        public int GetPriceIncludingTax() {
            return Price + GetTax();
        }
    }
}
