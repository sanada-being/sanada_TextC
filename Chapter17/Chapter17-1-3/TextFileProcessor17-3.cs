using System.IO;

namespace Chapter17_1_3 {
    /// <summary>
    /// テキストファイル処理クラス
    /// </summary>
    class TextFileProcessor17_3 {

        /// <summary>
        /// ファイル処理を行うオブジェクト
        /// </summary>
        private ITextFileProcessor FFileProcessor;

        /// <summary>
        /// ファイル処理を実行するためのインスタンスを初期化するコンストラクタ
        /// </summary>
        /// <param name="vProcessor">テキストファイル処理クラスのインスタンス</param>
        public TextFileProcessor17_3(ITextFileProcessor vProcessor) {
            this.FFileProcessor = vProcessor;
        }

        /// <summary>
        /// ファイルを読み込み、行ごとに処理を実行するメソッド
        /// </summary>
        /// <param name="vFilePath">処理を行うファイルのパス</param>
        public void Run(string vFilePath) {
            FFileProcessor.Initialize(vFilePath);
            using (var wStreamReader = new StreamReader(vFilePath)) {
                while (!wStreamReader.EndOfStream) {
                    var wCurrentLine = wStreamReader.ReadLine();
                    FFileProcessor.Execute(wCurrentLine);
                }
            }
            FFileProcessor.Terminate();
        }
    }
}
