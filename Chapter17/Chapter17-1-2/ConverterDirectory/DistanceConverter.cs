namespace Chapter17_1_2 {

    /// <summary>
    /// 距離の単位を変換するクラス
    /// </summary>
    public class DistanceConverter {

        /// <summary>
        /// 変換元の単位コンバーター
        /// </summary>
        public ConverterBase From { get; private set; }

        /// <summary>
        /// 変換先の単位コンバーター
        /// </summary>
        public ConverterBase To { get; private set; }

        /// <summary>
        /// 単位を変換するコンストラクタ
        /// </summary>
        /// <param name="vFrom">変換元の単位</param>
        /// <param name="vTo">変換先の単位</param>
        public DistanceConverter(ConverterBase vFrom, ConverterBase vTo) {
            this.From = vFrom;
            this.To = vTo;
        }

        /// <summary>
        /// 指定した距離の値を変換するメソッド
        /// </summary>
        /// <param name="vValue">指定した距離の値</param>
        /// <returns>変換すされた値</returns>
        public double Convert(double vValue) {
            var wMeter = this.From.ToMeter(vValue);
            return this.To.FromMeter(wMeter);
        }
    }
}
