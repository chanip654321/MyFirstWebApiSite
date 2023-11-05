using Repositories;
using Services;
using Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();

builder.Services.AddControllers();

builder.Services.AddDbContext<Store214358897Context>(option => option.UseSqlServer
("Server=srv2\\pupils;Database=Store_214358897;Trusted_Connection=True;TrustServerCertificate=True"));

var app = builder.Build();



// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
