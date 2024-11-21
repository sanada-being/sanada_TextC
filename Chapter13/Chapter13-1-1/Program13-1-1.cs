using System;
using System.Collections.Generic;
using System.Linq;
using Chapter13_1_1.Models;

namespace Chapter13_1_1 {
    class Program {
        /*
        本文で作成したデータベースを利用し、以下のコードを書いてください

        1. 以下の2名の著者とと4冊の書籍を追加してください。
        ・名前/生年月日/性別
       　 菊池寛/1888年12月16日/男性
       　 川端康成/1899年6月14日/男性

        ・タイトル/発行年/著者名
        　こころ/1991/夏目漱石
       　 伊豆の踊子/2003/川端康成
        　真珠夫人/2002/菊池寛
        　注文の多い料理店/2000/宮沢賢治

        2. すべての書籍情報を著者名と共に表示するコードを書き、状況1.のデータが正しく追加されたかを確認してください。

        3. タイトルの最も長い書籍を求めてください。複数ある場合は全てを求めて表示してください。

        4. 発行日の古い順に3冊だけ書籍を取得し、そのタイトルと著者名を求めてください。

        5. 著者ごとの書籍のタイトルと発行年を表示してください。なお、著者は誕生日の遅い順にならべてください。
        */
        static void Main(string[] args) {
            var wNewAuthorsData = new List<Author> {
                    new Author { Name = "菊池寛", Birthday = new DateTime(1998, 12, 16), Gender = "男性" },
                    new Author { Name = "川端康成", Birthday = new DateTime(1899, 6, 14), Gender = "男性" },
                    new Author { Name = "宮沢賢治", Birthday = new DateTime(1896, 8, 27), Gender = "男性" },
                    new Author { Name = "夏目漱石", Birthday = new DateTime(1867, 2, 9), Gender = "男性" },
            };
            var wNewBooksData = new List<(string Title, int PublishedYear, string AuthorName)> {
                    ("こころ", 1991, "夏目漱石"),
                    ("伊豆の踊子", 2003, "川端康成"),
                    ("真珠夫人", 2002, "菊池寛"),
                    ("注文の多い料理店", 2000, "宮沢賢治")
                };
            // 1.
            InsertAuthors(wNewAuthorsData);
            InsertBooks(wNewBooksData);

            // 2.
            Console.WriteLine("問題2");
            using (var wDb = new BooksDbContext()) {
                var wBooksData = wDb.Books.ToList();
                var wAuthorsData = wDb.Authors.ToList();
                DisplayBooks(wBooksData);
                DisplayAuthors(wAuthorsData);
            }
            // 3.
            Console.WriteLine("\n問題3");
            using (var wDb = new BooksDbContext()) {
                var wBooksData = wDb.Books.ToList();
                var wLongestBooks = wBooksData.Where(b => b.Title.Length == wBooksData.Max(book => book.Title.Length)).ToList();
                wLongestBooks.ForEach(book => Console.WriteLine($"最も長いタイトル: {book.Title}, 出版年: {book.PublishedYear}, 著者: {book.Author?.Name}"));
            }
            // 4.
            Console.WriteLine("\n問題4");
            using (var wDb = new BooksDbContext()) {
                var wOldestBooks = wDb.Books.OrderBy(b => b.PublishedYear).Take(3).ToList();
                wOldestBooks.ForEach(book => Console.WriteLine($"タイトル: {book.Title}, 著者: {book.Author?.Name}"));
            }
            // 5.
            Console.WriteLine("\n問題5");
            using (var wDb = new BooksDbContext()) {
                var wAuthorsBooks = wDb.Authors.OrderByDescending(x => x.Birthday).Select(x => new {
                    AuthorName = x.Name, Books = x.Books.Select(y => new { y.Title, y.PublishedYear })
                });

                foreach (var wAuthors in wAuthorsBooks) {
                    Console.WriteLine($"著者:{wAuthors.AuthorName}");
                    foreach (var wBook in wAuthors.Books) {
                        Console.WriteLine($"タイトル: {wBook.Title},発行年: {wBook.PublishedYear}");
                    }
                }
            }
        }

        /// <summary>
        /// 著者情報追加メソッド
        /// </summary>
        static void InsertAuthors(List<Author> vNewAuthorsData) {
            using (var wDb = new BooksDbContext()) {
                var wExistingAuthors = wDb.Authors.Select(x => x.Name).ToList();
                var wNewAuthors = vNewAuthorsData.Where(x => !wExistingAuthors.Contains(x.Name)).ToList();

                wDb.Authors.AddRange(wNewAuthors);
                wDb.SaveChanges();
                Console.WriteLine("著者情報の追加が完了しました");
            }
        }

        /// <summary>
        /// 書籍情報追加メソッド
        /// </summary>
        static void InsertBooks(List<(string Title, int PublishedYear, string AuthorName)> vNewBooksData) {
            using (var wDb = new BooksDbContext()) {
                var wExistingAuthors = wDb.Authors.ToList();

                foreach (var (wTitle, wPublishedYear, wAuthorName) in vNewBooksData) {
                    var wAuthor = wExistingAuthors.SingleOrDefault(x => x.Name == wAuthorName);
                    if (wAuthor == null) {
                        wAuthor = new Author { Name = wAuthorName, Birthday = null, Gender = "不明" };
                        wDb.Authors.Add(wAuthor);
                        wExistingAuthors.Add(wAuthor);
                    }

                    var wBook = new Book { Title = wTitle, PublishedYear = wPublishedYear, Author = wAuthor };
                    wDb.Books.Add(wBook);
                }
                wDb.SaveChanges();
                Console.WriteLine("書籍情報の追加が完了しました");
            }
        }

        /// <summary>
        /// 書籍情報表示メソッド
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
        /// 著者情報表示メソッド
        /// </summary>
        static void DisplayAuthors(IEnumerable<Author> vAuthorsData) {
            foreach (var wAuthor in vAuthorsData) {
                var wBirthday = wAuthor.Birthday.HasValue ? wAuthor.Birthday.Value.ToString("yyyy-MM-dd") : "不明";
                Console.WriteLine($"著者名: {wAuthor.Name}, 生年: {wBirthday}, 性別: {wAuthor.Gender}");
            }
        }
    }
}
