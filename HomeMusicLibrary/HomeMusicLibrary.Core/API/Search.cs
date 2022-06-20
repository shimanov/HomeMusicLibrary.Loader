using Spectre.Console;

namespace HomeMusicLibrary.Core.API;
using SpotifyAPI.Web;

public class Search
{
    public string token;
    string artist;

    public async Task Artist()
    {
        string[] art = File.ReadAllLines(Environment.CurrentDirectory + @"/art.txt");
        if (art.Length != 0)
        {
            foreach (string s in art)
            {
                artist = s;
                var spotify = new SpotifyClient(token);
                var search = await spotify.Search.Item(new SearchRequest(SearchRequest.Types.Artist, artist));
                await foreach (var a in spotify.Paginate(search.Artists, (s) => s.Artists))
                {
                    if (s == a.Name)
                    {
                        await using (var context = new ApplicationContext())
                        {
                            var artist = new Model.Artist
                            {
                                Id = Guid.NewGuid().ToString(),
                                ArtistName = a.Name,
                                ArtistId = a.Id,
                            };
                            try
                            {
                                await context.Artists.AddRangeAsync(artist);
                                await context.SaveChangesAsync();
                                AnsiConsole.MarkupLine("Artist: {0}\n ID: {1}\n [thistle1]:check_mark_button: Записано в таблицу\n\n[/]", 
                                    a.Name, a.Id);
                            }
                            catch (Exception e)
                            {
                                AnsiConsole.WriteException(e);
                            }
                        }
                        
                    }
                }
            }
        }
        else
        {
            AnsiConsole.WriteLine("[yellow3]Нет данных для поиска[/]");
        }
        
        
    }
}