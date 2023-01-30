using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApplication.WebAPI.Infrastrucutre.Abstractions;
using PizzaApplication.WebAPI.Infrastrucutre.Models;
using Mapster;
using Application.Models;
using Application.Models.Pizza;
using PizzaApplication.WebAPI.Infrastrucutre.Models.DTO;
using FluentValidation;

namespace PizzaApplication.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> AddNewPizza([FromBody]PizzaModel pizza , [FromServices] IValidator<PizzaModel> validator)
        {
            FluentValidation.Results.ValidationResult res = validator.Validate(pizza);
            if (!res.IsValid)
            {
                return BadRequest(res.Errors);
            }
            return Ok(await PizzaServices.AddPizza(pizza.Adapt<PizzaRequestModel>()));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPizza(int id)
        {
            IPizzaResponseModel res = await PizzaServices.GetPizza(id);
            if(res == null)
            {
                return BadRequest("There is not pizza with this id");
            }
            else
            {
                return Ok(new PizzaDTO()
                {
                    Name = res.GetName(),
                    Description = res.GetDescription(),
                    Price = res.GetPrice(),
                    CaloryCount = res.GetCaloryCount(),
                    PizzaID = res.GetID(),
                });
            }
        }
    }
}
