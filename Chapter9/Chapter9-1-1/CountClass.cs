using System;
using System.IO;

namespace Chapter9_1_1 {
    /// <summary>
    /// classカウントクラス
    /// </summary>
    class CountClass {

        // 1.
        /// <summary>
        /// "class"が入る行数をStreamReaderでカウント
        /// </summary>
        /// <param name="vFilePath">ファイルのパス</param>
        /// <returns>classが見つかった行数</returns>
        /// 
        public int CountContainClass1(string vFilePath) {
            int wClassCount = 0;

            if (File.Exists(vFilePath)) {
                using (var wReader = new StreamReader(vFilePath)) {
                    while (!wReader.EndOfStream) {
                        var wLine = wReader.ReadLine();
                        if (wLine.Contains("class")) {
                            wClassCount++;
                        }
                    }
                }
            } else {
                Console.WriteLine("指定したファイルが存在しません");
            }
            return wClassCount;
        }

        // 2.
        /// <summary>
        ///  "class"が入る行数をReadAllLinesでカウント
        /// </summary>
        /// <param name="vFilePath">ファイルのパス</param>
        /// <returns>classが見つかった行数</returns>
        public int CountContainClass2(string vFilePath) {
            int wClassCount2 = 0;

            if (File.Exists(vFilePath)) {
                var wLines2 = File.ReadAllLines(vFilePath);

                foreach (var wLine2 in wLines2) {
                    if (wLine2.Contains("class")) {
                        wClassCount2++;
                    }
                }
            } else {
                Console.WriteLine("指定したファイルが存在しません");
            }
            return wClassCount2;
        }

        // 3.
        /// <summary>
        ///  "class"が入る行数をReadLinesでカウント
        /// </summary>
        /// <param name="vFilePath">ファイルのパス</param>
        /// <returns>classが見つかった行数</returns>
        public int CountContainClass3(string vFilePath) {
            int wClassCount3 = 0;

            if (File.Exists(vFilePath)) {
                var wLines3 = File.ReadLines(vFilePath);

                foreach (var wLine3 in wLines3) {
                    if (wLine3.Contains("class")) {
                        wClassCount3++;
                    }
                }
            } else {
                Console.WriteLine("指定したファイルが存在しません");
            }
            return wClassCount3;
        }
    }
}
