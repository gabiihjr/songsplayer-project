using SongsPlayer.Infra.Data.Context.Entities;

namespace SongsPlayer.Domain.Models;

public class Playlist : Entity
{
    public string Name { get; set; }
    
    public List<Song> Song { get; set; }
    
    public int SongsQuantity { get; set; }
}