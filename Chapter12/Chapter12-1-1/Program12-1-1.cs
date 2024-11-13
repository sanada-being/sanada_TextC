using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

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
            Console.WriteLine("\n問題2");
            var wEmployees = new Employee[] {
                new Employee{Id = 2, Name ="sugisaka",HireDate = new DateTime(2019,4, 1) },
                new Employee{Id = 3, Name ="taiga",HireDate = new DateTime(2018,4,1) },
                new Employee{Id = 4, Name ="oohashi",HireDate = new DateTime(2021,4,1) }
            };
            var wSerializer = new DataContractSerializer(typeof(Employee[]));
            using (var wFileStream = new FileStream("Employees.xml", FileMode.Create)) {
                wSerializer.WriteObject(wFileStream, wEmployees);
            }
            Console.WriteLine("\nシリアル化された従業員データ:");
            Console.WriteLine(File.ReadAllText("Employees.xml"));

            // 3.
            Console.WriteLine("\n問題3");
            using (var wFileStreamOpen = new FileStream("Employees.xml", FileMode.Open)) {
                var wEmployeesDeserialized = (Employee[])wSerializer.ReadObject(wFileStreamOpen);

                Console.WriteLine("\n逆シリアル化された従業員データ:");
                foreach (var wEmployeeDeserialized in wEmployeesDeserialized) {
                    Console.WriteLine($"Id: {wEmployeeDeserialized.Id}, Name: {wEmployeeDeserialized.Name}, HireDate: {wEmployeeDeserialized.HireDate.ToShortDateString()}");
                }
            }

            // 4.
            Console.WriteLine("\n問題4");
            var wEmployees2 = new Employee2[]
            {
                new Employee2 { Id = 5, Name = "miyake", HireDate = new DateTime(2017, 4, 1) },
                new Employee2 { Id = 6, Name = "matsumoto", HireDate = new DateTime(2016, 4, 1) },
                new Employee2 { Id = 7, Name = "ueshiba", HireDate = new DateTime(2025, 4, 1) }
            };

            using (var wJsonFile = new FileStream("Employees.json", FileMode.Create)) {
                var wJsonSerializer = new DataContractJsonSerializer(typeof(Employee2[]));
                wJsonSerializer.WriteObject(wJsonFile, wEmployees2);
            }
            Console.WriteLine("JSONファイルにシリアル化されたデータ:");
            Console.WriteLine(File.ReadAllText("Employees.json"));
        }
    }
}

