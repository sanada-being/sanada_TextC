using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;

namespace Chapter16_1_2 {
    /// <summary>
    /// 並列処理クラス
    /// </summary>
    public class ParallelProcessing {

        /// <summary>
        /// asyncとawaitが使われているファイルを列挙する並列処理メソッド
        /// </summary>
        /// <param name="vFiles">処理を行う.csファイル</param>
        public void ParallelProcessFiles(IEnumerable<FileInfo> vFiles) {
            var wParallelProcessingTime = new Stopwatch();
            wParallelProcessingTime.Start();

            try {
                vFiles.AsParallel().Where(x => {
                    string wFileContent = File.ReadAllText(x.FullName);
                    return wFileContent.Contains("async") && wFileContent.Contains("await");
                })
                    .ToList().ForEach(x => Console.WriteLine(x.FullName));
            }
            catch (Exception wEx) {
                ExceptionHandler.HandleException(wEx);
            }
        }
    }
}
