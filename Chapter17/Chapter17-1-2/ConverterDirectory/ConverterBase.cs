namespace Chapter17_1_2 {
    /// <summary>
    /// 距離換算の基底クラス
    /// </summary>
    public abstract class ConverterBase {

        /// <summary>
        /// 単位名判定メソッド
        /// </summary>
        /// <param name="vName">距離の単位</param>
        /// <returns>単位名が正しい場合trueを返す</returns>
        public abstract bool IsMyUnit(string vName);

        /// <summary>
        /// メートルとの比率
        /// </summary>
        protected abstract double Ratio { get; }

        /// <summary>
        /// 距離の単位名
        /// </summary>
        public abstract string UnitName { get; }

        /// <summary>
        /// メートルから変換するメソッド
        /// </summary>
        /// <param name="vMeter">処理を行うメートル単位の距離</param>
        /// <returns>メートルから基準の単位に変換した距離</returns>
        public double FromMeter(double vMeter) => vMeter / this.Ratio;

        /// <summary>
        /// メートルへの変換をするメソッド
        /// </summary>
        /// <param name="vFeet">基準の単位の距離</param>
        /// <returns>基準の単位からメートルに変換した距離</returns>
        public double ToMeter(double vFeet) => vFeet * this.Ratio;
    }
}
