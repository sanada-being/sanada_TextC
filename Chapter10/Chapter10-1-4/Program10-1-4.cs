using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Chapter10_1_4 {
    class Program {
        /*
        テキストファイルを読み込み、version="4.0"と書かれた箇所を、version="5.0"に書き換え、 同じファイルに保存してください。
        なお、入力ファイルの = の前後には任意の数の空白文字が入っていることもあります。出力時には、=の前後の空白は削除してください。
        "virsion"は、"Virsion"である可能性もあります。
        */
        static void Main(string[] args) {
            var wFilePath = @"..\..\Sample10-4.txt";

            if (File.Exists(wFilePath)) {
                var wTexts = File.ReadAllText(wFilePath);
                var wPattern = @"(?i)version\s*=\s*""v4\.0""";
                var wReplaced = Regex.Replace(wTexts, wPattern, "version=\"5.0\"");
                Console.WriteLine(wReplaced);
            } else {
                Console.WriteLine("指定したファイルが存在しません ");
            }
        }
    }
}
