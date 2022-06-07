namespace HomeMusicLibrary.Core.API;
using SpotifyAPI.Web;

public class SpotifyToken
{
    static Task<string> Token()
    {
        var config = SpotifyClientConfig
            .CreateDefault()
            .WithAuthenticator(new ClientCredentialsAuthenticator("23764d882c704915ae47b1f94fa5714e", "23764d882c704915ae47b1f94fa5714e"));
        var spotify = new SpotifyClient(config);
        return Task.FromResult(spotify.ToString());
    }
}