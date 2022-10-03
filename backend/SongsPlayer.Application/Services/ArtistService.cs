using AutoMapper;
using SongsPlayer.Application.Interfaces;
using SongsPlayer.Domain.DTOs;
using SongsPlayer.Domain.Models;
using SongsPlayer.Infra.Data.Interface;

namespace SongsPlayer.Application.Services;

public class ArtistService : IArtistService
{
    private readonly IArtistRepository _artistRepository;
    private readonly IMapper _mapper;

    public ArtistService(IArtistRepository artistRepository, IMapper mapper)
    {
        _artistRepository = artistRepository;
        _mapper = mapper;
    }

    public async Task<RegisterArtistDto> RegisterArtist(RegisterArtistDto artist)
    {
        var artistMapper = _mapper.Map<Artist>(artist);
        await _artistRepository.RegisterArtist(artistMapper);

        return artist;
    }

    public async Task<List<GetArtistDto>> GetArtists()
    {
        var artists = await _artistRepository.GetArtists();

        return _mapper.Map<List<GetArtistDto>>(artists);
    }

    public async Task<GetArtistDto> GetArtistByGuid(Guid artistGuid)
    {
        var artist = await _artistRepository.GetArtistByGuid(artistGuid);

        return _mapper.Map<GetArtistDto>(artist);
    }
}