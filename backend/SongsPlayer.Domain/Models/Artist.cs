using SongsPlayer.Infra.Data.Context.Entities;

namespace SongsPlayer.Domain.Models;

public class Artist : Entity
{
    public string Name { get; set; }
    
    public List<Album> Albums { get; set; }
}