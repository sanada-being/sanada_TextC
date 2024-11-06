using System.IO;

namespace Chapter9_1_2 {
    class Program {
        /*
        テキストファイルを読み込み、行の先頭に行番号を振り、その結果を別のテキストファイルに出力するプログラムを書いてください。
        書式と出力先のファイルは自由に決めてください。出力するファイル名と同名のファイル名があった場合は、上書きしてください。
        */
        static void Main(string[] args) {
            var wFilepath = @"C:\Users\sanada\Desktop\ripository\C#テキスト学習2冊目\Chapter9\Program9-1-2\9_CountClass.txt";
            var wNewFilePath = @"C:\Users\sanada\Desktop\ripository\C#テキスト学習2冊目\Chapter9\Program9-1-2\AddNumber.txt";

            File.Copy(wFilepath, wNewFilePath, overwrite: true);
            var wLines = File.ReadAllLines(wNewFilePath);
            using (var wWriter = new StreamWriter(wNewFilePath)) {
                for (int i = 0; i < wLines.Length; i++) {
                    wWriter.WriteLine($"{i + 1}:{wLines[i]}");
                }
            }
        }
    }
}

