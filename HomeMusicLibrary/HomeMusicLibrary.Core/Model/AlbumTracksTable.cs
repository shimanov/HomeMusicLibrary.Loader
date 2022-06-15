using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HomeMusicLibrary.Core.Model;

public class AlbumTracksTable
{
    [Key, Required]
    public string Id { get; set; }
    
    [AllowNull]
    public string AlbumId { get; set; }
    
    [AllowNull]
    public int TrackNumber { get; set; }
    
    [AllowNull]
    public string TrackName { get; set; }
    
    [AllowNull]
    public int Duration { get; set; }
}