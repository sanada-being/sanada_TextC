namespace Chapter17_1_2 {
    /// <summary>
    /// キロメートルに変換するクラス
    /// </summary>
    public class KiloMeterConverter : ConverterBase {

        /// <summary>
        /// 指定した単位がキロメートルかを判定
        /// </summary>
        /// <param name="vName">指定した単位名</param>
        /// <returns>キロメートルの単位ならtrueを返す</returns>
        public override bool IsMyUnit(string vName) => vName.ToLower() == "kilometer" || vName == this.UnitName;

        /// <summary>
        /// メートルとの比率
        /// </summary>
        protected override double Ratio => 1000;

        /// <summary>
        /// 距離の単位（キロメートル)
        /// </summary>
        public override string UnitName => "キロメートル";
    }
}