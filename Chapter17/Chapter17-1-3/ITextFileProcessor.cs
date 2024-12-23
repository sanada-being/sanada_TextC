namespace Chapter17_1_3 {
    /// <summary>
    /// テキストファイルを処理するインターフェース
    /// </summary>
    interface ITextFileProcessor {

        /// <summary>
        /// 処理を初期化するメソッド
        /// </summary>
        /// <param name="vFilePath"></param>
        void Initialize(string vFilePath);

        /// <summary>
        /// 各行に実行する処理を定義するメソッド
        /// </summary>
        /// <param name="vLine">ファイルの行</param>
        void Execute(string vLine);

        /// <summary>
        /// 処理を終了するメソッド
        /// </summary>
        void Terminate();
    }
}
