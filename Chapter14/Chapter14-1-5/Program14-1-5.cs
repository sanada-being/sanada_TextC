using System;
using System.IO;
using System.IO.Compression;

namespace Chapter14_1_5 {
    /*
    指定されたZIPファイルから、拡張子が.txtのファイルだけを抽出するコンソールアプリケーションを作成してください。
    ZIPファイルと出力先フォルダは以下のようにコマンドラインで指定します。
          ..\..\sample.zip ..\..\GettxtFileDirectory
    第一パラメータがZIPファイルのパス、第二パラメータが出力先ファイルです。出力先フォルダが存在しない場合は新たに作成してください。
    */
    class Program {
        static void Main(string[] args) {
            if (args.Length != 2) {
                Console.WriteLine("エラー:ZIPファイルと保存先ファイルの2つを引数に指定してください");
                return;
            }

            var wZipFilePath = args[0];
            var wOutputDirPath = args[1];

            if (!File.Exists(wZipFilePath)) {
                Console.WriteLine($"ZIPファイルが見つかりません: {wZipFilePath}");
                return;
            }
           
            try {
                using (var wZip = ZipFile.OpenRead(wZipFilePath)) {
                    foreach (var wEntry in wZip.Entries) {
                        if (Path.GetExtension(wEntry.FullName).Equals(".txt", StringComparison.OrdinalIgnoreCase)) {
                            var wDestinationPath = Path.Combine(wOutputDirPath, wEntry.FullName);
                            Directory.CreateDirectory(Path.GetDirectoryName(wDestinationPath));

                            wEntry.ExtractToFile(wDestinationPath, overwrite: true);
                        }
                    }
                }
                Console.WriteLine(".txtファイルの抽出を完了しました");
            } catch (Exception wEx) {
                Console.WriteLine($"エラーが発生しました:{wEx.Message}");
            }
        }
    }
}
