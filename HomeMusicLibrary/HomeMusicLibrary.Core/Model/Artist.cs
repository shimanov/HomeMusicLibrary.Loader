using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HomeMusicLibrary.Core.Model;

public class Artist
{
    [Required, Key]
    public string Id { get; set; }
    
    [AllowNull]
    public string ArtistName { get; set; }
    
    [AllowNull]
    public string ArtistId { get; set; }
}