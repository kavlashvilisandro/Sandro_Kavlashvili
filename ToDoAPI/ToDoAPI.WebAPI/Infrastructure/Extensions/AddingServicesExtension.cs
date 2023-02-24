using ToDoAPI.Application.Services.Context;
using ToDoAPI.Application.Services;
using ToDoAPI.WebAPI.Infrastructure.Validation;
using ToDoAPI.WebAPI.Infrastructure.Models;
using FluentValidation;
using ToDoAPI.WebAPI.Logs;

namespace ToDoAPI.WebAPI.Infrastructure.Extensions
{
    public static class AddingServicesExtension
    {
        public static void AddServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddContextService(configuration.GetValue<string>("ConnectionStrings:defaultConnectionString"));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IValidator<UserDTO>, UserDTOValidator>();
            services.AddScoped<IValidator<UserDTOWithoutID>, RegisterUserDTOValidator>();
            services.AddScoped<IValidator<ToDoRegisterDTO>, ToDoValidation>();
            services.AddScoped<IToDoService, ToDoService>();
            services.AddScoped<ISubTaskService, SubTaskService>();
            services.AddSingleton<ILogService, LogService>();
        }
    }
}
