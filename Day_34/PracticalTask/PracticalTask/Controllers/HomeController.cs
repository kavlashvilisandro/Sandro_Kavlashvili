using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticalTask.MiddleWares;

namespace PracticalTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public void Test(int number)
        {
            try
            {
                if(number > 10)
                {
                    throw new Exception(number + "");
                }
            }catch (Exception ex)
            {
UnHandledExceptionHandlerMiddleWare.exceptions.Add(ex, DateTime.Now);
            }
        }
    }
}
