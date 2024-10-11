using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///3.で名前空間を変更
namespace Chapter1_1_1change {
    internal class Product {
        //「1-1クラス」で定義したProductクラス
        public int Code { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }

        //コンストラクタ
        public Product(int vCode, string vName, int vPrice) {
            this.Code = vCode;
            this.Name = vName;
            this.Price = vPrice;
        }

        //消費税額を求める
        public int GetTax() {
            return (int)(Price * 0.08);
        }

        //税込金額を表示する
        public int GetPriceIncludingTax() {
            return Price + GetTax();
        }
    }
}
