using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_ThomasMore.Data;
using MVC_ThomasMore.Data.Entities;
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

// Use Identity Framework
builder.Services.AddIdentity<CustomUser, IdentityRole>().
    AddEntityFrameworkStores<WebApiDataContext>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Events.OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = 401; // Unauthorized
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync("Error: Niet gauthenticeerd");
        };
    });

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 6;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(300);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();