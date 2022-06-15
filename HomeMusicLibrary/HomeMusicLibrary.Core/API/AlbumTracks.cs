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
            foreach (var tracks in searchTracks.Items)
            {
                await using (var context = new ApplicationContext())
                {
                    var track = new Model.AlbumTracksTable
                    {
                        Id = Guid.NewGuid().ToString(),
                        AlbumId = tracks.Id,
                        TrackNumber = tracks.TrackNumber,
                        TrackName = tracks.Name,
                        Duration = tracks.DurationMs
                    };
                    await context.TracksTables.AddRangeAsync(track);
                    await context.SaveChangesAsync();
                }
                Console.WriteLine("{0}. {1}. {2}", tracks.TrackNumber, tracks.Name, tracks.DurationMs);
            }
        }
    }
}