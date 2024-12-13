using System;
using System.Linq;

namespace Chapter17_1_2 {
    /// <summary>
    /// コンバーターを管理するクラス
    /// </summary>
    static class ConverterFactory {

        /// <summary>
        /// 定義されている全コンバーターのインスタンス
        /// </summary>
        private static ConverterBase[] FConverters = new ConverterBase[] {
            new MileCoverter(),
            new KiloMeterConverter(),
        };

        /// <summary>
        /// 指定した単位のコンバーターのインスタンスを取得するメソッド
        /// </summary>
        /// <param name="vName"></param>
        /// <returns></returns>
        public static ConverterBase GetInstance(string vName) {

            var wConverter = FConverters.FirstOrDefault(x => x.IsMyUnit(vName));
            if (wConverter == null) {
                Console.WriteLine("無効な単位です。使用できる単位は「キロメートル」または「マイル」です。");
            }
            return wConverter;
        }
    }
}
