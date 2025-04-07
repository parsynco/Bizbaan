using Microsoft.EntityFrameworkCore;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Service.Utiles.Bridges.ZipCodePerRadius;
using Parsyn.Apps.Company.Services.Interfaces;
using Parsyn.Apps.Company.Services.Interfaces.Bizbaan;
using Parsyn.Apps.Company.Services.Interfaces.Config;
using Parsyn.Apps.Company.Services.Interfaces.Dependencies;
using Parsyn.Apps.Company.Services.Services;
using Parsyn.Apps.Company.Services.Services.Bizbaan;
using Parsyn.Apps.Company.Services.Services.Config;
using Parsyn.Apps.Company.Services.Services.Dependencies;
using Parsyn.Apps.Web.Middleware;
using Serilog;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);
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
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PDBContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IUserIface, UserService>();
builder.Services.AddScoped<IMediaIface, MediaService>();
builder.Services.AddScoped<ISeoIface, SeoService>();
builder.Services.AddScoped<IArticleCatIface, ArticleCatService>();
builder.Services.AddScoped<IArticleIface, ArticleService>();
builder.Services.AddScoped<IFaqCatIface, FaqCatService>();
builder.Services.AddScoped<IFaqIface, FaqService>();
builder.Services.AddScoped<IPageIface, PageService>();
builder.Services.AddScoped<IFormsIface, FormsService>();


builder.Services.AddScoped<IAdCategoryIface, AdCategoryService>();
builder.Services.AddScoped<IAdIface, AdService>();
builder.Services.AddScoped<IAdsImagesIface, AdsIMagesService>();
builder.Services.AddScoped<IZipIface, ZipService>();
builder.Services.AddScoped<ISubscribeIface, SubscribeService>();
builder.Services.AddScoped<IOptionIface, OptionService>();
builder.Services.AddScoped<IOtpGenerator, OtpGenerator>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ITemplateEngine, TemplateEngine>();
builder.Services.AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        options.ViewLocationFormats.Add("/{0}.cshtml");
    });

/****/
builder.Services.AddScoped<IZipRadiusService, ZipRadiusService>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseMiddleware<BasicAuthMiddleware>();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
