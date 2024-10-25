using System;
using System.Linq;
using System.Text;

namespace Chapter5_1_3 {
    internal class Program {
        /*
        "Jackdaws love my big sphinx of quartz"という文字列があります。
        この文字列に対して、以下の問題を解いてみてください。

        1. 空白が何文字あるかカウントしてください。

        2. 字列の中の"big"という部分文字列を"small"に置き換えてください。

        3. 単語がいくつあるかカウントしてください。

        4. 4文字以下の単語を列挙してください。

        5. 空白で区切り、配列に格納した後、StringBuilderクラスを使い文字列を連結させ、
           元の文字列と同じものを作り出して下さい。元の文字列の中には連続した空白は存在しないものとする。
        */
        static void Main(string[] args) {
            // 1.
            Console.WriteLine("問題1");
            var wSentence = "Jackdaws love my big sphinx of quartz";
            Console.WriteLine("空白の数は" + wSentence.Count(char.IsWhiteSpace));

            // 2.
            Console.WriteLine("問題2");
            Console.WriteLine(wSentence.Replace("big", "small"));

            // 3.
            Console.WriteLine("問題3");
            string[] wWords = wSentence.Split(' ');
            Console.WriteLine("単語の数は" + wWords.Count());

            // 4.
            Console.WriteLine("問題4");
            foreach (var wWord in wWords.Where(x => x.Length <= 4).ToArray()) {
                Console.WriteLine(wWord);
            }
            // 5.
            Console.WriteLine("問題5");
           var wConnectedWords = new StringBuilder();
            foreach (var wWord in wWords) {
                wConnectedWords.Append(wWord);
            }
            Console.WriteLine(wConnectedWords.ToString());
        }
    }
}
