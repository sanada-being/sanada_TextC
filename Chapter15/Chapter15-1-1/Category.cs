using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter15_1_1 {
    /// <summary>
    ///カテゴリクラス
    /// </summary>
    public class Category {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() {
            return $"Id:{this.Id},カテゴリ名:{this.Name}";
        }
    }
}
