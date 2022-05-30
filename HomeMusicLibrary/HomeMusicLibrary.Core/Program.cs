// See https://aka.ms/new-console-template for more information

using SpotifyAPI.Web;

var spotify = new SpotifyClient("BQAy0oTGR_DAXCMJvM-zhczy4M03eFNjw9LHl-4AVbqbfkgBWWqVMF3vEnGzbz3i9ZvEdpiX2tw2hE4LU6eZWb528jEXGgIysrrDV7h1Mi4TeEg6nZ31YObyEIDhvgQv9OqAvOxxNqCOAOE7mVdoRBaj3ZmJieE");
var track = await spotify.Artists.GetAlbums("0lVlNsuGaOr9vMHCZIAKMt");


foreach (var t in track.Items)
{
    Console.WriteLine("Album: {0}\n realise date: {1}\n Type: {2}", t.Name, t.ReleaseDate, t.Type);
}