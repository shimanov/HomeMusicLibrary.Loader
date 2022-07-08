namespace HomeMusicLibrary.Loader.API;
using SpotifyAPI.Web;

public class SpotifyToken
{
    public async Task<string> Token()
    {
        var config = SpotifyClientConfig.CreateDefault();
        var request =
            new ClientCredentialsRequest("23764d882c704915ae47b1f94fa5714e", "d39b85cda0ee461b8cc84f2e7984f907");
        var response = await new OAuthClient(config).RequestToken(request);
        Console.WriteLine("Token: {0}\n Expired: {1}\n ExpiresIn: {2}", response.AccessToken, response.IsExpired, response.ExpiresIn);
        return response.AccessToken;
        //var spotiToken = new SpotifyClient(config.WithToken(response.AccessToken));
    }
}