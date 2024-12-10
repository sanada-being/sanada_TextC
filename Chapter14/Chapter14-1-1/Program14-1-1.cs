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

            if (!ExistsTextFile(wFullPath)) {
                return;
            }

            try {
                foreach (var wLine in File.ReadAllLines(wFullPath)) {
                    RunProgram(wLine);
                }
            } catch (Exception wEx) {
                Console.WriteLine($"エラーが発生しました: {wEx.Message}");
            }
        }

        /// <summary>
        /// .txtファイルが入力されたか判定メソッド
        /// </summary>
        /// <param name="vFilePath">入力されたファイルパス</param>
        /// <returns>判定結果(true か false)</returns>
        static bool ExistsTextFile(string vFilePath) {
            if (!File.Exists(vFilePath)) {
                Console.WriteLine("指定したファイルパスが存在しません");
                return false;
            }

            if (Path.GetExtension(vFilePath).ToLower() != ".txt") {
                Console.WriteLine("指定したファイルはテキストファイルではありません");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 文字列をプログラムパスと引数に分割するメソッド
        /// </summary>
        /// <param name="vLine">ファイルから読み込んだ行</param>
        /// <returns>プログラムパスと引数に分割した配列</returns>
        static string[] SplitProgramAndArguments(string vLine) {
            if (string.IsNullOrWhiteSpace(vLine)) {
                Console.WriteLine("指定したファイルの中身がありません");
                return null;
            }
            return vLine.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// プログラムパスが有効かを判定するメソッド
        /// </summary>
        /// <param name="vProgramPath">分割メソッドで分割されたプログラムパス</param>
        /// <returns>有効なパスならtrue,それ以外はfalse</returns>
        static bool IsProgramPathValid(string vProgramPath) {
            string wProgramPath = Path.GetFullPath(vProgramPath);
            return File.Exists(wProgramPath);
        }

        /// <summary>
        /// プログラム実行メソッド
        /// </summary>
        /// <param name="vLine">プログラムパスと引数を含む文字列</param>
        static void RunProgram(string vLine) {
            string[] wProgramAndParamsInfo = SplitProgramAndArguments(vLine);
            if (wProgramAndParamsInfo == null) return;

            string wProgramPath = wProgramAndParamsInfo[0];

            if (!IsProgramPathValid(wProgramPath)) {
                Console.WriteLine($"指定したプログラムが見つかりません: {wProgramPath}");
                return;
            }

            string wArguments = wProgramAndParamsInfo.Length > 1 ? wProgramAndParamsInfo[1] : string.Empty;

            try {
                using (var wProcess = Process.Start(wProgramPath, wArguments)) {
                    wProcess.WaitForExit();
                    Console.WriteLine($"{wProgramPath} の実行が完了しました");
                }
            } catch (Exception wEx) {
                Console.WriteLine($"エラーが発生しました: {wEx.Message}");
            }
        }
    }
}



