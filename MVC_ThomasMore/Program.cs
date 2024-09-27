using Microsoft.EntityFrameworkCore;
using MVC_ThomasMore.Data;
using MVC_ThomasMore.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services here
builder.Services.AddScoped<IProductRepo, ProductRepository>();

// Use Entity Framework
builder.Services.AddDbContext<WebApiDataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDBConnection")));

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
