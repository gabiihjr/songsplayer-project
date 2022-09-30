using System.ComponentModel.DataAnnotations;
using SongsPlayer.Domain.Models;

namespace SongsPlayer.Domain.DTOs;

public class RegisterSongDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public Guid ArtistGuid { get; set; }
    
    [Required]
    public Guid AlbumGuid { get; set; }
}