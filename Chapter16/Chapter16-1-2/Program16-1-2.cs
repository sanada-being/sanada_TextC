using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Chapter16_1_2 {
    /*
    指定したディレクトリ(..\..\..\..\..\C#テキスト学習2冊目)にあるC#のソースファイルの中をすべて検索し、キーワードasyncとawaitの両方を利用しているファイルを列挙してください。
    列挙する際はファイルのフルパスを表示してください。表示する順番は問いません。
    並列処理をした場合としない場合の2つのバージョンを作成し、どれくらい速度に差があるかも調べてください。
    */
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("検索するディレクトリを指定してください");
            var wGetPath = Console.ReadLine();
            var wSearchdirectory = new DirectoryInfo(wGetPath);

            if (!wSearchdirectory.Exists) {
                Console.WriteLine("指定したディレクトリは存在しません");
                return;
            }

            IEnumerable<FileInfo> wFiles = wSearchdirectory.EnumerateFiles("*.cs", SearchOption.AllDirectories);

            //直列処理
            var wSerialProcessingTime = new Stopwatch();
            wSerialProcessingTime.Start();

            try {
                foreach (var wAsynchronizedFile in wFiles) {
                    string wFileContent = File.ReadAllText(wAsynchronizedFile.FullName);

                    if (wFileContent.Contains("async") && wFileContent.Contains("await"))
                        Console.WriteLine(wAsynchronizedFile.FullName);
                }
            }
            catch (FileNotFoundException wEx) {
                Console.WriteLine("ファイルが見つかりません: " + wEx.Message);
            }
            catch (UnauthorizedAccessException wEx) {
                Console.WriteLine("アクセス権限がありません: " + wEx.Message);
            }
            catch (IOException wEx) {
                Console.WriteLine("I/Oエラーが発生しました: " + wEx.Message);
            }
            catch (Exception wEx) {
                Console.WriteLine("予期しないエラーが発生しました: " + wEx.Message);
            }

            wSerialProcessingTime.Stop();
            Console.WriteLine($"直列処理時間：{wSerialProcessingTime.ElapsedMilliseconds}ms");

            //並列処理
            var wParallelProcessingTime = new Stopwatch();
            wParallelProcessingTime.Start();
            try {
                wFiles.AsParallel().Where(x => {
                    string wFileContent = File.ReadAllText(x.FullName);
                    return wFileContent.Contains("async") && wFileContent.Contains("await");
                })
                    .ToList().ForEach(x => Console.WriteLine(x.FullName));
            }
            catch (FileNotFoundException wEx) {
                Console.WriteLine("ファイルが見つかりません: " + wEx.Message);
            }
            catch (UnauthorizedAccessException wEx) {
                Console.WriteLine("アクセス権限がありません: " + wEx.Message);
            }
            catch (IOException wEx) {
                Console.WriteLine("I/Oエラーが発生しました: " + wEx.Message);
            }
            catch (Exception wEx) {
                Console.WriteLine("予期しないエラーが発生しました: " + wEx.Message);
            }
            wParallelProcessingTime.Stop();
            Console.WriteLine($"並列処理時間：{wParallelProcessingTime.ElapsedMilliseconds}ms");
        }
    }
}
