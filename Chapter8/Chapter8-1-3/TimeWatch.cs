using System;

namespace Chapter8_1_3 {
    class TimeWatch {
        private DateTime FStartTime;
        private DateTime FStopTime;

        /// <summary>
        /// 開始時間
        /// </summary>
        public void Start() => FStartTime = DateTime.Now;

        /// <summary>
        /// 経過時間
        /// </summary>
        /// <returns>経過時間を返す</returns>
        public TimeSpan Stop() => DateTime.Now - this.FStartTime;
    }
}

