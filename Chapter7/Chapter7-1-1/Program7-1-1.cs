using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter7_1_1 {
    internal class Program {
        /*
        "Cozy lummox gives smart squid who asks for job pen"という文字列があります。
        この文字列に対して、以下のコードを書いてください。

        1. 各アルファベット文字（空白などアルファベット以外は除外)が何文字ずつ現れるかカウントするプログラムを書いてください。
        この時に、必ずディクショナリクラスを使ってください。
        大文字/小文字の区別はしないでください。
        以下の形式で出力してください。
        'A': 2
        'B': 1
        'C': 1  ....

        2. 上記プログラムを、SortedDictionary<TKey,TValue>を使って書き換えてください。
        */


        static void Main(string[] args) {
            string wSentence = "Cozy lummox gives smart squid who asks for job pen";
            // 1. 
            var wLetterCounts = new Dictionary<char, int>();

            foreach (char wCurrentChar in wSentence.ToLower()) {
                if (char.IsLetter(wCurrentChar)) {

                    if (wLetterCounts.TryGetValue(wCurrentChar, out int wCount)) {
                        wLetterCounts[wCurrentChar] = wCount + 1;
                    } else {
                        wLetterCounts[wCurrentChar] = 1;
                    }
                }
            }

            foreach (var wItem in wLetterCounts.OrderBy(x => x.Key)) {
                Console.WriteLine($"'{char.ToUpper(wItem.Key)}': {wItem.Value}");
            }

            // 2.
            Console.WriteLine("問題2");
            var wLetterCounts2 = new SortedDictionary<char, int>();

            foreach (char wCurrentChar in wSentence.ToLower()) {
                if (char.IsLetter(wCurrentChar)) {
                    if (wLetterCounts.ContainsKey(wCurrentChar)) {
                        wLetterCounts[wCurrentChar]++;
                    } else {
                        wLetterCounts[wCurrentChar] = 1;
                    }
                }
            }

            foreach (var wItem in wLetterCounts2) {
                Console.WriteLine($"'{char.ToUpper(wItem.Key)}': {wItem.Value}");
            }
        }
    }
}
