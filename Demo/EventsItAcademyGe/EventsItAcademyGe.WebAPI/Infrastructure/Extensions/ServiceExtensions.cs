using EventsItAcademyGe.WebAPI.Infrastructure.Validations;
using EventsItAcademyGe.WebAPI.Infrastructure.Models;
using FluentValidation;
using EventsItAcademyGe.Application;
using EventsItAcademyGe.Application.Services;

namespace EventsItAcademyGe.WebAPI.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services, Serilog.ILogger logger, IConfiguration config)
        {
            //logger
            services.AddSingleton<Serilog.ILogger>((IServiceProvider provider) =>
            {
                return logger;
            });


            //validations
            services.AddScoped<IValidator<UserLoginRegistrationDTO>, UserLoginRegistrationDTOValidation>();
            services.AddScoped<IValidator<EventDTO>, EventDTOValidation>();
            services.AddScoped<IValidator<List<EventDTO>>,EventDTOsValidation>();



            //DbContext
            services.AddDbContexts(config.GetValue<string>("SqlConnectionStrings:DefaultConnectionString"));


            //Services(Application)
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEventService, EventService>();
        }
    }
}
