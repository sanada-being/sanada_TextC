using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chapter10_1_5 {
    class Program {
        /*
        HTMLタグを読み込み、<DIV>や<P>などのタグ名が大文字になっているものを<div>,<p>などの小文字のタグに変換してください。
        可能ならば、<DIV class="mybox"id="myId">のように属性が記述されている場合にも対応してください。属性の中には'<'、'>'は含まれないものとします。
        */
        static void Main(string[] args) {
            var wFilePath = @"..\..\Sample10-5.html";

            if (File.Exists(wFilePath)) {
                var wHtmlTexts = File.ReadAllLines(wFilePath);

                var wPattern = @"<\s*(/?)\s*([A-Z]+)(\s*[^>]*)>";
                var wResult = String.Join(Environment.NewLine, wHtmlTexts.Select(x => Regex.Replace(x, wPattern, y => $"<{y.Groups[1].Value}{y.Groups[2].Value.ToLower()}{y.Groups[3].Value}>")));

                File.WriteAllText(wFilePath, wResult);
                Console.WriteLine("正常に更新されました");
            } else {
                Console.WriteLine("指定したファイルが存在しません");
            }
        }
    }
}