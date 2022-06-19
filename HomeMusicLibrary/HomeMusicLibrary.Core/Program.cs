// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using HomeMusicLibrary.Core;
using HomeMusicLibrary.Core.API;
using HomeMusicLibrary.Core.Model;
using Spectre.Console;

//Menu
var menu = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Что необходимо сделать?")
        .PageSize(10)
        .MoreChoicesText("[grey]Подсказочка[/]")
        .AddChoices(new []
        {
          "Добавить новых исполнителей из файла",
          "Добавить нового исполнителя",
          "Добавить новые вышедшие альбомы"
        }));
AnsiConsole.WriteLine(menu);


    Stopwatch stopwatch = new Stopwatch();
var spToken = new SpotifyToken();
string token = await spToken.Token();

//Шаг 1. Ищем исполнителя из файла и сохраняем в бд
//Шаг 2. Берем из БД ID артиста и находим все альбомы
//Шаг 3. Берем ID альбома и ищем его

stopwatch.Start();
//Step 1
var rules = new Rule("[chartreuse1]Добавление исполнителя в БД[/]")
{
    Alignment = Justify.Left
};
AnsiConsole.Write(rules);
var searchArt = new Search()
{
    token = token
};
await searchArt.Artist();

//Step 2
var rule = new Rule("[chartreuse1]Добавление списка альбомов в БД[/]")
{
    Alignment = Justify.Left
};
AnsiConsole.Write(rule);
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
}

//Step 3
var rul = new Rule("[chartreuse1]Добавление треков в БД[/]")
{
    Alignment = Justify.Left
};
AnsiConsole.Write(rul);
using (ApplicationContext db = new ApplicationContext())
{
    var tracks = db.AlbumsTables.ToList();
    foreach (AlbumsTable track in tracks)
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
AnsiConsole.MarkupLine("[lightcyan1]Затрачено времени: {0}[/]", elapsedTime);
