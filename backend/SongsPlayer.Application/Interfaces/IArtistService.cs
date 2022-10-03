
using SongsPlayer.Domain.DTOs;

namespace SongsPlayer.Application.Interfaces;

public interface IArtistService
{
    Task<RegisterArtistDto>  RegisterArtist(RegisterArtistDto artist);

    Task<List<GetArtistDto>> GetArtists();

    Task<GetArtistDto> GetArtistByGuid(Guid artistGuid);
}