using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chapter10_1_2 {
    class Program {
        // テキストファイルを読み込み、3文字以上の数字だけから成る部分文字列をすべて抜き出すコードを書いてください。
        static void Main(string[] args) {
            var wFilePath = @"aaa.txt";
            var wLines = File.ReadAllLines(wFilePath).ToString();
            var w3OrMoreNumbers = Regex.Matches(wLines, @"ここに絞り込み条件");
            foreach (Match wMatch in w3OrMoreNumbers) {
                Console.WriteLine($"{wMatch.Value}");
            }
        }
    }
}
