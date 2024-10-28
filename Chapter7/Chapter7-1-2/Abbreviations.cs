using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Chapter7_1_2 {
    /// <summary>
    /// Addreviationsクラス
    /// </summary>
    internal class Abbreviations {
        private Dictionary<string, string> FDict = new Dictionary<string, string>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Abbreviations() {
            var wLines = File.ReadAllLines("Abbreviations.txt");
            FDict = wLines.Select(line => line.Split('=')).ToDictionary(x => x[0], x => x[1]);
        }

        /// <summary>
        /// 要素を追加
        /// </summary>
        /// <param name="vAbbr">省略語</param>
        /// <param name="vJapanese">正式名称</param>
        public void Add(string vAbbr, string vJapanese) {
            FDict[vAbbr] = vJapanese;
        }

        /// <summary>
        /// 省略語をキーに取り正式名称を返す
        /// </summary>
        /// <param name="vAbbr">省略語</param>
        /// <returns>省略語に対する正式名称</returns>
        public string this[string vAbbr] {
            get {
                return FDict.ContainsKey(vAbbr) ? FDict[vAbbr] : null;
            }
        }

        /// <summary>
        /// 正式名称から省略語を返す
        /// </summary>
        /// <param name="vJapanese">正式名称</param>
        /// <returns>正式名称に対する省略語</returns>
        public string ToAbbreviation(string vJapanese) {
            return FDict.FirstOrDefault(x => x.Value == vJapanese).Key;
        }

        // 日本語の位置を引数に与え、それが含まれる要素(Key,Value)をすべて取り出す
        public IEnumerable<KeyValuePair<string, string>> FindAll(string vSubstring) {
            foreach (var wItem in FDict) {
                if (wItem.Value.Contains(vSubstring))
                    yield return wItem;
            }
        }

        /// <summary>
        /// 登録されている用語の数
        /// </summary>
        public int Count {
            get { return FDict.Count; }
        }

        // 2.
        /// <summary>
        /// 省略語を引数に受け取り、その名称を削除する
        /// </summary>
        /// <param name="vAbbr"></param>
        /// <returns>削除の成否</returns>
        public bool Remove(string vAbbr) {
            return FDict.Remove(vAbbr);
        }

        // 4.
        /// <summary>
        /// 3文字の省略語
        /// </summary>
        /// <returns>省略語に対応する名称</returns>
        public IEnumerable<KeyValuePair<string, string>> GetThreeLetterAbbreviations() {
            return FDict.Where(x => x.Key.Length == 3);
        }
    }
}


