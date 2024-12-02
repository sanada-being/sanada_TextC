using System.Configuration;

namespace Chapter14_1_3 {
    /// <summary>
    /// セクションクラス(カレンダーの属性)
    /// </summary>
    public class CalendarOptionSection : ConfigurationSection {
        [ConfigurationProperty("CalendarOption")]
        public CalendarOptionElement CalendarOption {
            get { return (CalendarOptionElement)this["CalendarOption"]; }
        }
    }
}
