using Autofac;
using Autofac.Extensions.DependencyInjection;
using AvioLine.Domain.Entities;
using AvioLine.Utils;
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
    options.Password.RequiredLength = 3;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;

}).AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "AvioLine";
    options.Cookie.HttpOnly = true;
    options.Cookie.MaxAge = TimeSpan.FromDays(2);
    options.LoginPath = "/Account/Login";
    options.SlidingExpiration = true;

});
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder => { builder.RegisterModule(new AutoFacConfig()); });
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
