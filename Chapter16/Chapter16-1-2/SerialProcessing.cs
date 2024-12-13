using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Chapter16_1_2 {
    /// <summary>
    /// 直列処理クラス
    /// </summary>
    public class SerialProcessing {

        /// <summary>
        ///  asyncとawaitが使われているファイルを列挙する直列処理メソッド
        /// </summary>
        /// <param name="vFiles">処理を行う.csファイル</param>
        public void SerialProcessFiles(IEnumerable<FileInfo> vFiles) {
            var wSerialProcessingTime = new Stopwatch();
            wSerialProcessingTime.Start();

            try {
                foreach (var wAsynchronizedFile in vFiles) {
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
        }
    }
}
