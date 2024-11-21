using System;
using Confiig
namespace ClassLibrary14_1_3 {

    public class CalendarOptionSection : ConfigurationSection {
        [ConfigurationProperty("CalendarOption")]
        public CalendarOptionElement CalendarOption {
            get { return (CalendarOptionElement)this["CalendarOption"]; }
            set { this["CalendarOption"] = value; }
        }
    }
}



    }
}
