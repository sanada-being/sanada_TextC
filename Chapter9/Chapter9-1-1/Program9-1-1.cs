using System;

namespace Chapter9_1_1 {
    class Program {
        /*
        以下の問題を解いてください。
        1. 指定したC#のソースファイルを読み込み、キーワード"class"が含まれている行数をカウントするコンソールアプリケーションCountClassを作成してください。
           この時、StreamReaderクラスを使い、1行ずつ読み込む処理にしてください。なお、以下の2点を前提として構いません。
        ・classキーワードの前後には必ず空白文字がある
        ・リテラル文字列やコメントの中には"class"という単語は含まれていない
        
        2. このプログラムをFile.ReadAllLinesメソッドを使って書き換えてください。

        3. このプログラムをFile.ReadLinesメソッドを使って書き換えてください。
        */
        static void Main(string[] args) {
            var wCountClass = new CountClass();
            var wFilePath = @"C:\Users\sanada\Desktop\ripository\C#テキスト学習2冊目\Chapter9\Chapter9-1-1\9_CountClass.txt";

            // 1.
            Console.WriteLine($"'class'が含まれている行数: {wCountClass.CountContainClass1(wFilePath)}");
            // 2.
            Console.WriteLine($"'class'が含まれている行数: {wCountClass.CountContainClass2(wFilePath)}");
            // 3.
            Console.WriteLine($"'class'が含まれている行数: {wCountClass.CountContainClass3(wFilePath)}");
        }
    }
}
