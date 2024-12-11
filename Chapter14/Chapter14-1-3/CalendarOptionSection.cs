using System.Configuration;

namespace Chapter14_1_3 {
    /// <summary>
    /// セクションクラス(カレンダーの属性)
    /// </summary>
    public class CalendarOptionSection : ConfigurationSection {

        /// <summary>
        /// カレンダーオプション属性の設定を取得
        /// </summary>
        [ConfigurationProperty("CalendarOption")]
        public CalendarOptionElement CalendarOption {
            get { return (CalendarOptionElement)this["CalendarOption"]; }
        }
    }
}
