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
            foreach (var album in searchAlbums.Items)
            {
                Console.WriteLine("Album: {0}\n realise date: {1}\n Type: {2}\n Total Tracks: {3}\n Id: {4}\n\n",
                                 album.Name, album.ReleaseDate, album.Type, album.TotalTracks, album.Id);
            }
        }
    }
}