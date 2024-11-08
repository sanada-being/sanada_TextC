using System;
using System.IO;

namespace Chapter9_1_5 {
    class Program {
        /*
        指定したディレクトリおよびそのサブディレクトリの配下にあるファイルからファイルサイズが1MB以上(1,048,576バイト)のファイル名の一覧を表示するプログラムを書いてください。
        */
        static void Main(string[] args) {
            var wMainDirectory = @"..\..\..\Chapter9-1-5";
            const int C_1MBSize = 1 * 1024 * 1024;
            var wFoundLargeFile = false;

            if (!Directory.Exists(wMainDirectory)) {
                Console.WriteLine("指定したディレクトリが存在しません");
                return;
            }

            var wFiles = Directory.EnumerateFiles(wMainDirectory, "*", SearchOption.AllDirectories);

            foreach (var wFile in wFiles) {
                var wFileInfo = new FileInfo(wFile);

                if (wFileInfo.Length >= C_1MBSize) {
                    Console.WriteLine($"ファイル名:{wFile}, サイズ:{wFileInfo.Length}バイト");
                    wFoundLargeFile = true;
                }
            }
            if (!wFoundLargeFile) {
                Console.WriteLine("1MB以上のファイルは見つかりませんでした。");
            }
        }
    }
}
