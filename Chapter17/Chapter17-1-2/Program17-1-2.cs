using System;

namespace Chapter17_1_2 {
    // 「17.3」で示した距離換算プログラムに機能を追加し、マイルとキロメートルも扱えるようにしてください。
    class Program {
        static void Main(string[] args) {
            while (true) {
                var wFrom = GetConverter("変換元の単位を入力してください　使用出来る単位:キロメートル　マイル");
                var wTo = GetConverter("変換先の単位を入力してください　使用出来る単位:キロメートル　マイル");
                var wDistance = GetDistance(wFrom);

                var wConverter = new DistanceConverter(wFrom, wTo);
                var wResult = wConverter.Convert(wDistance);
                Console.WriteLine($"{wDistance}{wFrom.UnitName}は、{wResult}{wTo.UnitName}です\n");
            }
        }

        static double GetDistance(ConverterBase vFrom) {
            double? wValue = null;
            do {
                Console.WriteLine($"変換したい距離を数字で(単位:{vFrom.UnitName})入力してください");
                var wLine = Console.ReadLine();
                double wTemp;
                wValue = double.TryParse(wLine, out wTemp) ? (double?)wTemp : null;
            } while (wValue == null);
            return wValue.Value;
        }

        static ConverterBase GetConverter(string vMessege) {
            ConverterBase wConverter = null;
            do {
                Console.WriteLine(vMessege + " => ");
                var wUnit = Console.ReadLine();
                wConverter = ConverterFactory.GetInstance(wUnit);
            } while (wConverter == null);
            return wConverter;
        }
    }
}
