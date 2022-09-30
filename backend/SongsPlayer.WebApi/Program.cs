using Microsoft.EntityFrameworkCore;
using SongsPlayer.Application.Interfaces;
using SongsPlayer.Application.Services;
using SongsPlayer.Infra.Data.Context;
using SongsPlayer.Infra.Data.Interface;
using SongsPlayer.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>()
//     .AddEntityFrameworkStores<UsersDbContext>();
// Add services to the container.

builder.Services.AddControllers();

var configuration = builder.Configuration;

builder.Services.AddDbContext<SongsPlayerDbContext>(options =>
{
    options.UseNpgsql(conn => conn.MigrationsAssembly("SongsPlayer.Infra.Data"));
    options.UseNpgsql(configuration.GetConnectionString("SongsPlayerConnection"));
});

builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<ISongService, SongService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
