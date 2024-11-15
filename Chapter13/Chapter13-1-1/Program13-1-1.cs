using Chapter13_1_1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter13_1_1 {
    class Program {
        /*
        データベースを利用し、以下のコードを書いてください

        1. 以下の2名の著者とと4冊の書籍を追加してください。

        2. すべての書籍情報を著者名と共に表示するコードを書き、状況1.のデータが正しく追加されたかを確認してください。

        3. タイトルの最も長い書籍を求めてください。複数ある場合は全てを求めて表示してください。

        4. 発行日の古い順に3冊だけ書籍を取得し、そのタイトルと著者名を求めてください。

        5. 著者ごとの書籍のタイトルと発行年を表示してください。なお、著者は誕生日の遅い順にならべてください。
        */
        static void Main(string[] args) {
            // 1.
            /*
            InsertAuthors();
            InsertBooks();
            */

            // 2.
            using (var wDb = new BooksDbContext()) {
                var wBooksData = wDb.Books.ToList();
                var wAuthorsData = wDb.Authors.ToList();
                DisplayBooks(wBooksData);
                DisplayAuthors(wAuthorsData);
            }
            // 3.
            using (var wDb = new BooksDbContext()) {
                var wBooksData = wDb.Books.ToList();
                var wLongestBooks = wBooksData.Where(b => b.Title.Length == wBooksData.Max(book => book.Title.Length)).ToList();
                wLongestBooks.ForEach(book => Console.WriteLine($"最も長いタイトル: {book.Title}, 出版年: {book.PublishedYear}, 著者: {book.Author?.Name}"));
            }
            // 4.
            using (var wDb = new BooksDbContext()) {
                var wOldestBooks = wDb.Books.OrderBy(b => b.PublishedYear).Take(3).ToList();
                wOldestBooks.ForEach(book => Console.WriteLine($"タイトル: {book.Title}, 著者: {book.Author?.Name}"));
            }
            // 5.


        }

        /// <summary>
        /// 著者情報追加メソッド
        /// </summary>
        static void InsertAuthors() {
            using (var wDb = new BooksDbContext()) {
                var wAuthorsData = new List<Author> {
            new Author { Name = "菊池寛", Birthday = new DateTime(1998, 12, 16), Gender = "男性" },
            new Author { Name = "川端康成", Birthday = new DateTime(1899, 6, 14), Gender = "男性" }
            };

                foreach (var wAuthor in wAuthorsData) {
                    if (!wDb.Authors.Any(a => a.Name == wAuthor.Name)) {
                        wDb.Authors.Add(wAuthor);
                    }
                }
                wDb.SaveChanges();
            }
        }

        /// <summary>
        /// 書籍情報追加メソッド
        /// </summary>
        static void InsertBooks() {
            using (var wDb = new BooksDbContext()) {
                var wBooksData = new List<(string Title, int PublishedYear, string AuthorName)> {
            ("こころ", 1991, "夏目漱石"),
            ("伊豆の踊子", 2003, "川端康成"),
            ("真珠夫人", 2002, "菊池寛"),
            ("注文の多い料理店", 2000, "宮沢賢治")
                };

                foreach (var (wTitle, wPublishedYear, wAuthorName) in wBooksData) {

                    var wAuthor = wDb.Authors.SingleOrDefault(a => a.Name == wAuthorName);
                    if (wAuthor == null) {
                        wAuthor = new Author { Name = wAuthorName, Birthday = DateTime.Now, Gender = "不明" };
                        wDb.Authors.Add(wAuthor);
                    }
                    wDb.SaveChanges();

                    var wBook = new Book { Title = wTitle, PublishedYear = wPublishedYear, Author = wAuthor };
                    wDb.Books.Add(wBook);
                }
                wDb.SaveChanges();
            }
        }

        /// <summary>
        /// 書籍情報を表示するメソッド
        /// </summary>
        static void DisplayBooks(IEnumerable<Book> vBooksData) {
            foreach (var wBook in vBooksData) {
                if (wBook.Author != null) {
                    Console.WriteLine($"タイトル: {wBook.Title}, 出版年: {wBook.PublishedYear}, 著者: {wBook.Author.Name}");
                } else {
                    Console.WriteLine($"タイトル: {wBook.Title}, 出版年: {wBook.PublishedYear}, 著者: 不明");
                }
            }
        }

        /// <summary>
        /// 著者情報を表示するメソッド
        /// </summary>
        static void DisplayAuthors(IEnumerable<Author> vAuthorsData) {
            foreach (var wAuthor in vAuthorsData) {
                Console.WriteLine($"著者名: {wAuthor.Name}, 生年: {wAuthor.Birthday.ToString("yyyy-MM-dd")}, 性別: {wAuthor.Gender}");
            }
        }
    }
}
