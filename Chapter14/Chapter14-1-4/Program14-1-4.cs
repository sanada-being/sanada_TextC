using System;
using System.IO;
using System.Net;

namespace Chapter14_1_4 {
    // あなたがよく訪れるWebページのHTML要素を取得し、ファイルに保存するプログラムを作成してください。
    class Program {
        static void Main(string[] args) {
            var wUrl = "http://abehiroshi.la.coocan.jp/";
            var wFilePath = @"..\..\GetWebPagehtml.txt";

            try {
                var wDirectory = Path.GetDirectoryName(wFilePath);

                if (!Directory.Exists(wDirectory)) {
                    Directory.CreateDirectory(wDirectory);
                    Console.WriteLine("指定したディレクトリを作成しました。");
                }
                using (var wWc = new WebClient()) {
                    wWc.DownloadFile(wUrl, wFilePath);
                    Console.WriteLine("HTML内容をファイルに保存しました");
                }
            } catch (Exception wEx) {
                Console.WriteLine($"エラーが発生しました:{wEx.Message}");
            }
        }
    }
}
