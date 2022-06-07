namespace HomeMusicLibrary.Core.API;
using SpotifyAPI.Web;

public class SpotifyToken
{
    public async Task Token()
    {
        var config = SpotifyClientConfig.CreateDefault();
        var request =
            new ClientCredentialsRequest("23764d882c704915ae47b1f94fa5714e", "d39b85cda0ee461b8cc84f2e7984f907");
        var response = await new OAuthClient(config).RequestToken(request);
        var spotiToken = new SpotifyClient(config.WithToken(response.AccessToken));
    }
}