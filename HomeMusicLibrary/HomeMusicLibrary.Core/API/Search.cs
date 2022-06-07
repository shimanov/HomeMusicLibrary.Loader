namespace HomeMusicLibrary.Core.API;
using SpotifyAPI.Web;

public class Search
{
    public string token;
    public string artist;

    public async Task<string?> Artist()
    {
        string? result = null;
        var spotify = new SpotifyClient(token);
        var search = await spotify.Search.Item(new SearchRequest(SearchRequest.Types.Artist, artist));
        await foreach (var a in spotify.Paginate(search.Artists, (s) => s.Artists))
        {
            if (a.Name != artist) continue;
            Console.WriteLine("Artist: {0}\n ID: {1}\n", a.Name, a.Id);
            return a.Name;
        }
        return result;
    }
    
}