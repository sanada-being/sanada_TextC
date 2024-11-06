using System;
using System.IO;

namespace Chapter9_1_3 {
    class Program {
        /*
        あるテキストファイルの最初と最後に別のテキストファイルの内容を追加するコンソールアプリケーションを書いてください。
        コマンドラインで2つのテキストファイルのパス名を指定できるようにしてください。
        */
        static void Main(string[] args) {
            if (args.Length < 2) {
                Console.WriteLine("元のファイルと内容を追加するファイルのパスを指定してください");
            }
            var wMainFilePath = args[0];
            var wAddFilePath = args[1];

            var wMainContent = File.ReadAllText(wMainFilePath);
            var wAddContent = File.ReadAllText(wAddFilePath);

            File.WriteAllText(wMainFilePath, wAddContent + Environment.NewLine + wMainContent);
            File.AppendAllText(wMainFilePath, Environment.NewLine + wAddContent);

            Console.WriteLine("ファイルが更新されました");
        }
    }
}
