using System;
using System.Text.RegularExpressions;

namespace Chapter17_1_1 {
    /// <summary>
    /// 全角数字を半角数字に変換するクラス
    /// </summary>
    internal class ConvertingFromFullwidthToHalfwidth : TextProcessor {
        protected override void Execute(string vLine) {
            var wConvertedLine = Regex.Replace(vLine, "[０-９]", x => ((char)(x.Value[0] - '０' + '0')).ToString());
            Console.WriteLine(wConvertedLine);
        }
    }
}
