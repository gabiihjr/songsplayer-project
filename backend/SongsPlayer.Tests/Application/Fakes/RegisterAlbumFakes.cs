using Bogus;
using SongsPlayer.Domain.DTOs;

namespace SongsPlayer.Tests.Application.Fakes;

public class RegisterAlbumFakes
{
    public static Faker<RegisterAlbumDto> RegisterAlbumDto =>
        new Faker<RegisterAlbumDto>("pt_BR")
            .RuleFor(a => a.Name, f => f.Random.String(1, 999))
            .RuleFor(a => a.Year, f => f.Random.Int(1800, 2030))
            .RuleFor(a => a.ArtistGuid, f => f.Random.Guid());
}