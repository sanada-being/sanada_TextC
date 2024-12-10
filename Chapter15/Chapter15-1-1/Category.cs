namespace Chapter15_1_1 {
    /// <summary>
    ///カテゴリクラス
    /// </summary>
    public class Category {

        /// <summary>
        /// 書籍のカテゴリID
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// 書籍のカテゴリ名
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vId">カテゴリID</param>
        /// <param name="vName">カテゴリ名</param>
        public Category(int vId, string vName) {
            this.Id = vId;
            this.Name = vName;
        }

        /// <summary>
        /// カテゴリ情報を文字列に変換
        /// </summary>
        /// <returns>カテゴリ情報の文字列表現</returns>
        public override string ToString() =>
            $"カテゴリID:{this.Id},カテゴリ名:{this.Name}";
    }
}
