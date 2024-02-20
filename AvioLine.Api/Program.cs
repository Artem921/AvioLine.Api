using AvioLine.Api.Helper;
using AvioLine.Api.Services;
using AvioLine.Api.Services.Abstract;
using AvioLine.Dal;
using AvioLine.Dal.Repositories;
using AvioLine.Data;
using AvioLine.Domain.Entities;
using AvioLine.Interfaces;
using Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AvioLine.Api",
        Version = "v1",
        Description = "Secret_WebAPI",
        Contact = new OpenApiContact
        {
            Name = "Artem Ignatev",
            Email = "ignatgamego@gmail.com",
            Url = new Uri("https://store.steampowered.com/app/1682200/BJORN/"),
        },
    });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                }
            },
            new List < string > ()
        }
    });
});
builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = ConfigurationApplication.AppSetting["JWT:ValidIssuer"],
        ValidAudience = ConfigurationApplication.AppSetting["JWT:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationApplication.AppSetting["JWT:Secret"]))
    };
});
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddTransient<ITicketService, TicketsRepository>();
builder.Services.AddDbContext<ApplicationContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("avioLine")));
builder.Services.AddDbContext<IdentityContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("avioLine")));
builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequiredLength = 4;

})
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<Role>>();
    IdentityInitializer.Initialize(userManager, roleManager);
}
Mapping.CreateMapper();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.Run();
