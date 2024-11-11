using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Chapter11_1_1 {
    class Program {
        /*
       1. XMLファイルを読み込み、競技名とチームメンバー数の一覧を表示してください。

       2. 最初にプレイされた年の若い順に漢字の競技名を出力してください。

       3. メンバーがもっとも多い競技名を表示してください

       4. サッカーの情報を追加して、新たなXMLファイルに出力してください。
          ファイル名は特に指定しません。サッカーの情報は調べてください。
       */
        static void Main(string[] args) {
            var wFilePath = @"..\..\Sample.xml";

            if (!File.Exists(wFilePath)) {
                Console.WriteLine("このファイルは存在しません");
                return;
            }

            // 1.
            Console.WriteLine("問題1");
            var wHmlFile = XDocument.Load(wFilePath);
            var wSportsElements = wHmlFile.Root.Elements();
            foreach (var wXElement in wSportsElements) {
                var wName = wXElement.Element("name");
                var wMenberNum = wXElement.Element("teammembers");
                Console.WriteLine($"競技名:{wName.Value}, チームメンバー:{wMenberNum.Value}人");
            }

            // 2. 
            Console.WriteLine("問題2");
            var wFirstPlaySports = wSportsElements.OrderByDescending(x => (int)(x.Element("firstplayed")));
            foreach (var wSortedSportElement in wFirstPlaySports) {
                var wName = wSortedSportElement.Element("name");
                var wKanaName = wName.Attribute("kanji");
                Console.WriteLine($"競技名:{wKanaName?.Value}");
            }

            // 3.
            Console.WriteLine("問題3");
            var wMostManyPlayer = wSportsElements.OrderByDescending(x => (int)x.Element("teammembers")).First();
            var wSportsName = wMostManyPlayer.Element("name")?.Value;
            Console.WriteLine($"最もチームメンバーが多いスポーツ:{wSportsName}");

            // 4.
            Console.WriteLine("問題4");
            var wNewSportsElement = new XElement("ballsport",
                new XElement("name", new XAttribute("kanji", "蹴球"), "サッカー"),
                new XElement("teammembers", 11),
                new XElement("firstplayed", 1863)
                );
            wHmlFile.Root.Add(wNewSportsElement);
            wHmlFile.Save(@"..\..\NewHmlFile");
            Console.WriteLine("新しい情報の追加が完了しました。");
        }
    }
}
