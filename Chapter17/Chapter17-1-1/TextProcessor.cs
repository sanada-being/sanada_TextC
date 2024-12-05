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
        /// <param name="vFilename">処理をするファイル</param>
        public static void Run<T>(string vFilename) where T : TextProcessor, new() {
            var wSelf = new T();
            wSelf.Process(vFilename);
        }

        /// <summary>
        /// ファイルの各行を処理するメソッド
        /// </summary>
        /// <param name="vFilename">処理をするファイル</param>
        private void Process(string vFilename) {
            Initialize(vFilename);
            using (var wSr = new StreamReader(vFilename)) {
                while (!wSr.EndOfStream) {
                    string wLine = wSr.ReadLine();
                    Execute(wLine);
                }
            }
            Terminate();
        }

        /// <summary>
        /// 処理を初期化するメソッド。派生先で定義
        /// </summary>
        /// <param name="vFilename"></param>
        protected virtual void Initialize(string vFilename) { }

        /// <summary>
        /// 各行に実行する処理を定義するメソッド。派生先で定義
        /// </summary>
        /// <param name="vLine"></param>
        protected virtual void Execute(string vLine) { }

        /// <summary>
        /// 処理を終了するメソッド。派生先で定義
        /// </summary>
        protected virtual void Terminate() { }
    }
}
