using System;
namespace Chapter1_1_3 {
    // 「1.6：継承」で示したPersonクラスを使い、以下のコードを書いてください。

    // 1.Personクラスを継承し、Studentクラスを定義してください。
    // Studentには、2つのプロパティ、Grade(学年)とClassNumber(組)を追加してください。
    // 2つのプロパティの型は共にintとします。

    // 2.Studentクラスのインスタンスを生成するコードを書いてください。
    // この時、すべてのプロパティに値を設定してください。

    // 3.  2.で生成したインスタンスの各プロパティの値をコンソールに出力するコードを書いてください。

    // 4.  2で生成したインスタンスをperson型、およびobject型の変数に代入できることを確認してください。
    internal class Program {
        static void Main(string[] args) {

            //  2.　コンストラクタを元にプロパティに値を入れたインスタンスを生成するコード
            Student wStudent1 = new Student("Akbar Shah Sanada", new DateTime(2001, 11, 13), 6, 1);

            int wAge = wStudent1.GetAge();

            // 3.で生成したインスタンスの各プロパティの値をコンソールに出力するコード
            Console.WriteLine($"{wStudent1.Name}は{wStudent1.Grade}年{wStudent1.ClassNumber}組に所属しており、生年月日は{wStudent1.GetBirthdayFormat()}です。{wAge}歳です");

            // 4.Person型、object型の変数にそれぞれ代入
            Person wPerson = wStudent1;
            object wObject = wStudent1;
            Console.WriteLine(wPerson.Name);
            Console.WriteLine(wPerson.GetBirthdayFormat());
        }
    }
}

