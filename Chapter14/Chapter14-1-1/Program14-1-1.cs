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

            var wFullPath = Environment.ExpandEnvironmentVariables(wFilePath);
            if (!CheckIfTextFile(wFilePath)) {
                return;
            }
            try {
                foreach (var wLine in File.ReadAllLines(wFullPath)) {
                    if (string.IsNullOrEmpty(wLine)) continue;
                    RunProgram(wLine);
                }
            }
            catch (Exception wEx) {
                Console.WriteLine($"エラーが発生しました: {wEx.Message}");
            }
        }

        /// <summary>
        /// .txtファイルが入力されたか判定メソッド
        /// </summary>
        /// <param name="vFilePath">入力されたファイルパス</param>
        /// <returns>判定結果(true か false)</returns>
        static bool CheckIfTextFile(string vFilePath) {
            if (!File.Exists(vFilePath)) {
                Console.WriteLine("指定したファイルパスが存在しません");
                return false;
            }
            var wExtension = Path.GetExtension(vFilePath).ToLower();
            if (wExtension != ".txt") {
                Console.WriteLine("指定したファイルはテキストファイルではありません");
                return false;
            }
            return true;
        }

        /// <summary>
        ///  ファイル内プログラム実行メソッド
        /// </summary>
        /// <param name="vLine">ファイル内のプログラムのパス</param>
        static void RunProgram(string vLine) {
            var wProgramAndParamsInfo = vLine.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);

            if (wProgramAndParamsInfo.Length == 0) {
                Console.WriteLine($"無効な行です: {vLine}");
                return;
            }
            string wProgramPath = Path.GetFullPath(wProgramAndParamsInfo[0]);

            if (!File.Exists(wProgramPath)) {
                Console.WriteLine($"指定したプログラムが見つかりません: {wProgramPath}");
                return;
            }

            string wArguments = wProgramAndParamsInfo.Length > 1 ? wProgramAndParamsInfo[1] : string.Empty;
            try {
                using (var wProcess = Process.Start(wProgramPath, wArguments)) {
                    wProcess.Start();
                    wProcess.WaitForExit();
                    Console.WriteLine($"{wProgramPath} の実行が完了しました");
                }
            }
            catch (Exception wEx) {
                Console.WriteLine($"エラーが発生しました: {wEx.Message}");
            }
        }
    }
}



