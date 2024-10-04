using Microsoft.EntityFrameworkCore;
using MVC_ThomasMore.Data;
using MVC_ThomasMore.Data.Repositories;

// In deze klasse komt alle configuratie van de app
// Zaken zoals registren van dependencies (database, services, automapper...) doen we hier

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services here -> Dependency Injection
builder.Services.AddScoped<IProductRepo, ProductRepository>();


// Add automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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