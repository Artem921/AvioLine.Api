using Autofac;
using AvioLine.Clients.Services.Abstract;
using AvioLine.Clients.Services.ExchangeRate;
using AvioLine.Clients.Services.Identity;
using AvioLine.Clients.Services.Ticket;
using AvioLine.Clients.WeatherForecast;
using AvioLine.Domain.Entities;
using AvioLine.Domain.Models;
using AvioLine.Interfaces;
using Microsoft.AspNetCore.Identity;



namespace AvioLine.Utils
{
    public class AutoFacConfig: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ExchangeRateClient>().As<IExchangeRateClient>().SingleInstance();
            builder.RegisterType<WeatherForecastClient>().As<IWeatherForecastClient>().SingleInstance();
            builder.RegisterType<TicketClient>().As<ITicketService<TicketViewModel>>().SingleInstance();

            builder.RegisterType<UsersClient>().As<IUserStore<User>>();
            builder.RegisterType<UsersClient>().As<IUserPasswordStore<User>>();
            builder.RegisterType<UsersClient>().As<IUserEmailStore<User>>();
            builder.RegisterType<UsersClient>().As<IUserClaimStore<User>>();
            builder.RegisterType<UsersClient>().As<IUserTwoFactorStore<User>>();
            builder.RegisterType<UsersClient>().As<IUserLoginStore<User>>();

            builder.RegisterType<RolesClient>().As<IRoleStore<Role>>();

        }
    }
}
