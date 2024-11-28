using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter15_1_1 {
    class Program {
        /*
        1. Libraryクラスにコンストラクタを追加し、本章の最初に示した書籍のカテゴリデータと書籍データの値を、CategoresプロパティとBooksプロパティにセットするコードを書いてください。
        2. 最も価格の高い書籍を抽出し、その書籍の情報をコンソールに出力してください。
        3. 発行年ごとに書籍の数をカウントして、その結果をコンソールに出力してください。
        4. 発行年、価格の順（それぞれ値の大きい順）に並び替え、その結果をコンソールに出力してください。
        5. 2016年に発行された書籍のカテゴリ一覧を取得し、コンソールに出力してください。
        6. GroupByメソッドを使い、カテゴリごとに書籍を分類しカテゴリ名をアルファベット順に並び替え、その結果をコンソールに出力してください。
        7. カテゴリ"Development"の書籍に対して、発行年ごとに分類し、その結果をコンソールに出力してください。
        8. GroupJoinメソッドを使って4冊以上発行されているカテゴリ名を求め、そのカテゴリ名をコンソールに出力してください。
        */
        static void Main(string[] args) {
            // 2.
            Console.WriteLine("問題2");
            Console.WriteLine(Library.Books.First(x => x.Price == Library.Books.Max(y => y.Price)));

            // 3.
            Console.WriteLine("問題3");
            foreach (var wYearGroup in Library.Books.GroupBy(x => x.PublishedYear).OrderBy(x => x.Key).Select(x => new { Year = x.Key, Count = x.Count() })) {
                Console.WriteLine($"{wYearGroup.Year}年：{wYearGroup.Count}冊");
            }

            // 4.
            Console.WriteLine("問題4");
            foreach (var wBook in Library.Books.OrderByDescending(x => x.PublishedYear).ThenByDescending(x => x.Price)) {
                Console.WriteLine(wBook);
            }

            // 5.
            Console.WriteLine("問題5");
            Console.WriteLine("2016年に出版された書籍のカテゴリ一覧");
            foreach (var wBook in Library.Books.Where(x => x.PublishedYear == 2016)) {
                Console.WriteLine(wBook.CategoryId);
            }

            // 6.
            Console.WriteLine("問題6");
            foreach (var wBooksByCategory in Library.Books.Join(Library.Categories, x => x.CategoryId, y => y.Id, (x, y) => new { x, y }).GroupBy(z => z.y.Name).OrderBy(z => z.Key)) {
                Console.WriteLine($"カテゴリ名: {wBooksByCategory.Key}");
            }

            // 7.
            Console.WriteLine("問題7");
            int wDevelopmentCategoryId = Library.Categories.First(x => x.Name == "Development").Id;

            IEnumerable<IGrouping<int, Book>> wBooksByYear = Library.Books.Where(x => x.CategoryId == wDevelopmentCategoryId).GroupBy(x => x.PublishedYear).OrderBy(x => x.Key);
            foreach (var wBooksGroupedByYear in wBooksByYear) {
                Console.WriteLine($"{wBooksGroupedByYear.Key}年に発行された書籍");
                foreach (var wBook in wBooksGroupedByYear) {
                    Console.WriteLine(wBook);
                }
            }

            Console.WriteLine("問題8");
            var wCategoriesWithManyBooks = Library.Categories.GroupJoin(Library.Books, x => x.Id, y => y.CategoryId, (x, y) => new { x.Name, Books = y }).Where(x => x.Books.Count() >= 4);
            foreach (var wCategory in wCategoriesWithManyBooks) {
                Console.WriteLine($"4冊以上発行されているカテゴリ名:{wCategory.Name}");
            }
        }
    }
}
