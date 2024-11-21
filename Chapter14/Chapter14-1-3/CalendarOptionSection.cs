using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter14_1_3 {
    public class CalendarOptionSection : ConfigurationSection {
        [ConfigurationProperty("CalendarOption")]
        public CalendarOptionElement CalendarOption {
            get { return (CalendarOptionElement)this["CalendarOption"]; }
            set { this["CalendarOption"] = value; }
        }
    }
}
