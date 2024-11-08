using System;
using System.Text.RegularExpressions;

namespace Chapter10_1_3 {
    class Program {
        /*
        以下の文字配列wTextsから、単語"time"が含まれる文字列を取り出し、timeの開始位置をすべて出力してください。
        大文字/小文字の区別なく検索してください。
                */
        static void Main(string[] args) {
            var wTexts = new[]{
              "Time is Money.",
              "What time is it?",
              "IT will take time.",
              "We reorganized the timetable.",
            };

            foreach (var wText in wTexts) {
                var wMatches = Regex.Matches(wText, @"\btime\b", RegexOptions.IgnoreCase);

                if (wMatches.Count > 0) {
                    Console.WriteLine($"単語: \"{wText}\"");
                    foreach (Match wMatch in wMatches) {
                        Console.WriteLine($"timeの位置:{wMatch.Index}");
                    }
                } else {
                    Console.WriteLine("この文字列内に単語\"time\"は存在しません");
                }
            }
        }
    }
}