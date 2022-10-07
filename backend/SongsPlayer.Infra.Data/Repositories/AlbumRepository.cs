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
        _context.Albums.Add(album);
        await _context.SaveChangesAsync();
        return album;
    }
}