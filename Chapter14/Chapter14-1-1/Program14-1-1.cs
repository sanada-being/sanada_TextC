using System;
using System.Diagnostics;
using System.IO;

namespace Chapter14_1_1 {
    class Program {
        /*
        ファイル@"..\..\Sample14-1.txt"にプログラムのパスとパラメータが複数行書かれています。このファイルを読み込み、プログラムを順に起動するプログラムを書いてください。
        1つのプログラムが終わるのを待って次のプログラムを起動してください。
        入力するファイルの形式は、通常のテキストファイルでもXMLファイルでも構いません。
        */
        static void Main(string[] args) {
            Console.WriteLine("ファイルパスを入力してください");
            var wFilePath = Console.ReadLine();

            if (!File.Exists(wFilePath)) {
                Console.WriteLine("指定したファイルパスが存在しません");
                return;
            }
            try {
                var wFullPath = Environment.ExpandEnvironmentVariables(wFilePath);
                var wLines = File.ReadAllLines(wFullPath);
                foreach (var wLine in wLines) {
                    if (string.IsNullOrEmpty(wLine)) continue;
                    RunProgram(wLine);
                }
            } catch (Exception wEx) {
                Console.WriteLine($"エラーが発生しました: {wEx.Message}");
            }
        }

        /// <summary>
        ///  ファイル内プログラム実行メソッド
        /// </summary>
        /// <param name="vLine">ファイル内のプログラムのパス</param>
        static void RunProgram(string vLine) {
            var wParts = vLine.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);

            if (wParts.Length == 0) {
                Console.WriteLine($"無効な行です: {vLine}");
                return;
            }
            string wProgramPath = Path.GetFullPath(wParts[0]);

            if (!File.Exists(wProgramPath)) {
                Console.WriteLine($"指定したプログラムが見つかりません: {wProgramPath}");
                return;
            }

            string wArguments = wParts.Length > 1 ? wParts[1] : string.Empty;
            try {
                var wProcess = new Process();
                wProcess.StartInfo.FileName = wProgramPath;
                wProcess.StartInfo.Arguments = wArguments;
                wProcess.Start();
                wProcess.WaitForExit();
                Console.WriteLine($"{wProgramPath} の実行が完了しました");
            } catch (Exception wEx) {
                Console.WriteLine($"エラーが発生しました: {wEx.Message}");
            }
        }
    }
}




