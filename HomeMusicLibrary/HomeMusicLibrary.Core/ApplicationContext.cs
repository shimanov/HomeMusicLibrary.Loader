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
        optionsBuilder.UseMySql("server=localhost;user=root;password=123456789;database=usersdb;",
            new MariaDbServerVersion(new Version(8, 0, 25)));
    }
}