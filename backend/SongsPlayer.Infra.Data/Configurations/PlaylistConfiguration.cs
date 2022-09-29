using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SongsPlayer.Domain.Models;

namespace SongsPlayer.Infra.Data.Configurations;

public class PlaylistConfiguration : IEntityTypeConfiguration<Playlist>
{
    public void Configure(EntityTypeBuilder<Playlist> builder)
    {
        builder.HasIndex(p => p.Guid).IsUnique();
        builder.Property(p => p.Guid).HasDefaultValueSql("gen_random_uuid()");
        builder.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()");  
    }
}