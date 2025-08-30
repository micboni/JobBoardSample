using Microsoft.AspNetCore.Mvc;
using JobBoardSample.Shared;
using JobBoardSample.Api.Repositories;

namespace JobBoardSample.Api.Controllers
{
    [ApiController]
    //https://localhost:7290/api/application
    [Route("api/[controller]")]
    public class ApplicationsController : Controller
    {

        private readonly ApplicationsProvider _applicationsProvider;
        private readonly PositionsProvider _positionsProvider;


        public ApplicationsController(ApplicationsProvider applicationsProvider, PositionsProvider positionsProvider)
        {
            _applicationsProvider = applicationsProvider;
            _positionsProvider = positionsProvider;
        }

        [HttpPost]
        public IActionResult PostApplication([FromBody] Applications request)
        {
            if (string.IsNullOrWhiteSpace(request.candidateName))
            {
                return BadRequest(new { message = "Nome, email e positionid sono obbligatori" });
            }

            //controllo se la posizione esiste

            //aggiungo nuova candidatura
            return Ok(request);
        }
    }
}
