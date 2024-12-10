namespace Chapter15_1_1 {
    /// <summary>
    /// 書籍クラス
    /// </summary>
    public class Book {

        /// <summary>
        /// 書籍タイトルを取得
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// 書籍金額を取得
        /// </summary>
        public int Price { get; }

        /// <summary>
        /// 書籍のカテゴリIDを取得
        /// </summary>
        public int CategoryId { get; }

        /// <summary>
        /// 書籍の発行年を取得
        /// </summary>
        public int PublishedYear { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vTitle">タイトル</param>
        /// <param name="vPrice">金額</param>
        /// <param name="vCategoryId">カテゴリID</param>
        /// <param name="vPublishedYear">発行年</param>
        public Book(string vTitle, int vPrice, int vCategoryId, int vPublishedYear) {
            this.Title = vTitle;
            this.Price = vPrice;
            this.CategoryId = vCategoryId;
            this.PublishedYear = vPublishedYear;

        }

        /// <summary>
        /// 書籍情報を文字列に変換
        /// </summary>
        /// <returns>書籍情報の文字列表現</returns>
        public override string ToString() =>
            $"発行年:{this.PublishedYear},カテゴリ:{this.CategoryId},価格:{this.Price},発行年:{this.PublishedYear}";}
}
