using BackEndBase.Application.Concretes;
using BackEndBase.Application.Interfaces;
using BackEndBase.DataAccess.Context;
using BackEndBase.DataAccess.Repositories;
using BackEndBase.Domain.Bus;
using BackEndBase.Domain.CommandHandlers;
using BackEndBase.Domain.Commands;
using BackEndBase.Domain.Events;
using BackEndBase.Domain.Interfaces.Data;
using BackEndBase.Domain.Interfaces.Notifications;
using BackEndBase.Domain.Interfaces.Services;
using BackEndBase.Domain.Notifications;
using BackEndBase.Domain.Services;
using BackEndBase.Infra.CrossCutting.Bus;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BackEndBase.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            service.AddScoped<BaseContext>();

            //Application
            service.AddScoped<IUserApplication, UserApplication>();

            //Service
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<ITokenService, TokenService>();

            //Events
            service.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //CommandHandler
            service.AddScoped<IHandler<AddUserCommand>, UserCommandHandler>();

            //Bus
            service.AddScoped<IBus, InMemoryBus>();

            //Repository
            service.AddScoped<IUserRepository, UserRepository>();
        }
    }
}