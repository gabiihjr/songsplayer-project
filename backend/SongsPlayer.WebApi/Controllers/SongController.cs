using Microsoft.AspNetCore.Mvc;
using SongsPlayer.Application.Interfaces;
using SongsPlayer.Domain.Models;

namespace SongsPlayer.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SongController : ControllerBase
{
    private readonly ISongService _songService;

    public SongController(ISongService songService)
    {
        _songService = songService;
    }
    
    [HttpPost(Name = "RegisterSong")]
    public IActionResult RegisterSong(Song song)
    {
        _songService.RegisterSong(song);
        return Ok();
    }
}