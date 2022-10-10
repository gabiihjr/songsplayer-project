using Microsoft.AspNetCore.Mvc;
using SongsPlayer.Application.Interfaces;
using SongsPlayer.Domain.DTOs;

namespace SongsPlayer.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumController : ControllerBase
{
    private readonly IAlbumService _albumService;

    public AlbumController(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    [HttpPost("[action]", Name = "RegisterAlbum")]
    public async Task<ActionResult> RegisterAlbum(RegisterAlbumDto album)
    {
        return Ok(await _albumService.RegisterAlbum(album));
    }
}