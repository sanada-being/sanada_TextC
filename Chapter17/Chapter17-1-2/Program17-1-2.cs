using System;

namespace Chapter17_1_2 {
    // 「17.3」で示した距離換算プログラムに機能を追加し、マイルとキロメートルも扱えるようにしてください。
    class Program {
        static void Main(string[] args) {
            while (true) {
                var wFrom = GetConverter("変換元の単位を入力してください　使用出来る単位:キロメートル　マイル");
                var wTo = GetConverter("変換先の単位を入力してください　使用出来る単位:キロメートル　マイル");
                var wDistance = ReadDistance(wFrom);

                var wConverter = new DistanceConverter(wFrom, wTo);
                var wResult = wConverter.Convert(wDistance);
                Console.WriteLine($"{wDistance}{wFrom.UnitName}は、{wResult}{wTo.UnitName}です\n");
            }
        }

        static double ReadDistance(ConverterBase vFrom) {
            Console.WriteLine($"変換したい距離を数字で(単位:{vFrom.UnitName})入力してください");
            double wValue;
            string wLine = Console.ReadLine();
            while (!double.TryParse(wLine, out wValue)) {
                Console.WriteLine("無効な入力です。再度変換したい距離を入力してください。");
                wLine = Console.ReadLine();
            }
            return wValue;
        }

        static ConverterBase GetConverter(string vMessage) {
            Console.WriteLine(vMessage);

            while (true) {
                Console.Write("=>");
                string wUnit = Console.ReadLine();
                ConverterBase wConverter = ConverterFactory.GetInstance(wUnit);

                if (wConverter != null) {
                    return wConverter;
                }
                Console.WriteLine("再度単位名を入力してください");
            }
        }
    }
}
