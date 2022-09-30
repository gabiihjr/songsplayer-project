using SongsPlayer.Domain.Models;

namespace SongsPlayer.Domain.DTOs;

public class GetArtistDto
{
    public Guid Guid { get; set; }
    
    public string Name { get; set; }
    
    public List<Album> Albums { get; set; }
}