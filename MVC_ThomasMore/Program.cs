using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MVC_ThomasMore.Data;
using MVC_ThomasMore.Data.Entities;
using MVC_ThomasMore.Data.Repositories;
using MVC_ThomasMore.Helper;
using MVC_ThomasMore.Model;
using MVC_ThomasMore.Services;
using System.Text;

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
builder.Services.AddScoped<IProductService, ProductService>();


// Add automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Use Entity Framework
builder.Services.AddDbContext<WebApiDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDBConnection")));

// Use Identity Framework
builder.Services.AddIdentity<CustomUser, IdentityRole>().
    AddEntityFrameworkStores<WebApiDataContext>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.IncludeErrorDetails = true;
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.UseSecurityTokenValidators = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateLifetime = false,
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Token.MySettings.Secret))
        };
    });


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 6;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(300);
});

// Use JWT Tokens
Token.MySettings = new MySettings
{
    Secret = builder.Configuration["MySettings:Secret"].ToCharArray(),
    ValidIssuer = builder.Configuration["MySettings:ValidIssuer"],
    ValidAudience = builder.Configuration["MySettings:ValidAudience"]
};

builder.Configuration.GetRequiredSection(nameof(MySettings)).Bind(Token.MySettings);

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