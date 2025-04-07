using BlazorDB;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using FisSst.BlazorMaps.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using Parysn.Apps.Admin;
using Parysn.Apps.Admin.UIServices;
using Parysn.Apps.Admin.UIServices.Auth;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.Services.AddMudServices(config =>
        {

            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

            config.SnackbarConfiguration.PreventDuplicates = false;
            config.SnackbarConfiguration.NewestOnTop = true;
            config.SnackbarConfiguration.ShowCloseIcon = true;
            config.SnackbarConfiguration.VisibleStateDuration = 10000;
            config.SnackbarConfiguration.HideTransitionDuration = 500;
            config.SnackbarConfiguration.ShowTransitionDuration = 500;
            config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
        });
        MudGlobal.UnhandledExceptionHandler = (exception) => Console.WriteLine(exception);
        builder.Services.AddAuthorizationCore();
        builder.Services.AddScoped<IBlazorDbFactory, BlazorDbFactory>();
        builder.Services.AddScoped<InMemeoryStorage>();
        builder.Services.AddScoped<IUserObject, UserObject>();
        builder.Services.AddScoped<HttpClient>(sp => new HttpClient { BaseAddress = new Uri(UIHelper.BaseUrl) });
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");
        builder.Services.AddBlazorDB(options =>
        {
            options.Name = "BizbaanDB";
            options.Version = 1;
            options.StoreSchemas =
    [
        new()
        {
            Name = "Bizbaan",
            PrimaryKey = "id",
            PrimaryKeyAuto = true,
            UniqueIndexes = ["Key"],

        }
    ];
        });
        ConfigureServices(builder.Services, builder.HostEnvironment.BaseAddress);
        builder.Services.AddBlazoredLocalStorage();
        await builder.Build().RunAsync();
    }
    private static void ConfigureServices(IServiceCollection services, string baseAddress)
    {
        services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });





    }

}