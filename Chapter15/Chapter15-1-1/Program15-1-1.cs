using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter15_1_1 {
    internal class Program {
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

            var wBooks = Library.Books;

            if (wBooks == null || !wBooks.Any()) {
                Console.WriteLine("書籍が存在しません");
                return;
            }

            // 2.
            Console.WriteLine("問題2");
            var wMaxPrice = wBooks.Max(x => x.Price);
            Console.WriteLine(wBooks.First(x => x.Price == wMaxPrice));

            // 3.
            Console.WriteLine("問題3");
            foreach (var wYearGroup in wBooks.GroupBy(x => x.PublishedYear).OrderBy(x => x.Key)) {
                Console.WriteLine($"{wYearGroup.Key}年：{wYearGroup.Count()}冊");
            }

            // 4.
            Console.WriteLine("問題4");
            foreach (var wBook in wBooks.OrderByDescending(x => x.PublishedYear).ThenByDescending(x => x.Price)) {
                Console.WriteLine(wBook);
            }

            // 5.
            Console.WriteLine("問題5");
            Console.WriteLine("2016年に出版された書籍のカテゴリ一覧");
            var wCategoryIds = wBooks.Where(x => x.PublishedYear == 2016).Select(x => x.CategoryId).Distinct();
            var wCategoryNames = wCategoryIds.Join(Library.Categories, book => book, category => category.Id, (book, category) => category.Name);

            foreach (var wCategoryName in wCategoryNames) {
                Console.WriteLine(wCategoryName);
            }

            // 6.
            Console.WriteLine("問題6");
            var wBooksByCategory = wBooks.Join(Library.Categories, x => x.CategoryId, y => y.Id, (x, y) => new { x, y }).GroupBy(z => z.y.Name).OrderBy(z => z.Key);
            foreach (var wCategoryGroup in wBooksByCategory) {
                Console.WriteLine($"カテゴリ名: {wCategoryGroup.Key}");
                foreach (var wBook in wCategoryGroup) {
                    Console.WriteLine(wBook.x.Title);
                }
            }

            // 7.
            Console.WriteLine("問題7");
            int wDevelopmentCategoryId = Library.Categories.First(x => x.Name == "Development").Id;

            IEnumerable<IGrouping<int, Book>> wBooksByYear = wBooks.Where(x => x.CategoryId == wDevelopmentCategoryId).GroupBy(x => x.PublishedYear).OrderBy(x => x.Key);
            foreach (var wBooksGroupedByYear in wBooksByYear) {
                Console.WriteLine($"{wBooksGroupedByYear.Key}年に発行された書籍");
                foreach (var wBook in wBooksGroupedByYear) {
                    Console.WriteLine(wBook);
                }
            }

            Console.WriteLine("問題8");
            var wCategoriesWithManyBooks = Library.Categories.GroupJoin(Library.Books, x => x.Id, y => y.CategoryId, (x, y) => new { x.Name, Books = y });
            foreach (var wCategory in wCategoriesWithManyBooks.Where(x => x.Books.Count() >= 4)) {
                Console.WriteLine($"4冊以上発行されているカテゴリ名:{wCategory.Name}");
            }
        }
    }
}
