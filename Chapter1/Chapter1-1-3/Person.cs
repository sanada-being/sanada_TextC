using System;
namespace Chapter1_1_3 {
    /// <summary>
    /// 人間クラス
    /// </summary>
    internal class Person {

        /// <summary>
        /// 名前を取得、設定する。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 誕生日を取得、設定する。
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 年齢を取得する。
        /// </summary>
        /// <returns>年齢を整数値で返す。</returns>
        public int GetAge() {
            DateTime wToday = DateTime.Today;
            int wAge = wToday.Year - this.Birthday.Year;
            if (wToday < this.Birthday.AddYears(wAge)) wAge--;
            return wAge;
        }
        /// <summary>
        /// 誕生日をyyyy/MM/ddで表示する。
        /// </summary>
        /// <returns>誕生日をyyyy/MM/dd表示にして返す。</returns>
        public string GetBirthdayFormat() {
            return this.Birthday.ToString("yyyy/MM/dd");
        }
    }
}
