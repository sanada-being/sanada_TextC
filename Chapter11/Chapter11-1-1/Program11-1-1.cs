using System;
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
            var wMostManyPlayer = wSportsElements.OrderByDescending(x => {
                int wTeamMembers;
                return int.TryParse(x.Element("teammembers")?.Value, out wTeamMembers) ? wTeamMembers : 0;
            }).First();

            var wSportsName = wMostManyPlayer.Element("name")?.Value;
            Console.WriteLine($"最もチームメンバーが多いスポーツ:{wSportsName}");

            var wTeamMembersValue = wMostManyPlayer.Element("teammembers")?.Value;
            int wParsedMembers;
            if (int.TryParse(wTeamMembersValue, out wParsedMembers)) {
                Console.WriteLine($"チームメンバー数: {wParsedMembers}");
            } else {
                Console.WriteLine("チームメンバー数が無効な値です");
            }

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
