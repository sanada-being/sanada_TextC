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
            Console.WriteLine("ファイルパスを入力してください");
            var wFilePath = Console.ReadLine();

            if (!File.Exists(wFilePath)) {
                Console.WriteLine("指定したファイルが存在しません");
            }

            try {
                var wHtmlTexts = File.ReadAllLines(wFilePath);
                var wPattern = @"<\s*(/?)\s*([A-Z]+)(\s*[^>]*)>";

                File.WriteAllText(wFilePath, ReplaceText(wHtmlTexts, wPattern));
                Console.WriteLine("正常に更新されました");
            } catch (UnauthorizedAccessException) {
                Console.WriteLine("ファイルにアクセスする権限がありません");
            } catch (DirectoryNotFoundException) {
                Console.WriteLine("指定したディレクトリが存在しません");
            } catch (IOException) {
                Console.WriteLine("ファイルの読み込みまたは書き込み中にエラーが発生しました");
            } catch (Exception) {
                Console.WriteLine("予期しないエラーが発生しました");
            }
        }

        /// <summary>
        /// 置換処理メソッド
        /// </summary>
        /// <param name="vHtmlTexts">ファイルの内容</param>
        /// <param name="vPattern">正規表現</param>
        /// <returns>置換処理された文字列</returns>
        static string ReplaceText(string[] vHtmlTexts, string vPattern) {
            return String.Join(Environment.NewLine,
                vHtmlTexts.Select(x => Regex.Replace(x, vPattern, y => $"<{y.Groups[1].Value}{y.Groups[2].Value.ToLower()}{y.Groups[3].Value}>")));
        }
    }
}