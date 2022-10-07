using AutoMapper;
using SongsPlayer.Application.Interfaces;
using SongsPlayer.Domain.DTOs;
using SongsPlayer.Domain.Models;
using SongsPlayer.Infra.Data.Interface;

namespace SongsPlayer.Application.Services;

public class AlbumService : IAlbumService
{
    private readonly IAlbumRepository _albumRepository;
    private readonly IArtistService _artistService;
    private readonly IMapper _mapper;

    public AlbumService(IAlbumRepository albumRepository, IArtistService artistService, IMapper mapper)
    {
        _albumRepository = albumRepository;
        _artistService = artistService;
        _mapper = mapper;
    }

    public async Task<RegisterAlbumDto> RegisterAlbum(RegisterAlbumDto album)
    {
        var artist = await _artistService.GetArtistByGuid(album.ArtistGuid) ??
                     throw new Exception("Artista não encontrado");
        
        if (album.Name == null) throw new Exception("Nome do álbum precisa ser preenchido.");
        if (album.Year is < 1800 or > 2030) throw new Exception("Ano inválido.");
        if (album.ArtistGuid == Guid.Empty) throw new Exception("Artista precisa ser informado.");
        
        var albumMapper = _mapper.Map<Album>(album);
        await _albumRepository.RegisterAlbum(albumMapper, artist.Guid);

        return album;
    }
}