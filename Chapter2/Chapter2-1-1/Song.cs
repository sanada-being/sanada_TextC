// 1.2 Songクラスでプロパティとコンストラクタを定義
namespace Chapter2_1_1 {
    /// <summary>
    /// 歌クラス
    /// </summary>
    internal class Song {

        /// <summary>
        /// 曲名
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// アーティスト名
        /// </summary>
        public string ArtistName { get; set; }

        /// <summary>
        /// 曲の長さ
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vTitle">曲名</param>
        /// <param name="vArtistname">アーティスト名</param>
        /// <param name="vLength">曲の長さ</param>
        public Song(string vTitle, string vArtistname, int vLength) {
            Title = vTitle;
            ArtistName = vArtistname;
            Length = vLength;
        }
    }
}
