using System;
using System.Collections.Generic;
using System.IO;

namespace Chapter16_1_2 {
    /*
    指定したディレクトリ(..\..\..\..\..\C#テキスト学習2冊目)にあるC#のソースファイルの中をすべて検索し、キーワードasyncとawaitの両方を利用しているファイルを列挙してください。
    列挙する際はファイルのフルパスを表示してください。表示する順番は問いません。
    並列処理をした場合としない場合の2つのバージョンを作成し、どれくらい速度に差があるかも調べてください。
    */
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("検索するディレクトリを指定してください");
            var wGetPath = Console.ReadLine();
            var wSearchdirectory = new DirectoryInfo(wGetPath);

            if (!wSearchdirectory.Exists) {
                Console.WriteLine("指定したディレクトリは存在しません");
                return;
            }
            IEnumerable<FileInfo> wFiles = wSearchdirectory.EnumerateFiles("*.cs", SearchOption.AllDirectories);

            new SerialProcessing().SerialProcessFiles(wFiles);
            new ParallelProcessing().ParallelProcessFiles(wFiles);
        }
    }
}
