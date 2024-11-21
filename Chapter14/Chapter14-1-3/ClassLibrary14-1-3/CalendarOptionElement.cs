using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ClassLibrary14_1_3 {
    internal class CalendarOptionElement ConfigurationElement {
         [ConfigurationProperty("StringFormat", DefaultValue = "yyyy年MM月dd日(ddd)", IsRequired = true)]
    public string StringFormat {
        get { return (string)this["StringFormat"]; }
        set { this["StringFormat"] = value; }
    }

    [ConfigurationProperty("Minimum", DefaultValue = "1900/1/1", IsRequired = true)]
    public string Minimum {
        get { return (string)this["Minimum"]; }
        set { this["Minimum"] = value; }
    }

    [ConfigurationProperty("Maximum", DefaultValue = "2100/12/31", IsRequired = true)]
    public string Maximum {
        get { return (string)this["Maximum"]; }
        set { this["Maximum"] = value; }
    }

    [ConfigurationProperty("MondayIsFirstDay", DefaultValue = true, IsRequired = true)]
    public bool MondayIsFirstDay {
        get { return (bool)this["MondayIsFirstDay"]; }
        set { this["MondayIsFirstDay"] = value; }
    }
}


    
