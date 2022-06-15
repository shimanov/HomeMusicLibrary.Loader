// See https://aka.ms/new-console-template for more information

using HomeMusicLibrary.Core.API;

var spToken = new SpotifyToken();
string token = await spToken.Token();

//Шаг 1. Ищем исполнителя из файла и сохраняем в бд
//Шаг 2. Берем из БД ID артиста и находим все альбомы
//Шаг 3. Берем ID альбома и ищем его

string[] art = File.ReadAllLines(Environment.CurrentDirectory + @"/art.txt");
foreach (string s in art)
{
    string name = s;
    var searchArt = new Search()
    {
        token = token,
        artist = name
    };
    await searchArt.Artist();
}



// var album = new AlbumInfo()
// {
//     token = token,
//     artistId = "6oBT7BaxDA9UakaNepYMCY"
// };
// await album.Album();
//
// var tracks = new AlbumTracks()
// {
//     token = token,
//     albumsId = "3h8uLEWJtLmfVXtMEMkvPu"
// };
// await tracks.Tracks();
