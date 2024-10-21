namespace Chapter2_1_3 {
    /// <summary>
    /// 売り上げクラス
    /// </summary>
    public class Sale {

        /// <summary>
        /// 店舗名
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 商品カテゴリ
        /// </summary>
        public string ProductCategory { get; set; }

        /// <summary>
        /// 売上高
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vShopName">店名</param>
        /// <param name="vProductCategory">商品名</param>
        /// <param name="vAmount">売上高</param>
        public Sale(string vShopName, string vProductCategory, int vAmount) {
            {
                this.ShopName = vShopName;
                this.ProductCategory = vProductCategory;
                this.Amount = vAmount;
            }
        }
    }
}
