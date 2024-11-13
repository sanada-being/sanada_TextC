using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Chapter12_1_2 {
    class Program {
        /*
        1. XmlSerializrerクラスを使ってXMLファイル@"\\.\\.Sample.xml"を逆シリアル化し、Nove listオブジェクトを生成してください。
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

            Novelist wNovelist = null;

            try {
                using (var wReader = XmlReader.Create(wFilePath)) {
                    var wSerializer = new XmlSerializer(typeof(Novelist));
                    wNovelist = wSerializer.Deserialize(wReader) as Novelist;
                    Console.WriteLine(wNovelist);

                    if (wNovelist != null) {
                        Console.WriteLine($"Name: {wNovelist.Name}");
                        Console.WriteLine($"Birth: {wNovelist.Birth:yyyy-MM-dd}");
                        Console.WriteLine("Masterpieces:");
                        foreach (var wTitle in wNovelist.Masterpieces) {
                            Console.WriteLine($"・{wTitle}");
                        }
                    } else {
                        Console.WriteLine("エラー:逆シリアル化に失敗しました");
                    }
                }
            } catch (Exception wEx) {
                Console.WriteLine($"エラーが発生しました: {wEx.Message}");
                return;
            }

            // 2.
            try {
                using (var wStream = new FileStream("Novelist.json", FileMode.Create, FileAccess.Write)) {
                    var wSerializer = new DataContractJsonSerializer(typeof(Novelist));
                    wSerializer.WriteObject(wStream, wNovelist);
                    Console.WriteLine("NovelistオブジェクトをJSONファイルにシリアル化しました。");
                }
            } catch (Exception wEx) {
                Console.WriteLine($"JSONファイルへのシリアル化中にエラーが発生しました: {wEx.Message}");
            }
        }
    }
}


