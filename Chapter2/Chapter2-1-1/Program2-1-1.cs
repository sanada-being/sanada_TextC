using System;
using System.Collections.Generic;
namespace Chapter2_1_1 {
    internal class Program {
        /*
1. 以下のプロパティを持つSongクラスを定義してください。
Title : string型　（歌のタイトル)
ArtistName : string型　（アーティスト名）
Length : int型　（演奏時間、単位は秒）

2. この時、3つの引数を持つコンストラクタも定義してください。

3. 作成したSongクラスのインスタンスを複数生成し、配列wsongsに格納してください。

4. 配列に格納されたすべてのSongオブジェクトの内容をコンソールに表示してください。
演奏時間の表示は「4:16」のような書式にしてください。ただし、演奏時間は必ず60分未満と仮定してよいです。
        */
        static void Main(string[] args) {

            // インスタンスを格納するList
            List<Song> wSongs = new List<Song>();

            //Songクラスのインスタンスを追加
            wSongs.Add(new Song("エイリアンズ", "キリンジ", 376));
            wSongs.Add(new Song("aoi", "サカナクション", 253));
            wSongs.Add(new Song("花束", "サンボマスター", 401));

            //コンソールにSongオブジェクトの内容を表示
            foreach (var wSong in wSongs) {
                Console.WriteLine($"{wSong.Title}は{wSong.ArtistName}の曲です。局の長さは{wSong.Length / 60}:{wSong.Length % 60:00}秒です。");
            }
        }
    }
}
