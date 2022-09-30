using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SongsPlayer.Domain.DTOs;
using SongsPlayer.Domain.Models;

namespace SongsPlayer.AutoMapper;
public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<RegisterSongDto, Song>();
        CreateMap<Song, GetSongDto>();
        CreateMap<Artist, GetArtistDto>();
        CreateMap<Album, GetAlbumDto>();
    }
}
