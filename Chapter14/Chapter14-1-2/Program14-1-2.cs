using System;
using System.Diagnostics;
using System.Reflection;

namespace Chapter14_1_2 {
    // 自分自身のファイルバージョンとアセンブリバージョンを表示するコンソールアプリケーションを作成してください。
    class Program {
        static void Main(string[] args) {
            var wAssemblyInfo = Assembly.GetExecutingAssembly();
            var wAssemblyVersion = wAssemblyInfo.GetName().Version;
            Console.WriteLine($"{wAssemblyVersion.Major}.{wAssemblyVersion.Minor}.{wAssemblyVersion.Build}.{wAssemblyVersion.Revision}");

            var wLocation = Assembly.GetExecutingAssembly().Location;
            var wFileVersion = FileVersionInfo.GetVersionInfo(wLocation);
            Console.WriteLine($"{wFileVersion.FileMajorPart}.{wFileVersion.FileMinorPart}.{wFileVersion.FileBuildPart}.{wFileVersion.FilePrivatePart}");
        }
    }
}
