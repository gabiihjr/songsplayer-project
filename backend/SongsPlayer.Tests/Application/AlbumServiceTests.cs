using AutoMapper;
using NSubstitute;
using NSubstitute.ClearExtensions;
using SongsPlayer.Application.Interfaces;
using SongsPlayer.Application.Services;
using SongsPlayer.AutoMapper;
using SongsPlayer.Domain.DTOs;
using SongsPlayer.Domain.Models;
using SongsPlayer.Infra.Data.Interface;
using SongsPlayer.Tests.Application.Fakes;
using Xunit;

namespace SongsPlayer.Tests.Application;

public class AlbumServiceTests : IDisposable
{
    private readonly AlbumService _albumService;
    private readonly IAlbumRepository _albumRepository;
    private readonly IArtistService _artistService;

    public AlbumServiceTests()
    {
        var iMapperMock = new Mapper(new MapperConfiguration(m => m.AddProfile(new AutoMapperConfig())));
        _albumRepository = Substitute.For<IAlbumRepository>();
        _artistService = Substitute.For<IArtistService>();

        _albumService = new AlbumService(
            _albumRepository,
            _artistService,
            iMapperMock
        );
    }

    [Fact]

    public void TestingAlbumServiceCompleted()
    {
        var fakeAlbum = RegisterAlbumFakes.RegisterAlbumDto.Generate();

        _albumRepository.RegisterAlbum(new Album(), new Guid())
            .Returns(arg => new Album());

        var newAlbum = _albumService.RegisterAlbum(fakeAlbum);
        
        Assert.NotNull(newAlbum);
        Assert.True(newAlbum.IsCompleted);
        Assert.IsType<Task<RegisterAlbumDto>>(newAlbum);
        Assert.NotNull(newAlbum.Result);
    }

    [Fact]
    public void TestingIfAlbumNameIsCorrect()
    {
        var fakeAlbum = RegisterAlbumFakes.RegisterAlbumDto.Generate();
        var newAlbum = _albumService.RegisterAlbum(fakeAlbum);
        
        Assert.Equal(fakeAlbum.Name, newAlbum.Result.Name);
    }
    
    [Fact]
    public void TestingIfAlbumYearIsCorrect()
    {
        var fakeAlbum = RegisterAlbumFakes.RegisterAlbumDto.Generate();
        var newAlbum = _albumService.RegisterAlbum(fakeAlbum);
        
        Assert.Equal(fakeAlbum.Year, newAlbum.Result.Year);
    }
    
    [Fact]
    public void TestingIfAlbumArtistIsCorrect()
    {
        var fakeAlbum = RegisterAlbumFakes.RegisterAlbumDto.Generate();
        var newAlbum = _albumService.RegisterAlbum(fakeAlbum);
        
        Assert.Equal(fakeAlbum.ArtistGuid, newAlbum.Result.ArtistGuid);
    }
    
    [Fact]
    public void TestingExceptionWhenAlbumNameIsNull()
    {
        var fakeAlbum = RegisterAlbumFakes.RegisterAlbumDto.Generate();
        fakeAlbum.Name = null;

        var exception = Assert.ThrowsAsync<Exception>(
            () => _albumService.RegisterAlbum(fakeAlbum)
        ).Result;
        
        Assert.NotNull(exception);
    }
    
    [Fact]
    public void TestingExceptionWhenAlbumYearIsInvalid()
    {
        var fakeAlbum = RegisterAlbumFakes.RegisterAlbumDto.Generate();
        fakeAlbum.Year = -1;

        var exception = Assert.ThrowsAsync<Exception>(
            () => _albumService.RegisterAlbum(fakeAlbum)
        ).Result;
        
        Assert.NotNull(exception);
    }
    
    [Fact]
    public void TestingExceptionWhenAlbumArtistGuidIsEmpty()
    {
        var fakeAlbum = RegisterAlbumFakes.RegisterAlbumDto.Generate();
        fakeAlbum.ArtistGuid = Guid.Empty;

        var exception = Assert.ThrowsAsync<Exception>(
            () => _albumService.RegisterAlbum(fakeAlbum)
        ).Result;
        
        Assert.NotNull(exception);
    }

    public void Dispose()
    {
        _albumRepository.ClearSubstitute();
    }
}