using Microsoft.AspNetCore.Mvc;

namespace MVC_ThomasMore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
    {
        [HttpGet]
        public string SayHello(string name, string firstName)
        {
            return $"Hello {name}, {firstName}";
        }

        [HttpPost]
        public string AddUser()
        {
            return "User was added";
        }
    }
}
