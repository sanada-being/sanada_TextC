using System;
using System.Diagnostics;
using System.Reflection;

namespace Chapter14_1_2 {
    // 自分自身のファイルバージョンとアセンブリバージョンを表示するコンソールアプリケーションを作成してください。
    class Program {
        static void Main(string[] args) {
            var wAssemblyInfo = Assembly.GetExecutingAssembly();
            Version wAssemblyVersion = wAssemblyInfo.GetName().Version;
            Console.WriteLine($"{wAssemblyVersion}");

            var wFileVersion = FileVersionInfo.GetVersionInfo(wAssemblyInfo.Location);
            Console.WriteLine($"{wFileVersion.FileMajorPart}.{wFileVersion.FileMinorPart}.{wFileVersion.FileBuildPart}.{wFileVersion.FilePrivatePart}");
        }
    }
}
