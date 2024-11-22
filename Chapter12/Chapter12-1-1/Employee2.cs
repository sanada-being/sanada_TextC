using System;
using System.Runtime.Serialization;

namespace Chapter12_1_1 {
    /// <summary>
    /// 問題4用の従業員クラス
    /// </summary>
    [DataContract]
    public class Employee2 {
        public int Id { get; set; }
        [DataMember(Order = 1)]
        public string Name { get; set; }
        [DataMember(Order = 2)]
        public DateTime HireDate { get; set; }

        public Employee2() { }

        public Employee2(int vId, string vName, DateTime vHireDate) {
            this.Id = vId;
            this.Name = vName;
            this.HireDate = vHireDate;
        }
    }
}
