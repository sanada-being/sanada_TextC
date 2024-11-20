using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Chapter12_1_2 {
    class Program {
        /*
        1. XmlSerializrerクラスを使ってXMLファイル@"..\..\Sample.xml"を逆シリアル化し、Novelistオブジェクトを生成してください。
           Novelistクラスには必要であれば適切な属性を追加してください。
        
        2. 上記Noveristオブジェクトの内容を以下のようなJSONファイルにシリアル化するコードを書いてください。
        */
        static void Main(string[] args) {
            // 1.
            Console.WriteLine("ファイルパスを入力してください");
            var wFilePath = Console.ReadLine();

            if (!File.Exists(wFilePath)) {
                Console.WriteLine("指定したファイルが存在しません");
                return;
            }
            Novelist wNovelist = DeserializeXmlToNovelist(wFilePath);
            DisplayNovelistInformation(wNovelist);

            // 2.
            SerializeNovelistToJson(wNovelist);
        }

        /// <summary>
        /// 逆シリアル化メソッド
        /// </summary>
        /// <param name="vFilePath">ファイルパス</param>
        /// <returns>逆シリアル化されたNoveristオブジェクト</returns>
        static Novelist DeserializeXmlToNovelist(string vFilePath) {
            try {
                using (var wReader = XmlReader.Create(vFilePath)) {
                    var wSerializer = new XmlSerializer(typeof(Novelist));
                    var wNovelist = wSerializer.Deserialize(wReader) as Novelist;

                    if (wNovelist != null) {
                        Console.WriteLine("逆シリアル化が成功しました。");
                    }
                    return wNovelist;
                }
            } catch (Exception wEx) {
                Console.WriteLine($"エラーが発生しました: {wEx.Message}");
                return null;
            }
        }

        /// <summary>
        /// 情報表示メソッド
        /// </summary>
        /// <param name="vNovelist">Novelistオブジェクト</param>
        static void DisplayNovelistInformation(Novelist vNovelist) {
            if (vNovelist == null) {
                Console.WriteLine("Novelist オブジェクトが null のため情報を表示できません。処理を終了します");
                return;
            }
            Console.WriteLine($"Name: {vNovelist.Name}");
            Console.WriteLine($"Birth: {vNovelist.Birth:yyyy-MM-dd}");
            Console.WriteLine("Masterpieces:");
            if (vNovelist.Masterpieces == null || vNovelist.Masterpieces.Count == 0) {
                Console.WriteLine("表示する作品がありません");
            } else {
                foreach (var wTitle in vNovelist.Masterpieces) {
                    Console.WriteLine($"・{wTitle}");
                }
            }
        }

        /// <summary>
        /// JSONファイルシリアル化メソッド
        /// </summary>
        /// <param name="vNovelist">Novelistオブジェクト</param>
        static void SerializeNovelistToJson(Novelist vNovelist) {
            if (vNovelist == null) {
                Console.WriteLine("JSON ファイルへのシリアル化に失敗しました。Novelist オブジェクトが null のため、処理を続行できません");
                return;
            }
            try {
                using (var wStream = new FileStream("Novelist.json", FileMode.Create, FileAccess.Write)) {
                    var wSerializer = new DataContractJsonSerializer(typeof(Novelist));
                    wSerializer.WriteObject(wStream, vNovelist);
                    Console.WriteLine("NovelistオブジェクトをJSONファイルにシリアル化しました。");
                }
            } catch (Exception wEx) {
                Console.WriteLine($"JSONファイルへのシリアル化中にエラーが発生しました: {wEx.Message}");
            }
        }
    }
}





