// See https://aka.ms/new-console-template for more information

using HomeMusicLibrary.Core.API;

var _token = "BQD5dxS1IT-otQVylbBo8LQNH8BdGjOwhieaGYeHx2MZ41IPg5MUepoEst3DJA4CJuZXcaVCqOWWEhdWB4guy_tq0D8OWAp2wS3lASCdvwfmOSgKL1vg_15huJCJSrD6DFaGsIzuxwdxO0ASxn1L3lB2kdgDTLE";

var search = new Search
{
    token = _token,
    artist = "Rammstein"
};
await search.Artist();

var album = new AlbumInfo()
{
    token = _token,
    artistId = "0lVlNsuGaOr9vMHCZIAKMt"
};
await album.Album();



//var spotify = new SpotifyClient("BQCa0HcJkNdLu6zLySpGieAas9cr534rCJtUEc1sW3pxkQ88MdFJ3k75MDQ2d8WR0RfvEq7vEodpDfJJ_M4pHwrZhmbDivjzXz8RA4dwcoS9KMaKsF0daC9z-CjlGpOuGoQIhayyg27JxhJG4gPNHXoLq9MAiy4");

//Поиск по названию артиста
// var search = await spotify.Search.Item(new SearchRequest(SearchRequest.Types.Artist, "lorna shore"));
// await foreach (var item in spotify.Paginate(search.Artists, (s) => s.Artists))
// {
//     if (item.Name == "Lorna Shore")
//     {
//         Console.WriteLine("Artist: {0}\n ID: {1}\n", item.Name, item.Id);
//     }
// }
    
//Выводим инфу по альбому
// var albums = await spotify.Artists.GetAlbums("0lVlNsuGaOr9vMHCZIAKMt");
// if (albums.Items != null)
//     foreach (var t in albums.Items)
//     {
//         Console.WriteLine("Album: {0}\n realise date: {1}\n Type: {2}\n Total Tracks: {3}\n Id: {4}\n\n",
//             t.Name, t.ReleaseDate, t.Type, t.TotalTracks, t.Id);
//     }

//Выводим список треков с альбома
// var track = await spotify.Albums.GetTracks("5OhAVXSslPqvWkh7XEj4Wq");
// if (track.Items != null)
//     foreach (var t in track.Items)
//     {
//         Console.WriteLine("{0}. {1}. {2}", t.TrackNumber, t.Name, t.DurationMs);
//     }
