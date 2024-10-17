using System;
//usingディレクティブで変更した名前空間を指定
using Chapter1_1_1change;

namespace Chapter1_1_1 {
    internal class Program {
        // 問題1.1
        // 「1-1クラス」で定義したProductクラスを使い、以下のコードを書いてください
        // 1.どら焼きオブジェクトを生成するコードをかいてください。
        //　この時の商品番号は"98"、商品価格は"210円"としてください。
        // 2.どら焼きオブジェクトの消費税額を求め、コンソールに出力するコードを書いてください。
        // 3.Productクラスが属する名前空間を別の名前空間に変更し、Mainメソッドから呼び出すようにしてください。
        // ただし、MainメソッドのあるProgramクラスの名前はそのままとしてください。

        static void Main(string[] args) {
            // 1.どら焼きオブジェクトを生成するコードをかいてください。
            var wDorayaki = new Product(98, "どら焼き", 210);

            // 2.どら焼きオブジェクトの消費税額を求め、コンソールに出力するコードを書いてください。
            Console.WriteLine("消費税額は" + wDorayaki.GetTax() + "円です。");

            // 3.変更した名前空間のメソッドをmainメソッドから呼び出し
            Console.WriteLine("税込金額は" + wDorayaki.GetPriceIncludingTax() + "円です。");
        }
    }
}
