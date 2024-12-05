namespace Chapter17_1_1 {

    //「17.2」で示したTextProcessorクラスを使い、テキストファイルの中の全角数字を半角数字に置き変えて、その結果をコンソールに出力するプログラムを作ってください。
    class Program {
        static void Main(string[] args) {
            TextProcessor.Run<ConvertingFromFullwidthToHalfwidth>(args[0]);
        }
    }
}