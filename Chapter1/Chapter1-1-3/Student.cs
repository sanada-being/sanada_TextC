using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1_1_3 {
    internal class Student : Person {

        //1.Grade(学年)とClassNumber(組)プロパティを追加したStudentクラスを作成
        public int Grade { get; set; }
        public int ClassNumber { get; set; }


    }
}
