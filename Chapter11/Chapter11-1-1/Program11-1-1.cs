using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Chapter11_1_1 {
    class Program {
        /*
       1. XMLファイル@"..\..\Sample.xml";を読み込み、競技名とチームメンバー数の一覧を表示してください。

       2. 最初にプレイされた年の若い順に漢字の競技名を出力してください。

       3. メンバーがもっとも多い競技名を表示してください

       4. サッカーの情報を追加して、新たなXMLファイルに出力してください。
          ファイル名は特に指定しません。サッカーの情報は調べてください。
       */
        static void Main(string[] args) {
            Console.WriteLine("ファイルパスを入力してください");
            var wFilePath = Console.ReadLine();

            if (!File.Exists(wFilePath)) {
                Console.WriteLine("このファイルは存在しません");
                return;
            }

            // 1.
            Console.WriteLine("問題1");
            var wXmlFile = XDocument.Load(wFilePath);
            var wSportsElements = wXmlFile.Root.Elements();
            foreach (var wSport in wSportsElements) {
                var wName = wSport.Element("name");
                var wPlayerCount = wSport.Element("teammembers");
                Console.WriteLine($"競技名:{wName.Value}, チームメンバー:{wPlayerCount.Value}人");
            }

            // 2. 
            Console.WriteLine("問題2");
            foreach (var wSortedSportsElement in wSportsElements.OrderBy(x => (int)x.Element("firstplayed"))) {
                var wName = wSortedSportsElement.Element("name");
                Console.WriteLine($"競技名:{wName.Attribute("kanji")?.Value ?? "なし"}");
            }

            // 3.
            Console.WriteLine("問題3");
            var wErrorMessages = new List<string>();
            var wParsedSports = wSportsElements.Select(x => new {
                Element = x,
                TeamMembers = int.TryParse(x.Element("teammembers")?.Value, out int wParsedMembers) ? wParsedMembers : (int?)null
            }).ToList();

            foreach (var wSport in wParsedSports.Where(x => !x.TeamMembers.HasValue)) {
                wErrorMessages.Add($"スポーツ名: {wSport.Element.Element("name")?.Value ?? "不明"} のチームメンバー数が無効です。");
            }

            if (wErrorMessages.Any()) {
                Console.WriteLine("一部の情報に不備がありました:");
                foreach (var wMessage in wErrorMessages) {
                    Console.WriteLine(wMessage);
                }
            }

            var wMostManyPlayer = wParsedSports.OrderByDescending(x => x.TeamMembers ?? 0).First();

            Console.WriteLine($"最もチームメンバーが多いスポーツ: {wMostManyPlayer.Element.Element("name")?.Value ?? "不明"}");
            if (wMostManyPlayer.TeamMembers.HasValue) {
                Console.WriteLine($"チームメンバー数: {wMostManyPlayer.TeamMembers}");
            } else {
                Console.WriteLine("チームメンバー数が無効な値です");

                // 4.
                Console.WriteLine("問題4");
                var wNewSportsElement = new XElement("ballsport",
                    new XElement("name", new XAttribute("kanji", "蹴球"), "サッカー"),
                    new XElement("teammembers", 11),
                    new XElement("firstplayed", 1863)
                    );
                wXmlFile.Root.Add(wNewSportsElement);
                wXmlFile.Save(@"..\..\NewXMLFile");
                Console.WriteLine("新しい情報の追加が完了しました。");
            }
        }
    }
}
