using Microsoft.EntityFrameworkCore;
using SongsPlayer.Domain.DTOs;
using SongsPlayer.Domain.Models;
using SongsPlayer.Infra.Data.Context;
using SongsPlayer.Infra.Data.Interface;

namespace SongsPlayer.Infra.Data.Repositories;

public class AlbumRepository : IAlbumRepository
{
    private readonly SongsPlayerDbContext _context;

    public AlbumRepository(SongsPlayerDbContext context)
    {
        _context = context;
    }

    public async Task<Album> RegisterAlbum(Album album, Guid artistGuid)
    {
        var artist = await _context.Artists
            .Include(a => a.Albums)
                .ThenInclude(ab => ab.Songs)
            .Where(a => a.Guid == artistGuid)
            .FirstOrDefaultAsync();
        
        if (artist == default) throw new Exception("Artista não encontrado");
        
        album.Artist.Guid = artist.Guid;
        album.Artist.Name = artist.Name;

        artist.Albums.Add(album);
        _context.Artists.Update(artist);
        await _context.SaveChangesAsync();
        return album;
    }
}