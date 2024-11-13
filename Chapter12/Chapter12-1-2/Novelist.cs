using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Chapter12_1_2 {
    [DataContract]
    [XmlRoot("novelist")]
    public class Novelist {
        [DataMember(Order = 3)]
        [XmlElement("name")]
        public string Name { get; set; }
        [DataMember(Order = 1)]
        [XmlElement("birth")]
        public DateTime Birth { get; set; }
        [DataMember(Order = 2)]
        [XmlArray("masterpieces")]
        [XmlArrayItem("title")]
        public List<string> Masterpieces { get; set; }
    }
}
