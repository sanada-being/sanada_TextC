using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1_1_3 {
    //「1.6：継承」で示したPersonクラスを使い、以下のコードを書いてください。

    //1.Personクラスを継承し、Studentクラスを定義してください。
    //Studentには、2つのプロパティ、Grade(学年)とClassNumber(組)を追加してください。
    //2つのプロパティの型は共にintとします。

    //2.Studentクラスのインスタンスを生成するコードを書いてください。
    //この時、すべてのプロパティに値を設定してください。

    //3.  2.で生成したインスタンスの各プロパティの値をコンソールに出力するコードを書いてください。

    //4.  2で生成したインスタンスをperson型、およびobject型の変数に代入できることを確認してください。
    internal class Program {
        static void Main(string[] args) {


            //2.すべてのプロパティに値を入れたインスタンスを生成するコード
            Student wStudent1 = new Student {
                Name = "Akbar Shah Sanada",
                Birthday = new DateTime(2001, 11, 13),
                Grade = 6,
                ClassNumber = 1,
            };
            int wAge = wStudent1.GetAge();

            // 3.で生成したインスタンスの各プロパティの値をコンソールに出力するコード
            Console.WriteLine("{0}は{1}年{2}組に所属しており、生年月日は{3}です。{4}歳です",
                wStudent1.Name, wStudent1.Grade, wStudent1.ClassNumber, wStudent1.Birthday, wAge);


            //4.Person型、object型の変数にそれぞれ代入
            Person wPerson = wStudent1;
            object wObject = wStudent1;
            Console.WriteLine( wPerson.Name);
            Console.WriteLine(wPerson.Birthday);
        }
    }
}
