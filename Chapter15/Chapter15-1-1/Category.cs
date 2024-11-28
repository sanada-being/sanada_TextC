namespace Chapter15_1_1 {
    /// <summary>
    ///カテゴリクラス
    /// </summary>
    public class Category {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() {
            return $"Id:{this.Id},カテゴリ名:{this.Name}";
        }
    }
}
