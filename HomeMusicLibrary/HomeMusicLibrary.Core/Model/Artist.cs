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

    public List<ArtistImages> ArtistImagesList { get; set; }
}

public class ArtistImages
{
    public int Height { get; set; }
    public int Width { get; set; }
    public string Url { get; set; }
}