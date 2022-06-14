using HomeMusicLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HomeMusicLibrary.Core;

public class ApplicationContext : DbContext
{
    public DbSet<Artist> Artists { get; set; } = null!;
    public DbSet<AlbumsTable> AlbumsTables { get; set; } = null!;
    public DbSet<AlbumTracksTable> TracksTables { get; set; } = null!;

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=192.168.1.200;user=sa;password=qwep[]ghjB1;database=HomeMusicLibrary;",
            new MariaDbServerVersion(new Version(10, 8, 3)));
    }
}