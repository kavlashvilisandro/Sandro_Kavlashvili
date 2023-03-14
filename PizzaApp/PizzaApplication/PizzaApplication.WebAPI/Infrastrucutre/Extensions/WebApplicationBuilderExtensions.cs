using Domain.Logger;
using FluentValidation;
using PizzaApplication.WebAPI.Infrastrucutre.Validations;
using PizzaApplication.WebAPI.Infrastrucutre.Models;
using Application.Models;
using Application.Models.Pizza;

namespace PizzaApplication.WebAPI.Infrastrucutre.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void LogInformation(this WebApplicationBuilder builder,string info)
        {
            Domain.Logger.ILogger logger = Logger.GetLogger();
            logger.LogInformation(info, builder.Configuration.GetValue<string>("DomainConfigurationPath"));
        }

        public static void LogError(this WebApplicationBuilder builder, string error)
        {
            Domain.Logger.ILogger logger = Logger.GetLogger();
            logger.LogErrors(error, builder.Configuration.GetValue<string>("DomainConfigurationPath"));
        }

        public static async Task LogInformationAsync(this WebApplicationBuilder builder, string info)
        {
            Domain.Logger.ILogger logger = Logger.GetLogger();
            await logger.LogInformationAsync(info, builder.Configuration.GetValue<string>("DomainConfigurationPath"));
        }

        public static async Task LogErrorAsync(this WebApplicationBuilder builder, string error)
        {
            Domain.Logger.ILogger logger = Logger.GetLogger();
            await logger.LogErrorsAsync(error, builder.Configuration.GetValue<string>("DomainConfigurationPath"));
        }

        public static void AddServicesIntoDIContainer(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IValidator<PizzaModel>, PizzaValidation>();
            builder.Services.AddScoped<IValidator<AddressModel>, AddressValidation>();
            builder.Services.AddScoped<IValidator<UserModel>, UserValidation>();
            builder.Services.AddScoped<IValidator<OrderModel>, OrderValidator>();
            builder.Services.AddSingleton<IUserServices, UserServices>();
            builder.Services.AddSingleton<IPizzaServices, PizzaServices>();
        }



    }
}
