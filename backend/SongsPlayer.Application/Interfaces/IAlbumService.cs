using SongsPlayer.Domain.DTOs;

namespace SongsPlayer.Application.Interfaces;

public interface IAlbumService
{
    Task<RegisterAlbumDto> RegisterAlbum(RegisterAlbumDto album);
}
