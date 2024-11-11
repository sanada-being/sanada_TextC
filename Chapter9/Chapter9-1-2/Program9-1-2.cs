using System.IO;
using System.Linq;

namespace Chapter9_1_2 {
    class Program {
        /*
        テキストファイルを読み込み、行の先頭に行番号を振り、その結果を別のテキストファイルに出力するプログラムを書いてください。
        書式と出力先のファイルは自由に決めてください。出力するファイル名と同名のファイル名があった場合は、上書きしてください。
        */
        static void Main(string[] args) {
            var wFilepath = @"..\..\9_CountClass.txt";
            var wNewFilePath = @"..\..\AddNnmber.txt";

            var wLines = File.ReadAllLines(wFilepath);
            var wMaxDigits = wLines.Length.ToString().Length; //最大桁数

            var wNumberedLines = wLines.Select((x, y) => $"{(y + 1).ToString().PadLeft(wMaxDigits, ' ')}:{x}").ToArray();

            File.WriteAllLines(wNewFilePath, wNumberedLines);
        }
    }
}
