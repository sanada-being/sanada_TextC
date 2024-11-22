using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter15_1_1 {
    /// <summary>
    /// ライブラリクラス
    /// </summary>
    public static class Library {

        // Categoriesプロパティで上記のカテゴリの一覧を取得することができる
        public static IEnumerable<Category> Categories { get; private set; }

        // Booksプロパティで上記の書籍情報の一覧を取得することができる
        public static IEnumerable<Book> Books { get; private set; }

        static Library() {
            // CategoriesとBooksにデータを設定。実装詳細は省略
        }
    }
}
