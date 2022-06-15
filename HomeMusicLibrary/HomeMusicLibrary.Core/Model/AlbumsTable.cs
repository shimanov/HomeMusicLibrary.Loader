using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HomeMusicLibrary.Core.Model;

public class AlbumsTable
{
    [Key, Required]
    public string Id { get; set; }
    
    [AllowNull]
    public string ArtistId { get; set; }
    
    public string Album { get; set; }
    
    [AllowNull]
    public string TypeAlbum { get; set; }
    
    [AllowNull]
    public string RealiseDate { get; set; }
    
    [AllowNull]
    public int TotalTracks { get; set; }
    
    [AllowNull]
    public string AlbumId { get; set; }
    
    //[AllowNull]
    //public string CoverAlbum { get; set; }
}