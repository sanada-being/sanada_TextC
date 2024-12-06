using System.Linq;

namespace Chapter17_1_2 {
    /// <summary>
    /// コンバーターを管理するクラス
    /// </summary>
    static class ConverterFactory {

        /// <summary>
        /// 定義されている全コンバーターのインスタンス
        /// </summary>
        private static ConverterBase[] _converters = new ConverterBase[] {
            new MileCoverter(),
            new KiloMeterConverter(),
        };

        /// <summary>
        /// 指定した単位のコンバーターのインスタンスを取得するメソッド
        /// </summary>
        /// <param name="vName"></param>
        /// <returns></returns>
        public static ConverterBase GetInstance(string vName) {
            return _converters.FirstOrDefault(x => x.IsMyUnit(vName));
        }
    }
}
