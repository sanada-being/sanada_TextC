using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chapter10_1_1 {
    internal class Program {
        static void Main(string[] args) {
            var wText = "RegexクラスのMatchメソッドを使います";
            var wMatches = Regex.Matches(wText, @"\p{IsKatakana}+");
            foreach (Match wMatch in wMatches) {
                Console.Write($"{wMatch.Index},{wMatch.Length},{wMatch.Value}");
            }
        }
    }
}
