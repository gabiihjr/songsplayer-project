using Microsoft.AspNetCore.Mvc;
using SongsPlayer.Application.Interfaces;
using SongsPlayer.Domain.DTOs;

namespace SongsPlayer.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistController : ControllerBase
{
  private readonly IArtistService _artistService;

  public ArtistController(IArtistService artistService)
  {
    _artistService = artistService;
  }

  [HttpPost("[action]", Name = "RegisterArtist")]
  public async Task<ActionResult> RegisterArtist(RegisterArtistDto artist)
  {
    return Ok(await _artistService.RegisterArtist(artist));
  }

  [HttpGet("[action]", Name = "GetArtists")]
  public async Task<ActionResult> GetArtists()
  {
    return Ok(await _artistService.GetArtists());
  }
  
  [HttpGet("[action]/{artistGuid:guid}")]
  public async Task<ActionResult> GetArtistByGuid(Guid artistGuid)
  {
    return Ok(await _artistService.GetArtistByGuid(artistGuid));
  }
}