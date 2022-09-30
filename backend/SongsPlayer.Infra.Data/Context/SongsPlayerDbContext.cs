using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SongsPlayer.Domain.Models;
using SongsPlayer.Infra.Data.Configurations;

namespace SongsPlayer.Infra.Data.Context;

public class SongsPlayerDbContext : DbContext
{
    public SongsPlayerDbContext(DbContextOptions<SongsPlayerDbContext> options) : base(options)
    {
    }
    
    public DbSet<Album> Albums { get; set; } = null;

    public DbSet<Artist> Artists { get; set; } = null;

    public DbSet<Playlist> Playlists { get; set; } = null;

    public DbSet<Song> Songs { get; set; } = null;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AlbumConfiguration());
        modelBuilder.ApplyConfiguration(new ArtistConfiguration());
        modelBuilder.ApplyConfiguration(new PlaylistConfiguration());
        modelBuilder.ApplyConfiguration(new SongConfiguration());
    }
}

