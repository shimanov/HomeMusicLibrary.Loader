// See https://aka.ms/new-console-template for more information

using HomeMusicLibrary.Core.API;

var spToken = new SpotifyToken();
await spToken.Token();

const string token = "BQCre69R-WUxfPytJmqdpljzMoW_8j85-1tc_c73MnXqoRpywK0OpXSgtj9HAAjd1RuOtpGRWYpyiCzoVqs";

var search = new Search
{
    token = token,
    artist = "Rammstein"
};
await search.Artist();

var album = new AlbumInfo()
{
    token = token,
    artistId = "0lVlNsuGaOr9vMHCZIAKMt"
};
await album.Album();

var tracks = new AlbumTracks()
{
    token = token,
    albumsId = "5OhAVXSslPqvWkh7XEj4Wq"
};
await tracks.Tracks();
