using Application.Models;
using Application.Models.Pizza;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;


namespace PizzaApplication.WebAPI.Infrastrucutre.Abstractions
{
    public abstract class BaseController : ControllerBase
    {
        public static IServiceProvider ServiceProvider { get; set; }
        protected IUserServices UserServices;
        protected IPizzaServices PizzaServices;
        public BaseController()
        {
            UserServices = ServiceProvider.GetRequiredService<IUserServices>();
            PizzaServices = ServiceProvider.GetRequiredService<IPizzaServices>();

        }
    }
}
