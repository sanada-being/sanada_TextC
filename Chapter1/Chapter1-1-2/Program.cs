using System;
namespace Chapter1_1_2 {
    // 「1.2：構造体」で定義したMyClassとMyStructの２つを使い、以下のコードを書いてください

    // 1.MyClassとMyStructの2つの型を引数にとるメソッドPrintObjectsを定義してください。
    // PrintObjectsメソッドでは、2つのオブジェクト内容（プロパティの値)をコンソールに表示するようにしてください。
    // なお、PrintObjectsメソッドは、Programクラスのメソッドとして定義してください。

    // 2.MainメソッドでPrintObjectsメソッドを呼び出すコードを書いてください。
    // MyClass,MyStructオブジェクトの値は自由に決めて構いません。

    // 3.MyClass,MyStructそれぞれのプロパティの値を2倍に変更する PrintDoubleObjectsメソッドを定義してください。
    // Mainメソッドでは PrintDoubleObjects呼び出しの後に、MyClass,MyStructオブジェクトのプロパティの値をコンソールに表示するコードを加えてください。

    // 4.上のコードを実行し、結果を確認してください。そして、なぜそのような結果になったのかを説明してください。
    internal class Program {
        static void Main(string[] args) {

            MyClass wMyClass1 = new MyClass { X = 10, Y = 20 };
            MyStruct wMyStruct1 = new MyStruct { X = 100, Y = 200 };

            // 2.MainメソッドでPrintObjectsメソッドを呼び出すコード
            PrintObjects(wMyClass1, wMyStruct1);

            // 3.メインメソッドでPrintDoubleObjectsを呼び出すコード
            PrintDoubleObjects(wMyClass1, wMyStruct1);

            //MyClass,MyStructオブジェクトのプロパティの値を表示
            Console.WriteLine($"X: {wMyClass1.X}, Y: {wMyClass1.Y}");
            Console.WriteLine($"X: {wMyStruct1.X}, Y:{wMyStruct1.Y}");
        }

        // 1.MyClassとMyStructの2つの型を引数にとり、
        // オブジェクトの内容をコンソールに表示するメソッドPrintObjectsを定義

        /// <summary>
        /// 引数に取るMyClassとMyStructの内容をコンソールに表示する。
        /// </summary>
        /// <param name="vMyClass">表示するMyClassのオブジェクト</param>
        /// <param name="vMyStruct">表示するMyStructのオブジェクト</param>
        static void PrintObjects(MyClass vMyClass, MyStruct vMyStruct) {
            // MyClass の内容を表示
            Console.WriteLine($"X: {vMyClass.X}, Y: {vMyClass.Y}");

            // MyStruct の内容を表示
            Console.WriteLine($"X: {vMyStruct.X}, Y: {vMyStruct.Y}");
        }

        //3. それぞれ2倍して表示するメソッド PrintDoubleObjectを定義

        /// <summary>
        ///引数に取るMyClassとMyStructの値を2倍にし、コンソールに表示する。
        /// </summary>
        /// <param name="vMyClass">2倍にするMyClassのオブジェクト</param>
        /// <param name="vMyStruct">2倍にするMyStructのオブジェクト</param>
        static void PrintDoubleObjects(MyClass vMyClass, MyStruct vMyStruct) {

            // 2倍したMyClassの内容を表示
            vMyClass.X *= 2;
            vMyClass.Y *= 2;
            Console.WriteLine($"X: {vMyClass.X}, Y: {vMyClass.Y}");

            // 2倍したMyStructの内容を表示
            vMyStruct.X *= 2;
            vMyStruct.Y *= 2;
            Console.WriteLine($"X: {vMyStruct.X}, Y: {vMyStruct.Y}");
        }
        // 4.PrintDoubleObjectメソッドの実行後、wMyClass1とwMyStruct1のプロパティの値はそれぞれ、
        // wMyClass1{X=20,Y=40} wMyStruct1{X=100,Y=200}　となった。
        // wMyClass1のみ値が２倍になった理由はwMyClass1が参照型のオブジェクトであり、
        // メソッドの引数に指定すると、オブジェクトへの参照がコピーされ、メソッドの中で
        // 受け取ったオブジェクトの値を変更するコードを書くと参照元を経由するため、
        // 呼び出し元のオブジェクトも変更される。
        // 一方、wMyStruct1は値型のオブジェクトであり、値のみがメソッドに渡る。
        // そのためメソッドの中でオブジェクトを変更しても、呼び出し元の参照元は変更されないため、
        // 呼び出し元の値も変更されない。
    }
}
