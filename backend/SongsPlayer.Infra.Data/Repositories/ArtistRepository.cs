using Microsoft.EntityFrameworkCore;
using SongsPlayer.Domain.Models;
using SongsPlayer.Infra.Data.Context;
using SongsPlayer.Infra.Data.Interface;

namespace SongsPlayer.Infra.Data.Repositories;

public class ArtistRepository : IArtistRepository
{
    private readonly SongsPlayerDbContext _context;

    public ArtistRepository(SongsPlayerDbContext context)
    {
        _context = context;
    }

    public async Task<Artist> RegisterArtist(Artist artist)
    {
        _context.Artists.Add(artist);
        await _context.SaveChangesAsync();
        return artist;
    }

    public async Task<List<Artist>> GetArtists()
    {
        return await _context.Artists
            .ToListAsync();
    }

    public async Task<Artist> GetArtistByGuid(Guid artistGuid)
    {
        var artist = await _context.Artists
            .Where(a => a.Guid == artistGuid)
            .FirstOrDefaultAsync();

        if (artist == default) throw new Exception("Esse artista não existe.");
        
        return artist;
    }
}