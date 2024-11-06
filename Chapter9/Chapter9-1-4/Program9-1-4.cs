﻿using System;
using System.IO;

namespace Chapter9_1_4 {
    class Program {
        /*
        指定したディレクトリ直下にあるファイルを別のディレクトリにコピーするプログラムを作成してください。
        その際、コピーするファイル名は、拡張子を含まないファイル名の後ろに、_bakを付加してください。
        つまり、元のファイル名がGreeting.txtならば、コピー先のファイル名はGreeting_bak.txtという名前になります。
        コピー先に同名ファイル名がある場合は置き換えてください。
        */
        static void Main(string[] args) {
            var wMainDirectory = @"C:\Users\sanada\Desktop\ripository\C#テキスト学習2冊目\Chapter9\Chapter9-1-4\MainDirectory";
            var wNewDirectory = @"C:\Users\sanada\Desktop\ripository\C#テキスト学習2冊目\Chapter9\Chapter9-1-4\NewDirectory";

            if (Directory.Exists(wMainDirectory)) {
                if (!Directory.Exists(wNewDirectory)) {
                    Console.WriteLine("コピー先のディレクトリが存在しません");
                    return;
                }
                var wFiles = Directory.GetFiles(wMainDirectory);
                foreach (var wFile in wFiles) {

                    var wFileNmaeWithOutExtension = Path.GetFileNameWithoutExtension(wFile);
                    var wFileExtension = Path.GetExtension(wFile);

                    var wNewFilePath = Path.Combine(wNewDirectory, wFileNmaeWithOutExtension + "_bak" + wFileExtension);

                    File.Copy(wFile, wNewFilePath, overwrite: true);
                    Console.WriteLine($"ファイル{Path.GetFileName(wFile)}を{wNewFilePath}にコピーしました。");
                }
            } else {
                Console.WriteLine("指定したディレクトリが存在しません");
            }
        }
    }
}
