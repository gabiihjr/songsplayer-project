using AutoMapper;
using SongsPlayer.Domain.DTOs;
using SongsPlayer.Domain.Models;

namespace SongsPlayer.AutoMapper;
public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<RegisterSongDto, Song>().ReverseMap();
        CreateMap<Song, GetSongDto>().ReverseMap();
        CreateMap<Artist, GetArtistDto>().ReverseMap();
        CreateMap<RegisterArtistDto, Artist>().ReverseMap();
        CreateMap<Album, GetAlbumDto>().ReverseMap();
    }
}
