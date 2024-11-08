using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chapter10_1_6 {
    class Program {
        //  5文字の回文とマッチする正規表現を考えてください。記号や数字だけから成る回文は除外してください。
        static void Main(string[] args) {
            //検討中
            var wText = "しんぶんし ええいああ 11111 あいういあ level label とまと pop 111 ___ _@_ 1_1 @a@ あ4い4あ　12321 12_21 _____ 1_@_1 ";
            var wPattern = @"\b(?!(?:[\d\W]{5})\b)(\w)(\w)\w\2\1\b";
            var wAAA = @"\b(?!(?:[\d\W]{3})\b)(\w)\w\1\b";
            foreach (Match wMatch in Regex.Matches(wText, wPattern)) {
                Console.WriteLine($"5文字の回文: {wMatch.Value}");
            }
        }
    }
}
