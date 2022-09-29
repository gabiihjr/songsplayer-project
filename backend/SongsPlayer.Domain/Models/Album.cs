using SongsPlayer.Infra.Data.Context.Entities;

namespace SongsPlayer.Domain.Models;

public class Album : Entity
{
    public string Name { get; set; }
    
    public List<Song> Songs { get; set; }
    
    public Artist Artist { get; set; }
}