using SongsPlayer.Domain.Models;

namespace SongsPlayer.Application.Interfaces;

public interface ISongService
{
    Song RegisterSong(Song song);
}