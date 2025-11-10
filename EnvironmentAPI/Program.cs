using EnvironmentAPI.Filters;
using EnvironmentAPI.Middlewares;
using EnvironmentRepository.Database;
using EnvironmentRepository.Models.BaseModels;
using EnvironmentRepository.Models.Kullanici;
using EnvironmentRepository.Repos;
using EnvironmentRepository.RepoServices;
using EnvironmentRepository.UnitOfWork;
using EnvironmentServices.Helpers;
using EnvironmentServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});
builder.Services.AddMemoryCache();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<EnvironmentDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("EnvironmentDb"), option =>
{
    option.MigrationsAssembly(Assembly.GetAssembly(typeof(EnvironmentDbContext))!.GetName().Name);
}));
builder.Services.AddDbContextFactory<EnvironmentDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("EnvironmentDb")), ServiceLifetime.Scoped);
builder.Services.AddIdentity<Kullanici, Rol>().AddEntityFrameworkStores<EnvironmentDbContext>();
builder.Services.AddScoped<ITokenHandler, JwtTokenHandler>();
builder.Services.AddSingleton<JwtSettings>(sp =>
{
    var _configuration = sp.GetRequiredService<IConfiguration>();
    return new JwtSettings { Key = _configuration["JwtSettings:Key"], Issuer = _configuration["JwtSettings:Issuer"], Duration = Int32.Parse(_configuration["JwtSettings:Duration"]), RefreshDuration = Int32.Parse(_configuration["JwtSettings:RefreshDuration"]) };
});
builder.Services.AddScoped<SiteControlModel>(sp => 
{
    var siteControlModel = new SiteControlModel();
    var user = sp.GetRequiredService<IHttpContextAccessor>().HttpContext.User;
    siteControlModel.IsSuperAdmin = sp.GetRequiredService<IHttpContextAccessor>().HttpContext.User.IsInRole("SuperAdmin");
    siteControlModel.SirketListesi = user.FindFirstValue("Sirket")?.Split(",").ToList().Select(x => Int32.Parse(x)).ToList() ?? new();
    return siteControlModel;
});


//repos
builder.Services.AddTransient<IBaseRepo, BaseRepo>();
builder.Services.AddTransient<ITransaction, Transaction>();
builder.Services.AddTransient<IMusteriRepo, MusteriRepo>();
builder.Services.AddTransient<IKullaniciRepo, KullaniciRepo>();
builder.Services.AddTransient<IVeriListesiRepo, VeriListesiRepo>();
//builder.Services.AddTransient<Dictionary<int, int>>(x => { return new Dictionary<int, int>(); });

//repo services
builder.Services.AddTransient<DynamicDataCacheService>();

//services
builder.Services.AddTransient<BaseService>();
builder.Services.AddTransient<IMusteriService, MusteriService>();
builder.Services.AddTransient<IKullaniciService, KullaniciService>();
builder.Services.AddTransient<IVeriListesiService, VeriListesiService>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
    }).
    AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!)),
            ValidateLifetime = true,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
        };
        options.SaveToken = true;
        options.MapInboundClaims = false;
    });
builder.Services.AddAuthorization();
builder.Services.AddLogging(builder => builder.AddConsole());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.MapOpenApi();
app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseRouting();
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
