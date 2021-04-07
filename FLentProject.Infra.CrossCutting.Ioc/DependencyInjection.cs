using CoreProject.Core.Interfaces.Apis;
using CoreProject.Core.Interfaces.Validations;
using FLentProject.Application.FriendService;
using FLentProject.Application.GameService;
using FLentProject.Application.LendService;
using FLentProject.Application.UserService;
using FLentProject.Domain.Friends.FriendInterfaces.Repositories;
using FLentProject.Domain.Friends.FriendInterfaces.Services;
using FLentProject.Domain.Friends.FriendInterfaces.Validations;
using FLentProject.Domain.Friends.FriendValidations;
using FLentProject.Domain.Games.GameInterfaces.Repositories;
using FLentProject.Domain.Games.GameInterfaces.Services;
using FLentProject.Domain.Games.GameInterfaces.Validations;
using FLentProject.Domain.Games.GamesValidations;
using FLentProject.Domain.Lends.LendInterfaces.Repositories;
using FLentProject.Domain.Lends.LendInterfaces.Services;
using FLentProject.Domain.Lends.LendInterfaces.Validations;
using FLentProject.Domain.Lends.LendValidations;
using FLentProject.Domain.Users.UserInterfaces.Repositories;
using FLentProject.Domain.Users.UserInterfaces.Services;
using FLentProject.Domain.Users.UserInterfaces.Validations;
using FLentProject.Domain.Users.UserValidations;
using FLentProject.Infra.CrossCutting.Environment;
using FLentProject.Infra.CrossCutting.Notification;
using FLentProject.Infra.Data.RavenDb;
using FLentProject.Infra.Data.RavenDb.Interfaces;
using FLentProject.Infra.Data.Repositories.FriendRepository;
using FLentProject.Infra.Data.Repositories.GameRepository;
using FLentProject.Infra.Data.Repositories.LendRepository;
using FLentProject.Infra.Data.Repositories.UserRepository;
using FLentProject.Infra.Data.UnitOfWork;
using FLentProject.Infra.Data.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FLentProject.Infra.CrossCutting.Ioc
{
    public static class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //=========================================
            //============= SYSTEM INJECT =============
            //=========================================

            //ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //Hosting Enviroment dependency
            services.AddSingleton<IHostingEnvironmentHolder, HostingEnvironmentHolder>();
            //Notifications dependency
            services.AddScoped<IValidationNotification, ValidationNotification>();
            //UnitOfWork context dependency
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //RAVENDB context dependency
            services.AddSingleton<IDocumentStoreHolder, DocumentStoreHolder>();
            //Security context dependency
            //services.AddScoped<IAccountService, AccountService>();
            //services.AddScoped<IJwtHandler, JwtHandler>();
            //services.AddScoped<IFacebookService, FacebookService>();

            services.AddScoped<IGameValidation, GameValidation>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGameService, GameService>();
            
            services.AddScoped<IFriendValidation, FriendValidation>();
            services.AddScoped<IFriendRepository, FriendRepository>();
            services.AddScoped<IFriendService, FriendService>();
            
            services.AddScoped<ILendValidation, LendValidation>();
            services.AddScoped<ILendRepository, LendRepository>();
            services.AddScoped<ILendService, LendService>();
            
            services.AddScoped<IUserValidation, UserValidation>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
