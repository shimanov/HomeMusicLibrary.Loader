using Spectre.Console;

namespace HomeMusicLibrary.Loader.API;
using SpotifyAPI.Web;

public class Search
{
    public string token;
    string artist;
    private string url;

    public async Task Artist()
    {
        string[] art = File.ReadAllLines(Environment.CurrentDirectory + @"/art.txt");
        if (art.Length != 0)
        {
            foreach (string s in art)
            {
                artist = s;
                var spotify = new SpotifyClient(token);
                try
                {
                    var search = await spotify.Search.Item(new SearchRequest(SearchRequest.Types.Artist, artist));
                    await foreach (var a in spotify.Paginate(search.Artists, (s) => s.Artists))
                    {
                        if (s == a.Name)
                        {
                            foreach (var img in a.Images)
                            {
                                if (img.Height == 300)
                                {
                                    url = img.Url;
                                }
                            }
                            await using var context = new ApplicationContext();
                            var artist = new Model.Artist
                            {
                                Id = Guid.NewGuid().ToString(),
                                ArtistName = a.Name,
                                ArtistId = a.Id,
                                Img = url
                            };
                            try
                            {
                                await context.Artists.AddRangeAsync(artist);
                                await context.SaveChangesAsync();
                                AnsiConsole.MarkupLine("Artist: {0}\n ID: {1}\n [thistle1]:check_mark_button: Записано в таблицу\n[/]", 
                                    a.Name, a.Id);
                                //AnsiConsole.MarkupLine("[cyan1]:sleeping_face: Спим 5 секунд\n [/]");
                                //Thread.Sleep(5000);
                            }
                            catch (Exception e)
                            {
                                AnsiConsole.WriteException(e);
                            }
                        }
                    }
                }
                catch (APIException e)
                {
                    AnsiConsole.WriteLine(e.Message);
                    AnsiConsole.WriteLine(e.Response?.StatusCode.ToString() ?? string.Empty);
                }
                
            }
        }
        else
        {
            AnsiConsole.WriteLine("[yellow3] Нет данных для поиска[/]");
        }
        
        
    }
}