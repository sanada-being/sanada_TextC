using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Chapter11_1_2 {
    class Program {
        /*
        XMLファイル"..\..\Sample11-2.xml"を以下の形式に変換し、別のファイルに保存してください。

          <?xml version="1.0" encoding="utf-8"?>
          <difficultkanji>
            <word kanji="鬼灯" yomi="ほおずき" />
            <word kanji="暖簾" yomi="のれん" />
            <word kanji="杜撰" yomi="ずさん" />
            <word kanji="坩堝" yomi="るつぼ" />
          </difficultkanji>
        */
        static void Main(string[] args) {
            Console.WriteLine("ファイルパスを入力してください");
            var wFilePath = Console.ReadLine();

            if (!File.Exists(wFilePath)) {
                Console.WriteLine("このファイルは存在しません");
                return;
            }

            var wDoc = XDocument.Load(wFilePath);
            var wWords = wDoc.Descendants("word");

            var wNewDoc = new XElement("difficultkanji", wWords.Select
                (x => new XElement("word", x.Elements().Select(y => new XAttribute(y.Name.LocalName,y.Value)))));

            wNewDoc.Save(@"..\..\NewFile.xml");
            Console.WriteLine("新しいファイルが作成されました");
        }
    }
}
