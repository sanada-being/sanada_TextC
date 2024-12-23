namespace Chapter17_1_2 {
    /// <summary>
    /// マイルに変換するクラス
    /// </summary>
    public class MileCoverter : ConverterBase {

        /// <summary>
        /// 指定した単位がマイルかを判定
        /// </summary>
        /// <param name="vName">指定した単位名</param>
        /// <returns>マイルの単位ならtrueを返す</returns>
        public override bool IsMyUnit(string vName) => vName.ToLower() == "mile" || vName == this.UnitName;

        /// <summary>
        /// メートルとの比率
        /// </summary>
        protected override double Ratio => 1609.344;

        /// <summary>
        /// 距離の単位（マイル)
        /// </summary>
        public override string UnitName => "マイル";
    }
}
