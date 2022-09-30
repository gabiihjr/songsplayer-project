using SongsPlayer.Domain.Models;

namespace SongsPlayer.Infra.Data.Interface;

public interface IArtistRepository
{
    Task<Artist> RegisterArtist(Artist artist);
}