namespace HomeMusicLibrary.Core.API;
using SpotifyAPI.Web;

public class Search
{
    public string token;
    public string artist;

    public async Task Artist()
    {
        var spotify = new SpotifyClient(token);
        var search = await spotify.Search.Item(new SearchRequest(SearchRequest.Types.Artist, artist));
        await foreach (var a in spotify.Paginate(search.Artists, (s) => s.Artists))
        {
            if (artist.Equals(a.Name.ToLower()))
            {
                await using (var context = new ApplicationContext())
                {
                    var artist = new Model.Artist
                    {
                        Id = Guid.NewGuid().ToString(),
                        ArtistName = a.Name,
                        ArtistId = a.Id,
                    };
                    await context.Artists.AddRangeAsync(artist);
                    await context.SaveChangesAsync();
                }
                Console.WriteLine("Artist: {0}\n ID: {1}\n", a.Name, a.Id);
            }
            else
            {
                Console.WriteLine("Совпадений не найдено");
            }
            
        }
    }
}