using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SongsPlayer.Domain.Models;
using SongsPlayer.Infra.Data.Configurations;

namespace SongsPlayer.Infra.Data.Context;

public class UsersDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
{
    protected readonly IConfiguration Configuration;
    
    public UsersDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(Configuration.GetConnectionString("UsersConnection"));
    }

}

