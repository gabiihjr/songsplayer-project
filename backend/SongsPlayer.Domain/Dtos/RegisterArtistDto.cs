using System.ComponentModel.DataAnnotations;

namespace SongsPlayer.Domain.DTOs;

public class RegisterArtistDto
{
    [Required]
    public string Name { get; set; }
}