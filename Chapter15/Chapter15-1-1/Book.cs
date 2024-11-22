using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter15_1_1 {
    /// <summary>
    /// 書籍クラス
    /// </summary>
    public class Book {
        public string Title { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public int PublishedYear { get; set; }
        public override string ToString() {
            return $"発行年:{this.PublishedYear},カテゴリ:{this.CategoryId},価格:{this.Price},タイトル:{this.Title}";
        }
    }
}
