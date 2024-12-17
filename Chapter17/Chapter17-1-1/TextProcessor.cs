using System.IO;

namespace Chapter17_1_1 {
    /// <summary>
    /// 継承元となる抽象クラス
    /// </summary>
    public abstract class TextProcessor {

        /// <summary>
        /// 型引数を受け取るジェネリックメソッド
        /// </summary>
        /// <typeparam name="T">処理を実行するクラス</typeparam>
        /// <param name="vFilePath">処理をするファイルパス</param>
        public static void Run<T>(string vFilePath) where T : TextProcessor, new() {
            var wSelf = new T();
            wSelf.Process(vFilePath);
        }

        /// <summary>
        /// ファイルの各行を処理するメソッド
        /// </summary>
        /// <param name="vFilePath">処理をするファイルパス</param>
        private void Process(string vFilePath) {
            using (var wStreamReader = new StreamReader(vFilePath)) {
                while (!wStreamReader.EndOfStream) {
                    string wLine = wStreamReader.ReadLine();
                    Execute(wLine);
                }
            }
        }

        /// <summary>
        /// 各行に実行する処理を定義するメソッド。派生先で定義
        /// </summary>
        /// <param name="vLine">ファイルの行</param>
        protected virtual void Execute(string vLine) { }
    }
}
