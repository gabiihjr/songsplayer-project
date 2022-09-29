using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SongsPlayer.Domain.Models;

namespace SongsPlayer.Infra.Data.Configurations;

public class SongConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.HasIndex(s => s.Guid).IsUnique();
        builder.Property(s => s.Guid).HasDefaultValueSql("gen_random_uuid()");
        builder.Property(s => s.CreatedAt).HasDefaultValueSql("NOW()");  
    }
}