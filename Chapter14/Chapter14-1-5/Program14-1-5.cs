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
            var wOutputFile = args[1];

            if (!File.Exists(wZipFilePath)) {
                Console.WriteLine($"ZIPファイルが見つかりません: {wZipFilePath}");
                return;
            }
            if (!Directory.Exists(wOutputFile)) {
                Directory.CreateDirectory(wOutputFile);
                Console.WriteLine($"出力先フォルダを作成しました:{wOutputFile}");
            }

            try {
                using (var wZip = ZipFile.OpenRead(wZipFilePath)) {
                    foreach (var wEntry in wZip.Entries) {
                        if (Path.GetExtension(wEntry.FullName).Equals(".txt", StringComparison.OrdinalIgnoreCase)) {
                            var wDestinationPath = Path.Combine(wOutputFile, wEntry.FullName);

                            if (wDestinationPath != null) {
                                Directory.CreateDirectory(Path.GetDirectoryName(wDestinationPath));
                            }
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
