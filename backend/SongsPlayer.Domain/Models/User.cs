using SongsPlayer.Infra.Data.Context.Entities;

namespace SongsPlayer.Domain.Models;

public class User : Entity
{
    public string Name { get; set; }
    
    public string Username { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
}