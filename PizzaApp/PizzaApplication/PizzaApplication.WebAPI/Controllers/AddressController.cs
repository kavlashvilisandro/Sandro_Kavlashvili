using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApplication.WebAPI.Infrastrucutre.Abstractions;

namespace PizzaApplication.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : BaseController
    {


        //TODO დასამთავრებელი
        [HttpGet]
        public async Task<IActionResult> AddAddress()
        {
            return Ok();
        }
    }
}
