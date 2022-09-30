namespace SongsPlayer.Domain.DTOs;

public class GetSongDto
{
    public string Name { get; set; }
    
    public GetArtistDto Artist { get; set; }
    
    public GetAlbumDto Album { get; set; }
}