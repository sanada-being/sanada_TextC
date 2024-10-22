﻿using System;

namespace Chapter4_1_2 {
    /// <summary>
    /// YearMonthクラス
    /// </summary>
    internal class YearMonth {
        //1. 年(Year)と月(Month)の2つのプロパティを持つクラスYearMonthを定義してください。
        //   2つのプロパティは読み取り専用にし、値はコンストラクタで指定出来るようにしてください。

        /// <summary>
        /// 年
        /// </summary>

        public int Year { get; }
        /// <summary>
        /// 月
        /// </summary>
        public int Month { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vYear">年</param>
        /// <param name="vMonth">月</param>
        /// <exception cref="ArgumentOutOfRangeException">1～12以外だと例外になる</exception>
        public YearMonth(int vYear, int vMonth) {
            if (vMonth < 1 || 12 < vMonth) {
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
        public bool Is21Century => 2001 <= this.Year && this.Year <= 2100;

        // 3. YearMonthクラスに、1ヶ月を求めるAddOneMonthメソッドを追加
        /// <summary>
        /// 1月追加メソッド
        /// </summary>
        /// <returns>月に１を足して返す,　12月の場合は翌年の1月を返す</returns>
        public YearMonth AddOneMonth() {
            if (this.Month == 12) {
                return new YearMonth(this.Year + 1, 1);
            } else {
                return new YearMonth(this.Year, this.Month + 1);
            }
        }

        //4. ToStringメソッドをオーバーライドしてください。
        //   結果は"2017年8月"といった形式にしてください。
        /// <summary>
        /// yyyy年M月で表示メソッド
        /// </summary>
        /// <returns>yyyy年M月表示で返す</returns>
        public override string ToString() {
            return $"{this.Year}年{this.Month}月";
        }
    }
}


