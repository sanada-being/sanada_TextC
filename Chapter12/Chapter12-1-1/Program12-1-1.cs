using System;
using System.Xml;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Chapter12_1_1 {
    class Program {
        /*
        1. Employeeクラスが定義されています。このオブジェクトをXMLにシリアル化するコードと逆シリアル化するコードを、
           XmlSerializerクラスを使って書いてください。この時、XMLの要素は全て小文字にしてください。

        2. 複数のEmployeeオブジェクトが配列に格納されているとします。
        この配列をDataContractSerializerクラスを使ってXMLファイルにシリアル化してください。

        3. 2で作成したファイルを読み込み、逆シリアル化してください。

        4. 複数のEmployeeオブジェクトが配列に格納されているとします。
        この配列を DataContractJsonSerializerを使ってJSONファイルに出力してください。この時、シリアル化対象にIdは含めないでください。
        */
        static void Main(string[] args) {
            // 1.シリアル化
            Console.WriteLine("問題1");
            var wEmployee = new Employee {
                Id = 1, Name = "akbar", HireDate = new DateTime(2020, 4, 1)
            };


            var wXmlSerializer = new XmlSerializer(typeof(Employee));

            var wStringBuilder = new StringWriter();
            wXmlSerializer.Serialize(wStringBuilder, wEmployee);
            var wXmlData = wStringBuilder.ToString();
            Console.WriteLine(wXmlData);

            // 1.逆シリアル化
            using (var wReader = new StringReader(wXmlData)) {
                var wDeserializedEmployee = (Employee)wXmlSerializer.Deserialize(wReader);
                Console.WriteLine("\nDeserialized Employee:");
                Console.WriteLine($"Id: {wDeserializedEmployee.Id}");
                Console.WriteLine($"Name: {wDeserializedEmployee.Name}");
                Console.WriteLine($"HireDate: {wDeserializedEmployee.HireDate.ToString("yyyy-MM-dd")}");
            }

            // 2.
            Console.WriteLine("問題2");
            var wEmployees = new Employee[] {
                new Employee{Id = 2, Name ="sugisaka",HireDate = new DateTime(2019,4, 1) },
                new Employee{Id = 3, Name ="taiga",HireDate = new DateTime(2018,4,1) },
                new Employee{Id = 4, Name ="oohashi",HireDate = new DateTime(2021,4,1) }
            };
            var wSerializer = new DataContractSerializer(typeof(Employee[]));
            using (var wFileStream = new FileStream("Employees.xml", FileMode.Create)) {
                wSerializer.WriteObject(wFileStream, wEmployees);
            }
            Console.WriteLine("\nシリアル化されたwXml:");
            Console.WriteLine(File.ReadAllText("Employees.xml"));

            // 3.
        }
    }
}

