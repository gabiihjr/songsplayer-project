using SongsPlayer.Infra.Data.Context.Entities;

namespace SongsPlayer.Domain.Models;

public class Song : Entity
{
    public string Name { get; set; }
    
    public Artist Artist { get; set; }
    
    public Album Album { get; set; }
}