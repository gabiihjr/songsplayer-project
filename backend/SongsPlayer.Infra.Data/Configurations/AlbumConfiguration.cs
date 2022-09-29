using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SongsPlayer.Domain.Models;

namespace SongsPlayer.Infra.Data.Configurations;

public class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.HasIndex(a => a.Guid).IsUnique();
        builder.Property(a => a.Guid).HasDefaultValueSql("gen_random_uuid()");
        builder.Property(a => a.CreatedAt).HasDefaultValueSql("NOW()");  
    }
}