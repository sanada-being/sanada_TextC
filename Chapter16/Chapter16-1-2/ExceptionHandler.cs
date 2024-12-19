using System;
using System.IO;

namespace Chapter16_1_2 {
/// <summary>
/// 例外処理クラス
/// </summary>
    public class ExceptionHandler {

        /// <summary>
        /// 例外処理メソッド
        /// </summary>
        /// <param name="vEx">発生した例外</param>
        public static void HandleException(Exception vEx) {
            if (vEx is FileNotFoundException) {
                Console.WriteLine("ファイルが見つかりません: " + vEx.Message);
            }
            else if (vEx is UnauthorizedAccessException) {
                Console.WriteLine("アクセス権限がありません: " + vEx.Message);
            }
            else if (vEx is IOException) {
                Console.WriteLine("I/Oエラーが発生しました: " + vEx.Message);
            }
            else {
                Console.WriteLine("予期しないエラーが発生しました: " + vEx.Message);
            }
        }
    }
}
