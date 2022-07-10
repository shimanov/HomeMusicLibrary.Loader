// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using HomeMusicLibrary.Loader;
using HomeMusicLibrary.Loader.API;
using HomeMusicLibrary.Loader.Model;
using Spectre.Console;

//Menu
var menu = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("\nЧто необходимо сделать?\n")
        .PageSize(10)
        .MoreChoicesText("[grey]Подсказочка[/]")
        .AddChoices(new []
        {
          ":muted_speaker: Добавить новых исполнителей из файла",
          ":musical_notes: Добавить новые вышедшие альбомы",
          ":musical_notes: Добавить треки"
        }));


Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
var spToken = new SpotifyToken();
string token = await spToken.Token();

//Шаг 1. Ищем исполнителя из файла и сохраняем в бд
//Шаг 2. Берем из БД ID артиста и находим все альбомы
//Шаг 3. Берем ID альбома и ищем его

//Step 1
if (menu == ":muted_speaker: Добавить новых исполнителей из файла")
{
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
    AnsiConsole.MarkupLine("[mediumpurple2]Новые исполнители добавлены БД[/]");
}


//Step 2
if (menu == ":musical_notes: Добавить новые вышедшие альбомы")
{
    var rule = new Rule("[chartreuse1]Добавление альбомов в БД[/]")
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
    AnsiConsole.MarkupLine("[mediumpurple2]Новые альбомы добавлены БД[/]");
}

//Step 3
if (menu == ":musical_notes: Добавить треки")
{
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
    AnsiConsole.MarkupLine("[mediumpurple2]Новые треки добавлены в БД[/]");
}

stopwatch.Stop();
TimeSpan timeSpan = stopwatch.Elapsed;
string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
    timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
AnsiConsole.MarkupLine("[lightcyan1]Затрачено времени: {0}[/]", elapsedTime);
