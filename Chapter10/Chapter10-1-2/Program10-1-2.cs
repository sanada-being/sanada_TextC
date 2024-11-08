using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chapter10_1_2 {
    class Program {
        // テキストファイルを読み込み、3文字以上の数字だけから成る部分文字列をすべて抜き出すコードを書いてください。
        static void Main(string[] args) {
            var wFilePath = @"..\..\Sample10-2.txt";
            if (File.Exists(wFilePath)) {
                var wTexts = File.ReadAllText(wFilePath);
                var w3OrMoreNumbers = Regex.Matches(wTexts, @"\d{3,}").Cast<Match>().ToList();
                w3OrMoreNumbers.ForEach(x => Console.WriteLine(x.Value));
            } else {
                Console.WriteLine("指定したファイルが存在しません");
            }
        }
    }
}
