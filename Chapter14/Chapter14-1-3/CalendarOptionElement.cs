using System.Configuration;

namespace Chapter14_1_3 {
    /// <summary>
    /// 構成セクションクラス（カレンダーの要素)
    /// </summary>
    public class CalendarOptionElement : ConfigurationElement {

        /// <summary>
        /// カレンダーの日付フォーマットを取得
        /// </summary>
        [ConfigurationProperty("StringFormat", DefaultValue = "yyyy年MM月dd日(ddd)", IsRequired = true)]
        public string StringFormat {
            get { return (string)this["StringFormat"]; }
        }

        /// <summary>
        /// 日付の最小値を設定
        /// </summary>
        [ConfigurationProperty("Minimum", DefaultValue = "1900/1/1", IsRequired = true)]
        public string Minimum {
            get { return (string)this["Minimum"]; }
        }

        /// <summary>
        /// 日付の最大値を設定
        /// </summary>
        [ConfigurationProperty("Maximum", DefaultValue = "2100/12/31", IsRequired = true)]
        public string Maximum {
            get { return (string)this["Maximum"]; }
        }

        /// <summary>
        /// 月曜日を週の初めの日として扱うかどうかを設定
        /// デフォルトは「true」
        /// </summary>
        [ConfigurationProperty("MondayIsFirstDay", DefaultValue = true, IsRequired = true)]
        public bool MondayIsFirstDay {
            get { return (bool)this["MondayIsFirstDay"]; }
        }
    }
}

