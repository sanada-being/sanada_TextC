using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Chapter14_1_4 {
    // あなたがよく訪れるWebページのHTML要素を取得し、ファイルに保存するプログラムを作成してください。
    class Program {
        static async Task Main(string[] args) {
            var wUrl = "http://abehiroshi.la.coocan.jp/";
            Console.Write("保存先のファイルパスを入力してください: ");
            var wFilePath = Console.ReadLine();

            try {
                var wDirectory = Path.GetDirectoryName(wFilePath);
                Directory.CreateDirectory(wDirectory);

                using (var wClient = new HttpClient()) {
                    var wContent = await wClient.GetStringAsync(wUrl);
                    File.WriteAllText(wFilePath, wContent);
                    Console.WriteLine("HTML内容をファイルに保存しました");
                }
            }
            catch (HttpRequestException wEx) {
                Console.WriteLine($"Web への接続に失敗しました: {wEx.Message}");
            }
            catch (UnauthorizedAccessException wEx) {
                Console.WriteLine($"ファイルへのアクセス権限がありません: {wEx.Message}");
            }
            catch (Exception wEx) {
                Console.WriteLine($"エラーが発生しました:{wEx.Message}");
            }
        }
    }
}



