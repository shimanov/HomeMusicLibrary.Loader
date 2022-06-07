using SpotifyAPI.Web;

namespace HomeMusicLibrary.Core.API;

public class AlbumTracks
{
    public string token;
    public string albumsId;

    public async Task Tracks()
    {
        var spotifyTracks = new SpotifyClient(token);
        var searchTracks = await spotifyTracks.Albums.GetTracks(albumsId);
        if (searchTracks.Items != null)
        {
            foreach (var track in searchTracks.Items)
            {
                Console.WriteLine("{0}. {1}. {2}", track.TrackNumber, track.Name, track.DurationMs);
            }
        }
    }
}