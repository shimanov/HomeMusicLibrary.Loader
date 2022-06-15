using System.ComponentModel.DataAnnotations;

namespace HomeMusicLibrary.Core.Model;

public class AlbumsTable
{
    [Key, Required]
    public string Id { get; set; }
    
    public string ArtistId { get; set; }
    
    public string Album { get; set; }
    
    public string TypeAlbum { get; set; }
    
    public string RealiseDate { get; set; }
    
    public int TotalTracks { get; set; }
    
    public string AlbumId { get; set; }
    
    public string CoverAlbum { get; set; }
}