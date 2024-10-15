using System;
namespace Chapter1_1_3 {
    /// <summary>
    /// 生徒クラス
    /// </summary>
    internal class Student : Person {

        // 1.Grade(学年)とClassNumber(組)プロパティを追加したStudentクラスを作成

        /// <summary>
        /// 学年の取得、設定
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// クラス番号の取得、設定
        /// </summary>
        public int ClassNumber { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vName">名前</param>
        /// <param name="vBirthday">誕生日</param>
        /// <param name="vGrade">学年</param>
        /// <param name="vClassNumber">クラス番号</param>
        public Student(string vName, DateTime vBirthday, int vGrade, int vClassNumber) {
            Name = vName;
            Birthday = vBirthday;
            Grade = vGrade;
            ClassNumber = vClassNumber;
        }
    }
}
