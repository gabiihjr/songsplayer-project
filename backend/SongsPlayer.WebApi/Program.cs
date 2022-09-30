using Microsoft.AspNetCore.Identity;
using SongsPlayer.Application.Interfaces;
using SongsPlayer.Application.Services;
using SongsPlayer.Infra.Data.Context;

var builder = WebApplication.CreateBuilder(args);


// builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>()
//     .AddEntityFrameworkStores<UsersDbContext>();
// Add services to the container.

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ISongService, SongService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
