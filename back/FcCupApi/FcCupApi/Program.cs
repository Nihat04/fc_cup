using FcCupApi.Contexts;
using FcCupApi.Helpers;
using FcCupApi.Services;
using FcCupApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFramework;
using FcCupAp.Services;
using FcCupApi.Profiles;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(UserProfile));

builder.Services.AddControllers();
builder.Services.AddDbContext<FcCupDbContext>(options => 
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"), 
        new MySqlServerVersion(new Version(9, 0, 0))));

builder.Services.AddScoped(typeof(IEfRepository<>), typeof(UserRepository<>));
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization(opt => opt.AddPolicy("default", opt.DefaultPolicy));
builder.Services.AddAuthentication();
builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<UsersDbContext>()
    .AddApiEndpoints();

builder.Services.AddDbContext<UsersDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(9, 0, 0))));



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();

app.UseMiddleware<JwtMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();
app.MapControllers();
app.MapIdentityApi<User>();

app.Run();