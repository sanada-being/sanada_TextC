using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Chapter12_1_1 {
    /// <summary>
    /// 従業員クラス
    /// </summary>
    [XmlRoot("employee")]
    [DataContract]
    public class Employee {

        [XmlElement("id")]
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [XmlElement("name")]
        [DataMember(Order = 2)]
        public string Name { get; set; }
        [XmlElement("hiredate")]
        [DataMember(Order = 3)]
        public DateTime HireDate { get; set; }
    }
}
