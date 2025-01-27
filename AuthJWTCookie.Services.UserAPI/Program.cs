using AuthJWTCookie.Services.UserAPI;
using AuthJWTCookie.Services.UserAPI.Cryptography;
using AuthJWTCookie.Services.UserAPI.Cryptography.Interfaces;
using AuthJWTCookie.Services.UserAPI.DbContexts;
using AuthJWTCookie.Services.UserAPI.Interfaces;
using AuthJWTCookie.Services.UserAPI.Interfaces.Implementations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions))); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, IPasswordHasher>();

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

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
