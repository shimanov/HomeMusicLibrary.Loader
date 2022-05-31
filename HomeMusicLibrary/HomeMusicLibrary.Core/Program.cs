// See https://aka.ms/new-console-template for more information

using SpotifyAPI.Web;

var spotify = new SpotifyClient("BQBch_4XSnFeZT0U4cQknXRefF71Ruhxt3ljAvJlRS2JrCpxid34aUw9LQY7YwNfIXemhYfQMr8C7E4AwkcKJQgD3C6KdqMyWef7_swG51GTQd31PBZfGu2dzF8Vg8Wq9QeA2BSGJMrPNZzvBh5pLjiuRlEt01A");

//Поиск по названию артиста
var search = await spotify.Search.Item(new SearchRequest(SearchRequest.Types.Artist, "lorna shore"));
await foreach (var item in spotify.Paginate(search.Artists, (s) => s.Artists))
{
    if (item.Name == "Lorna Shore")
    {
        Console.WriteLine("Artist: {0}\n ID: {1}\n", item.Name, item.Id);
    }
    
}
    
//Выводим инфу по альбому
var albums = await spotify.Artists.GetAlbums("0lVlNsuGaOr9vMHCZIAKMt");
if (albums.Items != null)
    foreach (var t in albums.Items)
    {
        Console.WriteLine("Album: {0}\n realise date: {1}\n Type: {2}\n Total Tracks: {3}\n Id: {4}\n\n",
            t.Name, t.ReleaseDate, t.Type, t.TotalTracks, t.Id);
    }

var track = await spotify.Albums.GetTracks("5OhAVXSslPqvWkh7XEj4Wq");
foreach (var t in track.Items)
{
    Console.WriteLine("{0}. {1}. {2}", t.TrackNumber, t.Name, t.DurationMs );
}
