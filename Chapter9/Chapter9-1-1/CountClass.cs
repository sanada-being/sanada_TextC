using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

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
                        if (Regex.IsMatch(wLine, @"\sclass\s")) {
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
                wClassCount2 = File.ReadAllLines(vFilePath).Count(x => Regex.IsMatch(x, @"\sclass\s"));
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
                wClassCount3 = File.ReadLines(vFilePath).Count(x => Regex.IsMatch(x, @"\sclass\s"));
            } else {
                Console.WriteLine("指定したファイルが存在しません");
            }
            return wClassCount3;
        }
    }
}
