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
            catch (Exception wEx) {
                ExceptionHandler.HandleException(wEx);
            }
            wSerialProcessingTime.Stop();
            Console.WriteLine($"直列処理時間：{wSerialProcessingTime.ElapsedMilliseconds}ms");
        }
    }
}
