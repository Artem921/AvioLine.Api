using AvioLine.Clients.Services.Abstract;
using AvioLine.Clients.Services.ExchangeRate;
using AvioLine.Clients.Services.Identity;
using AvioLine.Clients.Services.Ticket;
using AvioLine.Clients.WeatherForecast;
using AvioLine.Domain.Entities;
using AvioLine.Domain.Models;
using AvioLine.Interfaces;
using Mappers;
using Microsoft.AspNetCore.Identity;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Logging.ClearProviders();
builder.WebHost.UseNLog();
builder.Services.AddLogging(log =>
{   
    log.AddNLog("nlog.config")
    .AddConsole()
    .AddFilter("Microsoft",LogLevel.Information);

});
builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequiredLength = 4;

}).AddDefaultTokenProviders();





builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "AvioLine";
    options.Cookie.HttpOnly = true;
    options.Cookie.MaxAge = TimeSpan.FromDays(2);
    options.LoginPath = "/Account/Login";
    options.SlidingExpiration = true;

});

#region WebApi Identity clients

builder.Services.AddTransient<IUserStore<User>, UsersClient>()
    .AddTransient<IUserPasswordStore<User>,UsersClient>()
    .AddTransient<IUserEmailStore<User>,UsersClient>()
    .AddTransient<IUserClaimStore<User>,UsersClient>()
     .AddTransient<IUserTwoFactorStore<User>, UsersClient>()
     .AddTransient<IUserLoginStore<User>, UsersClient>();

builder.Services.AddTransient<IRoleStore<Role>, RolesClient>();
#endregion

builder.Services.AddSingleton<IWeatherForecastClient,WeatherForecastClient>();
builder.Services.AddSingleton<IExchangeRateClient, ExchangeRateClient>();
builder.Services.AddSingleton<ITicketService<TicketViewModel>, TicketClient>();
Mapping.CreateMapper();



var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Admin",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
        );
});






app.Run();
