namespace Chapter13_1_1.Models {
    /// <summary>
    /// 書籍クラス
    /// </summary>
    public class Book {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PublishedYear { get; set; }
        public virtual Author Author { get; set; }
    }
}
