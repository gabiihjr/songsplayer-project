using System.ComponentModel.DataAnnotations;

namespace SongsPlayer.Domain.DTOs;

public class RegisterAlbumDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public Guid ArtistGuid { get; set; }
    
    [Required]
    public int Year { get; set; }
}