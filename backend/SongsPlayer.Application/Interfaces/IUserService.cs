using SongsPlayer.Domain.Models;

namespace SongsPlayer.Application.Interfaces;

public interface IUserService
{
    Task CreateUser();
}