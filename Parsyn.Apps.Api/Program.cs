using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Data.Models.Dtos.UIDtos;
using Parsyn.Apps.Company.Data.Models.Entity.Landing;
using Parsyn.Apps.Company.Data.Models.Entity.User;
using Parsyn.Apps.Company.Service.Utiles.Accessor.Auth;
using Parsyn.Apps.Company.Service.Utiles.Middlewares;
using Parsyn.Apps.Company.Services.Interfaces;
using Parsyn.Apps.Company.Services.Interfaces.Base;
using Parsyn.Apps.Company.Services.Interfaces.Bizbaan;
using Parsyn.Apps.Company.Services.Interfaces.Config;
using Parsyn.Apps.Company.Services.Interfaces.Dependencies;
using Parsyn.Apps.Company.Services.Services;
using Parsyn.Apps.Company.Services.Services.Base;
using Parsyn.Apps.Company.Services.Services.Bizbaan;
using Parsyn.Apps.Company.Services.Services.Config;
using Parsyn.Apps.Company.Services.Services.Dependencies;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using Parsyn.Apps.Company.Service.Utiles.Utiles;
using Microsoft.AspNetCore.Builder;
using Parsyn.Apps.Api.Core.Handlers.Exception;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//var connectionString = builder.Configuration.GetConnectionString("PRSNLocalConnection");
var connectionString = builder.Configuration.GetConnectionString("PRSNPublishConnection");
var logger = new LoggerConfiguration()
.WriteTo.MSSqlServer(connectionString, sinkOptions: new MSSqlServerSinkOptions
{
    TableName = "PrsnLogs",
    AutoCreateSqlTable = true
})
.CreateLogger();
builder.Host.UseSerilog(logger);
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddExceptionHandler<ExceptionHandler>();
// Add services to the container.
builder.Services.AddScoped<IUserIface, UserService>();
builder.Services.AddScoped<IMediaIface, MediaService>();
builder.Services.AddScoped<IArticleCatIface, ArticleCatService>();
builder.Services.AddScoped<IArticleIface, ArticleService>();
builder.Services.AddScoped<IFaqCatIface, FaqCatService>();
builder.Services.AddScoped<IFaqIface, FaqService>();
builder.Services.AddScoped<IPageIface, PageService>();

/***********BIZBAAN**************/
builder.Services.AddScoped<IAdCategoryIface, AdCategoryService>();
builder.Services.AddScoped<IAdIface, AdService>();
builder.Services.AddScoped<IAdsImagesIface, AdsIMagesService>();
builder.Services.AddScoped<IZipIface, ZipService>();
builder.Services.AddScoped<ISeoIface, SeoService>();
builder.Services.AddScoped<IRoleIbase, RoleService>();
builder.Services.AddScoped<IPermissionIface, PermissionService>();
builder.Services.AddScoped<IRolePermissionIface, RolePermissionService>();
builder.Services.AddScoped<ISubscribeIface, SubscribeService>();
builder.Services.AddScoped<IOptionIface, OptionService>();
builder.Services.AddScoped<IFormsIface, FormsService>();

builder.Services.AddScoped<IOtpGenerator, OtpGenerator>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ITemplateEngine, TemplateEngine>();
builder.Services.AddScoped<IMediaCatIface, MediaCatService>();
builder.Services.AddDbContext<PDBContext>(options => options.UseSqlServer(connectionString));
//builder.Services.AddDbContext<PDBContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();

// Add custom user service
builder.Services.AddScoped<IUserAccessor, UserAccessor>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddOptions();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddResponseCaching();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseSwagger();
app.UseSwaggerUI();
app.UseResponseCaching();
app.UseMiddleware<AuthMiddleware>(app.Services.GetRequiredService<ILogger<AuthMiddleware>>(), builder.Configuration);
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllers();

app.Run();
