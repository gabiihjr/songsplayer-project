using SongsPlayer.Domain.DTOs;
using SongsPlayer.Domain.Models;

namespace SongsPlayer.Infra.Data.Interface;

public interface IAlbumRepository
{
    Task<Album> RegisterAlbum(Album album, Guid artistGuid);
}