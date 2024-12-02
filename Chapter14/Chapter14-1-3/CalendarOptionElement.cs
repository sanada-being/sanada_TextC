using System.Configuration;

namespace Chapter14_1_3 {
    /// <summary>
    /// 構成セクションクラス（カレンダーの要素)
    /// </summary>
    public class CalendarOptionElement : ConfigurationElement {
        [ConfigurationProperty("StringFormat", DefaultValue = "yyyy年MM月dd日(ddd)", IsRequired = true)]
        public string StringFormat {
            get { return (string)this["StringFormat"]; }
        }

        [ConfigurationProperty("Minimum", DefaultValue = "1900/1/1", IsRequired = true)]
        public string Minimum {
            get { return (string)this["Minimum"]; }
        }

        [ConfigurationProperty("Maximum", DefaultValue = "2100/12/31", IsRequired = true)]
        public string Maximum {
            get { return (string)this["Maximum"]; }
        }

        [ConfigurationProperty("MondayIsFirstDay", DefaultValue = true, IsRequired = true)]
        public bool MondayIsFirstDay {
            get { return (bool)this["MondayIsFirstDay"]; }
        }
    }
}

