using System;
using System.IO;
using System.Threading.Tasks;

namespace Chapter16_1_1 {
    /*StreamReaderクラスにあるReadLineAsyncメソッドを使い、テキストファイルを非同期で読み込むコードを書いてください。
     ファイルパス: ..\..\sample16-1-1.txt
    */
    class Program {
        static async Task Main(string[] args) {
            Console.WriteLine("読み込むファイルを指定してください");
            var wFilePath = Console.ReadLine();

            if (!File.Exists(wFilePath)) {
                Console.WriteLine("指定したファイルが存在しません");
                return;
            }
            try {
                using (var wReader = new StreamReader(wFilePath)) {
                    while (!wReader.EndOfStream) {
                        var wLine = await wReader.ReadLineAsync();
                        if (wLine == null) break;
                        Console.WriteLine(wLine);
                    }
                    Console.WriteLine("ファイルの読み込みが完了しました");
                }
            }
            catch (FileLoadException wEx) {
                Console.WriteLine($"ファイルの読み込みに失敗しました: {wEx.Message}");
            }
            catch (OutOfMemoryException wEx) {
                Console.WriteLine($"メモリ不足: {wEx.Message}");
            }
            catch (Exception wEx) {
                Console.WriteLine($"エラーが発生しました:{wEx.Message}");
            }
        }
    }
}