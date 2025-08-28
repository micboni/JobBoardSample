using Microsoft.AspNetCore.Mvc;

namespace JobBoardSample.Api.Controllers
{
    public class ApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
