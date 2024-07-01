using FcCupApi.Contexts;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFramework;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<FcCupDbContext>(options => 
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"), 
        new MySqlServerVersion(new Version(9, 0, 0))));

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




