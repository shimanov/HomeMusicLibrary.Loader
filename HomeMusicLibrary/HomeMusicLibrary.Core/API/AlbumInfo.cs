using Spectre.Console;
using SpotifyAPI.Web;

namespace HomeMusicLibrary.Core.API;

public class AlbumInfo
{
    public string token;
    public string artistId;

    public async Task Album()
    {
        var spotifyAblum = new SpotifyClient(token);
        var searchAlbums = await spotifyAblum.Artists.GetAlbums(artistId);
        if (searchAlbums.Items != null)
        {
            //Save link on cover album in database
            // foreach (var item in searchAlbums.Items)
            // {
            //     foreach (var image in item.Images)
            //     {
            //         await using (var context = new ApplicationContext())
            //         {
            //             var albumImage = new Model.AlbumsTable()
            //             {
            //                 CoverAlbum = image.Url
            //             };
            //             await context.AlbumsTables.AddRangeAsync(albumImage);
            //             await context.SaveChangesAsync();
            //         }
            //     }
            // }
            
            //Save data album in datebase
            foreach (var album in searchAlbums.Items)
            {
                await using (var context = new ApplicationContext())
                {
                    var albumInfo = new Model.AlbumsTable
                    {
                        Id = Guid.NewGuid().ToString(),
                        ArtistId = artistId,
                        Album = album.Name,
                        TypeAlbum = album.Type,
                        RealiseDate = album.ReleaseDate,
                        TotalTracks = album.TotalTracks,
                        AlbumId = album.Id,
                    };
                    try
                    {
                        await context.AlbumsTables.AddRangeAsync(albumInfo);
                        await context.SaveChangesAsync();
                        AnsiConsole.MarkupLine("Album: {0}\n realise date: {1}\n Type: {2}\n Total Tracks: {3}\n Id: {4}\n\n " +
                                               "[thistle1]:check_mark_button: Записано в таблицу\n\n[/]",
                            album.Name, album.ReleaseDate, album.Type, album.TotalTracks, album.Id);
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