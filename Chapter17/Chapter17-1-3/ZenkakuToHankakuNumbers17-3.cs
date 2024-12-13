using System;
using System.Linq;

namespace Chapter17_1_3 {
    /// <summary>
    /// 全角数字を半角数字に変換するクラス
    /// </summary>
    class ZenkakuToHankakuNumbers17_3 : ITextFileProcessor {

        /// <summary>
        /// 初期化処理を実行するメソッド
        /// </summary>
        /// <param name="vFilePath">処理するファイルのパス</param>
        public void Initialize(string vFilePath) {
            //今回は初期化処理はなし 必要な場合はここに追加
        }

        /// <summary>
        /// ファイルの各行の全角の数字を半角数字に変換するメソッド
        /// </summary>
        /// <param name="vTextLine">処理を行う行</param>
        public void Execute(string vTextLine) {
            vTextLine = new string(vTextLine.Select(x => '０' <= x && x <= '９' ? (char)(x - '０' + '0') : x).ToArray());
            Console.WriteLine(vTextLine);
        }

        /// <summary>
        /// 処理完了を通知するメソッド
        /// </summary>
        public void Terminate() {
            Console.WriteLine("処理が完了しました");
        }
    }
}
