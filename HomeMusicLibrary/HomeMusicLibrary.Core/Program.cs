// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Threading.Channels;
using HomeMusicLibrary.Core;
using HomeMusicLibrary.Core.API;
using HomeMusicLibrary.Core.Model;

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

var spToken = new SpotifyToken();
string token = await spToken.Token();

//Шаг 1. Ищем исполнителя из файла и сохраняем в бд
//Шаг 2. Берем из БД ID артиста и находим все альбомы
//Шаг 3. Берем ID альбома и ищем его

//Step 1
string[] art = File.ReadAllLines(Environment.CurrentDirectory + @"/art.txt");
foreach (string s in art)
{
    if (s != string.Empty)
    {
        string name = s;
        var searchArt = new Search()
        {
            token = token,
            artist = name
        };
        await searchArt.Artist();  
    }
    else
    {
        Console.WriteLine("Нет данных для поиска");
    }
}


//Step 2
using (ApplicationContext db = new ApplicationContext())
{
    var artists = db.Artists.ToList();
    foreach (Artist a in artists)
    {
        var album = new AlbumInfo()
        {
            token = token,
            artistId = a.ArtistId
        };
        await album.Album();
        
        Console.WriteLine(a.ArtistId);
    }
    
    //Step 3
    var tracks = db.TracksTables.ToList();
    foreach (AlbumTracksTable track in tracks)
    {
        var tr = new AlbumTracks()
        {
            token = token,
            albumsId = track.AlbumId
        };
        await tr.Tracks();
    }
}

stopwatch.Stop();
TimeSpan timeSpan = stopwatch.Elapsed;
string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
    timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
Console.WriteLine("Выполнено за " + elapsedTime);