using System;
using System.Text.RegularExpressions;

namespace Chapter10_1_1 {
    class Program {
        /*
           指定された文字列が携帯電話の番号かどうかを判定するメソッドを定義してください。
           電話番号は必ずハイフン(-)で区切られていなければなりません。
           また、頭3文字は"090","080","070",のいずれかとします。
        */
        static void Main(string[] args) {
            var wPhoneNumber = "090-1111-2222";
            var wPhoneNumber2 = "111-2222";
            CheckPhoneNumber(wPhoneNumber);
            CheckPhoneNumber(wPhoneNumber2);
        }

        /// <summary>
        /// 携帯電話の番号判定メソッド
        /// </summary>
        /// <param name="vPhoneNumber">判定する番号</param>
        public static void CheckPhoneNumber(string vPhoneNumber) {
            string wPattern = @"^(090|080|070)-\d{4}-\d{4}$";

            if (Regex.IsMatch(vPhoneNumber, wPattern)) {
                Console.WriteLine($"{vPhoneNumber}は携帯電話の番号です");
            } else {
                Console.WriteLine($"{vPhoneNumber}は携帯電話の番号ではありません");
            }
        }
    }
}
