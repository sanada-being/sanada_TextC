using System;
using System.Text.RegularExpressions;

namespace Chapter10_1_6 {
    class Program {
        //  5文字の回文とマッチする正規表現を考えてください。記号や数字だけから成る回文は除外してください。
        static void Main(string[] args) {
            var wText = "しんぶんし ええいああ 11111 あいういあ level label とまと pop 111 ___ _@_ 1_1 @a@ あ4い4あ　12321 12_21 _____ 1_@_1 ";
            
            foreach (Match wMatch in Regex.Matches(wText, @"\b(?!(?:[\d\W]{5})\b)(\w)(\w)\w\2\1\b")) {
                Console.WriteLine($"5文字の回文: {wMatch.Value}");
            }
        }
    }
}
