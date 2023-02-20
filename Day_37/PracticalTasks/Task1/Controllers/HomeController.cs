using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1.Models;
using Task1.Models.DTO;
using Mapster;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost("[action]")]
        public IActionResult GetText([FromBody] GeorgianLanguageTextModel model)
        {
            return Ok(model.Adapt<GeorgianLanguageTextDTO>());
        }
    }
}
