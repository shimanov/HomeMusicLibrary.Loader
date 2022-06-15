using System.ComponentModel.DataAnnotations;

namespace HomeMusicLibrary.Core.Model;

public class Artist
{
    [Required, Key]
    public string Id { get; set; }
    
    public string ArtistName { get; set; }
    
    public string ArtistId { get; set; }
}