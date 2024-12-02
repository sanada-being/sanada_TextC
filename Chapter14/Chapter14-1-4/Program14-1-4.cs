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

                using (var client = new HttpClient()) {
                    var content = await client.GetByteArrayAsync(wUrl);
                    File.WriteAllBytes(wFilePath, content);
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



