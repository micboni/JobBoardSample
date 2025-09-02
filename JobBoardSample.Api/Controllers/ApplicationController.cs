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
            //controllo campi obbligatori
            if (request == null || request.PositionId <= 0 ||
                string.IsNullOrWhiteSpace(request.CandidateName) ||
                string.IsNullOrWhiteSpace(request.Email))
            {
                return BadRequest(new { message = "PositionId, CandidateName ed Email sono obbligatori" });
            }

            //controllo se la posizione esiste
            var position = _positionsProvider.GetPositionById(request.PositionId);

            if (position == null) 
            {
                return NotFound(new {message = $"La posizione con id {request.PositionId} non esiste" });
            }

            //aggiungo la candidatura al provider 
            _applicationsProvider.Add(request);


            //restitituisco 201 Created
            return CreatedAtAction(nameof(PostApplication), new { id = request.PositionId }, request);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allApplications = _applicationsProvider.GetAll();
            return Ok(allApplications);
        }
    }
}
