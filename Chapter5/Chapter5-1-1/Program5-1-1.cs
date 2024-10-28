using System;

namespace Chapter5_1_1 {
    class Program {
        /*
        コンソールから入力した2つの文字列が等しいかを調べるコードを書いてください。
        この時、大文字、小文字も違いは無視するようにしてください。
        コンソールからの入力にはConsole.ReadLineメソッドを使用してください。
        */
        static void Main(string[] args) {
            Console.WriteLine("1つ目の文字列を入力してください");
            string wWords1 = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(wWords1)) {
                Console.WriteLine("文字が入力されていません　文字列を入力してください。");
                return;
            } else {
                Console.WriteLine("1つめの文字列:" + wWords1);
            }

            Console.WriteLine("2つ目の文字列を入力してください");
            string wWords2 = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(wWords2)) {
                Console.WriteLine("文字が入力されていません　文字列を入力してください。");
                return;
            } else {
                Console.WriteLine("2つめの文字列:" + wWords2);
            }

            if (string.Compare(wWords1, wWords2, ignoreCase: true) == 0) {
                Console.WriteLine("これらの文字列は等しいです");
            } else {
                Console.WriteLine("これらの文字列は等しくありません");
            }
        }
    }
}
