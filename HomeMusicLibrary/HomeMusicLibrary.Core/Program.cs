// See https://aka.ms/new-console-template for more information

using HomeMusicLibrary.Core.API;

var spToken = new SpotifyToken();
string token = await spToken.Token();

var search = new Search
{
    token = token,
    artist = "MajorVoice"
};
await search.Artist();

var album = new AlbumInfo()
{
    token = token,
    artistId = "6oBT7BaxDA9UakaNepYMCY"
};
await album.Album();

var tracks = new AlbumTracks()
{
    token = token,
    albumsId = "3h8uLEWJtLmfVXtMEMkvPu"
};
await tracks.Tracks();
