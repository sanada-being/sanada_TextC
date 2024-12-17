using System;
using System.IO;

namespace Chapter17_1_3 {
    // 問題文はテキストP430 問題17.3を参照してください。
    class Program {
        static void Main(string[] args) {

            var wFilePath = string.Empty;

            if (args.Length == 0) {
                Console.WriteLine("ファイルパスを指定してください。");
                Console.Write("ファイルパス:");
                wFilePath = Console.ReadLine();
            }
            else {
                wFilePath = args[0];
            }

            if (!File.Exists(wFilePath)) {
                Console.WriteLine($"指定したファイルが見つかりません{wFilePath}");
                return;
            }
            try {
                var wProcessor = new TextFileProcessor17_3(new ZenkakuToHankakuNumbers17_3());
                wProcessor.Run(wFilePath);
            }
            catch (UnauthorizedAccessException wEx) {
                Console.WriteLine($"アクセス権限がありません: {wEx.Message}");
            }
            catch (IOException wEx) {
                Console.WriteLine($"入出力エラーが発生しました: {wEx.Message}");
            }
            catch (Exception wEx) {
                Console.WriteLine($"予期しないエラーが発生しました: {wEx.Message}");
            }
        }
    }
}
