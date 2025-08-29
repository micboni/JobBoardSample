using Microsoft.AspNetCore.Mvc;
using JobBoardSample.Shared;

namespace JobBoardSample.Api.Controllers
{
    [ApiController]
    //https://localhost:7290/api/application
    [Route("api/[controller]")]
    public class ApplicationsController : Controller
    {

        [HttpPost]
        public IActionResult PostApplication([FromBody] Applications application)
        {
            return View();
        }
    }
}
