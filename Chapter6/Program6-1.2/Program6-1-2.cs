using System;
using System.Collections.Generic;
using System.Linq;

namespace Program6_1_2 {
    internal class Program {
        /*
        次のようなリストが定義されています。
             var wBooks = new List<Book> {
               new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
               new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
               new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
               new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
               new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
               new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
               new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };
        このwBooksリストに対して、以下のコードを書いてください。

        1. wBooksの中で、タイトルが"ワンダフル・C#ライフ"である書籍の価格とページ数を表示するコードを書いてください。

        2. wBooksの中で、タイトルに"C#"が含まれている書籍が何冊あるかカウントするコードを書いてください。

        3. wBooksの中で、タイトルに"C#"が含まれている書籍の平均ページ数を求めるコードを書いてください。

        4. wBooksの中で、価格が4000円以上の本で最初に見つかった書籍のタイトルを表示するコードを書いてください。

        5. wBooksの中で、価格が4000円未満の本の中で最大のページ数を求めるコードを書いてください。

        6. wBooksの中で、ページが400ページ以上の書籍を、価格の高い順に表示(タイトルと価格を表示)するコードを書いてください。

        7. wBooksの中で、タイトル"C#"が含まれていてかつ500ページ以下の本を見つけ、本のタイトルを表示するコードを書いてください。
           複数見つかった場合は、そのすべてを表示してください。
        */
        static void Main(string[] args) {
            var wBooks = new List<Book> {
               new Book { Title = "C#プログラミングの新常識", Price = 3800, PageCount = 378 },
               new Book { Title = "ラムダ式とLINQの極意", Price = 2500, PageCount = 312 },
               new Book { Title = "ワンダフル・C#ライフ", Price = 2900, PageCount = 385 },
               new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, PageCount = 464 },
               new Book { Title = "フレーズで覚えるC#入門", Price = 5300, PageCount = 604 },
               new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, PageCount = 453 },
               new Book { Title = "楽しいC#プログラミング教室", Price = 2540, PageCount = 348 },
            };

            // ガード節
            if (wBooks == null) {
                Console.WriteLine("リストが存在しません");
                return;
            }

            // 1.
            Console.WriteLine("問題1");
            var wFindTextBook = wBooks.FirstOrDefault(x => x.Title == "ワンダフル・C#ライフ");
            if (wFindTextBook != null) {
                Console.WriteLine($"{wFindTextBook.Price}円,{wFindTextBook.PageCount}ページ");
            } else {
                Console.WriteLine("この書籍は見つかりません");
            }

            // 2.
            Console.WriteLine("問題2");
            Console.WriteLine(wBooks.Where(x => x.Title.Replace("Ｃ", "C").Replace("＃", "#").ToLower().Contains("c#")).Count());

            // 3.
            Console.WriteLine("問題3");
            var wAveragePageCount = wBooks.Where(x => x.Title.Contains("C#")).Select(y => y.PageCount).DefaultIfEmpty(-1).Average();
            if (wAveragePageCount == -1) {
                Console.WriteLine("C#に関連する書籍が存在しません。");
            } else {
                Console.WriteLine(wAveragePageCount + "ページ");
            }

            // 4.
            Console.WriteLine("問題4");
            var wBookFirstOver4000Yen = wBooks.Where(x => x.Price >= 4000).FirstOrDefault();
            if (wBookFirstOver4000Yen != null) {
                Console.WriteLine($"本のタイトルは「{wBookFirstOver4000Yen.Title}」");
            } else {
                Console.WriteLine("4000円以上の本は見つかりません");
            }

            // 5.
            Console.WriteLine("問題5");
            var wMaxPageCount = wBooks.Where(x => x.Price < 4000).Select(y => y.PageCount).DefaultIfEmpty(-1).Max();
            if (wMaxPageCount == -1) {
                Console.WriteLine("4000円未満の書籍は存在しません。");
            } else {
                Console.WriteLine(wMaxPageCount + "ページ");
            }

            // 6. 
            Console.WriteLine("問題6");
            wBooks.Where(x => x.PageCount >= 400).OrderByDescending(x => x.Price).ToList().ForEach(y => Console.WriteLine($"書籍名: {y.Title},　価格: {y.Price}円"));

            // 7.
            Console.WriteLine("問題7");
            wBooks.Where(x => x.Title.Contains("C#") && x.PageCount <= 500).ToList().ForEach(y => Console.WriteLine($"書籍名: {y.Title}"));
        }
    }
}
