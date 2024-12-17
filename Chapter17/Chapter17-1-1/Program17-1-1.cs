using System;
using System.IO;

namespace Chapter17_1_1 {
    //「17.2」で示したTextProcessorクラスを使い、テキストファイルの中の全角数字を半角数字に置き変えて、その結果をコンソールに出力するプログラムを作ってください。
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
                Console.WriteLine($"指定されたファイル '{wFilePath}' は存在しません。");
                return;
            }
            try {
                TextProcessor.Run<ZenkakuToHankakuNumbers>(wFilePath);
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