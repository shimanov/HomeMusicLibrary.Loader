using System.ComponentModel.DataAnnotations;

namespace HomeMusicLibrary.Core.Model;

public class AlbumTracksTable
{
    [Key, Required]
    public int Id { get; set; }
    
    public string AlbumId { get; set; }
    
    public int TrackNumber { get; set; }
    
    public string TrackName { get; set; }
    
    public int Duration { get; set; }
}