using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Chapter11_1_2 {
    class Program {
        /*
        XMLファイル"Sample11-2.xml"を以下の形式に変換し、別のファイルに保存してください。

          <?xml version="1.0" encoding="utf-8"?>
          <difficultkanji>
            <word kanji="鬼灯" yomi="ほおずき" />
            <word kanji="暖簾" yomi="のれん" />
            <word kanji="杜撰" yomi="ずさん" />
            <word kanji="坩堝" yomi="るつぼ" />
          </difficultkanji>
        */
        static void Main(string[] args) {
            var wFilePath = @"..\..\Sample11-2.xml";
            if (!File.Exists(wFilePath)) {
                Console.WriteLine("このファイルは存在しません");
            }

            var wDoc = XDocument.Load(wFilePath);
            var wWordDictionary = wDoc.Descendants("word").ToDictionary(x => x.Element("kanji")?.Value, x => x.Element("yomi")?.Value);
            var wNewDoc = new XElement("difficultkanji", wWordDictionary.Select(x => new XElement("word", new XAttribute("kanji", x.Key), new XAttribute("yomi", x.Value))));

            wNewDoc.Save(@"..\..\NewFile");
            Console.WriteLine("新しいファイルが作成されました");
        }
    }
}
