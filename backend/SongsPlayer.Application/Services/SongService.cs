using SongsPlayer.Application.Interfaces;
using SongsPlayer.Domain.Models;

namespace SongsPlayer.Application.Services;

public class SongService : ISongService
{
    public Song RegisterSong(Song song)
    {
        return song;
    }
}