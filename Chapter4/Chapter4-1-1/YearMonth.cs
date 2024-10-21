using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4_1_1 {
    /// <summary>
    /// YearMonthクラス
    /// </summary>
    internal class YearMonth {
        //1. 年(Year)と月(Month)の2つのプロパティを持つクラスYearMonthを定義してください。
        //   2つのプロパティは読み取り専用にし、値はコンストラクタで指定出来るようにしてください。

        /// <summary>
        /// 年を取得
        /// </summary>

        public int Year { get; }
        /// <summary>
        /// 月を取得
        /// </summary>
        public int Month { get; }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vYear">年</param>
        /// <param name="vMonth">月</param>
        /// <exception cref="ArgumentOutOfRangeException">1～12以外だと例外になる</exception>
        public YearMonth(int vYear, int vMonth) {
            if (1 <= vMonth || vMonth <= 12) {
                throw new ArgumentOutOfRangeException(nameof(vMonth), "月は1から12の範囲で指定してください。");
            }

            this.Year = vYear;
            this.Month = vMonth;
        }

        // 2. YearMonthクラスに、Is21Centuryプロパティを追加してください。
        //    2001年から2100年までが21世紀です。
        //    この処理では加減乗除はしないでください。

        /// <summary>
        /// 21世紀かを判定
        /// </summary>
        public bool Is21Century {
            get {
                return 2001 <= Year && Year <= 2100;
            }
        }

        // 3. YearMonthクラスに、1ヶ月を求めるAddOneMonthメソッドを追加
        /// <summary>
        /// 1月追加メソッド
        /// </summary>
        /// <returns>月に１を足して返す,　12月の場合は翌年の1月を返す</returns>
        public YearMonth AddOneMonth() {
            if (Month == 12) {
                return new YearMonth(Year + 1, 1);
            } else {
                return new YearMonth(Year + 1, Month + 1);
            }
        }

        //4. ToStringメソッドをオーバーライドしてください。
        //   結果は"2017年8月"といった形式にしてください。
        /// <summary>
        /// yyyy年dd日で表示メソッド
        /// </summary>
        /// <returns>yyyy年dd表示で返す</returns>
        public override string ToString() {
            return $"{Year}年{Month}月";
        }
    }
}
