// See https://aka.ms/new-console-template for more information

using HomeMusicLibrary.Core.API;

var spToken = new SpotifyToken();
await spToken.Token();

const string token = "BQD5dxS1IT-otQVylbBo8LQNH8BdGjOwhieaGYeHx2MZ41IPg5MUepoEst3DJA4CJuZXcaVCqOWWEhdWB4guy_tq0D8OWAp2wS3lASCdvwfmOSgKL1vg_15huJCJSrD6DFaGsIzuxwdxO0ASxn1L3lB2kdgDTLE";

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
