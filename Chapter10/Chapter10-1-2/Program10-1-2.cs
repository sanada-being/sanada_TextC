using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chapter10_1_2 {
    class Program {
        // テキストファイル@"..\..\Sample10-2.txt"を読み込み、3文字以上の数字だけから成る部分文字列をすべて抜き出すコードを書いてください。
        static void Main(string[] args) {
            Console.WriteLine("ファイルパスを入力してください");
            var wFilePath = Console.ReadLine();

            if (!File.Exists(wFilePath)) {
                Console.WriteLine("指定したファイルは存在しません");
                return;
            }
            try {
                var wTexts = File.ReadAllText(wFilePath);
                var w3OrMoreNumbers = Regex.Matches(wTexts, @"\d{3,}").Cast<Match>().ToList();
                w3OrMoreNumbers.ForEach(x => Console.WriteLine(x.Value));
            } catch (UnauthorizedAccessException) {
                Console.WriteLine("ファイルにアクセスする権限がありません");
            } catch (IOException) {
                Console.WriteLine("ファイルの読み込み中にエラーが発生しました");
            } catch (Exception wEx) {
                Console.WriteLine($"予期しないエラーが発生しました:{wEx.Message} ");
            }
        }
    }
}