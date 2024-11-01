using System;

namespace Chapter7_1_2 {
    internal class Program {
        /*
        「7.3:ディクショナリを使ったサンプルプログラム」で作成したプログラムに、以下の機能を追加してください。

        1. ディクショナリに登録されている用語の数を返すCountプロパティをAbbreviationsクラスに追加してください。

        2. 省力語を引数に受け取るRemoveメソッドをAbbreviationsクラスに追加してください。
           要素が見つからない場合はfalseを、削除できた場合はtureを返してください。

        3. CountプロパティとRemoveメソッドを利用するコードを書いてください。

        4. 3文字の省略語だけを取り出し、以下の形式でコンソールに出力するコードを書いてください。
           必要ならAbbreviationsクラスに新たなメソッドを追加してください。

           ILO=国際労働機関
           IMF=国際通貨基金  ....
        */
        static void Main(string[] args) {
            // コンストラクタ呼び出し
            var wAbbrs = new Abbreviations();

            // Addメソッドの呼び出し例
            wAbbrs.Add("IOC", "国際オリンピック委員会");
            wAbbrs.Add("NPT", "核兵器不拡散条約");
            　
            // 3.　辞書内の要素数を取得し、省略語を削除する
            Console.WriteLine("問題3");
            Console.WriteLine("削除前の省略語の数: " + wAbbrs.Count);

            string wVAbbrToRemove = "IOC";
            if (wAbbrs.Remove(wVAbbrToRemove)) {
                Console.WriteLine($"{wVAbbrToRemove} を削除しました");
            } else {
                Console.WriteLine($"{wVAbbrToRemove} は見つかりませんでした");
            }
            Console.WriteLine("削除後の省略語の数: " + wAbbrs.Count);

            // 4.
            Console.WriteLine("問題4");
            foreach (var wItem in wAbbrs.GetThreeLetterAbbreviations()) {
                Console.WriteLine($"{wItem.Key}={wItem.Value}");
            }

            // インデクサの利用例
            Console.WriteLine();
            var wNames = new[] { "WHO", "FIFA", "NPT", };
            foreach (var wName in wNames) {
                var wFullname = wAbbrs[wName];
                if (wFullname == null)
                    Console.WriteLine("{0}は見つかりません", wName);
                else
                    Console.WriteLine("{0}={1}", wName, wFullname);
            }
            Console.WriteLine();

            // ToAbbreviationメソッドの利用例
            var wJapanese = "東南アジア諸国連合";
            var wAbbreviation = wAbbrs.ToAbbreviation(wJapanese);
            if (wAbbreviation == null)
                Console.WriteLine("{0} は見つかりません", wJapanese);
            else
                Console.WriteLine("「{0}」の略語は {1} です", wJapanese, wAbbreviation);
            Console.WriteLine();

            // FindAllメソッドの利用例
            foreach (var wItem in wAbbrs.FindAll("国際")) {
                Console.WriteLine("{0}={1}", wItem.Key, wItem.Value);
            }
            Console.WriteLine();
        }
    }
}
