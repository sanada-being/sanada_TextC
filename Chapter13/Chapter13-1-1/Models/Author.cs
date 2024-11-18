using System;
using System.Collections.Generic;

namespace Chapter13_1_1.Models {

    /// <summary>
    /// 著者クラス
    /// </summary>
    public class Author {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string Gender { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
