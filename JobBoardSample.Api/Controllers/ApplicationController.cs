using Microsoft.AspNetCore.Mvc;
using JobBoardSample.Shared;
using JobBoardSample.Api.Repositories;
using System.Data;
using JobBoardSample.Shared.DTO;

namespace JobBoardSample.Api.Controllers
{
    [ApiController]
    //https://localhost:7290/api/application
    [Route("api/[controller]")]
    public class ApplicationsController : Controller
    {

        private readonly ApplicationsProvider _applicationsProvider;
        private readonly PositionsProvider _positionsProvider;
        private readonly string _adminApiKey;

        public ApplicationsController(ApplicationsProvider applicationsProvider, PositionsProvider positionsProvider, IConfiguration config)
        {
            _applicationsProvider = applicationsProvider;
            _positionsProvider = positionsProvider;
            _adminApiKey = config["AdminApiKey"];
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


        #region Admin

        //elencare le candidature per una posizione
        [HttpGet("by-position/{positionId}")]
        public ActionResult<IEnumerable<Applications>> GetByPosition(int positionId)
        {

            if (!Request.Headers.TryGetValue("X-Api-Key", out var apiKey) || apiKey != _adminApiKey)
            {
                return Unauthorized(new { message = "API Key non valida o assente" });
            }

            var app = _applicationsProvider.GetApplicationsByPosition(positionId);
            return Ok(app);
        }



        [HttpPatch("{applicationId}/status")]
        public IActionResult UpdateApplicationsStatus(int applicationId, [FromBody] UpdateStatusRequest request)
        {
            if (!Request.Headers.TryGetValue("X-Api-Key", out var apiKey) || apiKey != _adminApiKey)
            {
                return Unauthorized(new { message = "API Key non valida o assente" });
            }

            if (request.Status != "pending" && request.Status != "rejected" && request.Status != "highlighted")
            {
                return BadRequest();
            }

            var app = _applicationsProvider.UpdateStatus(applicationId, request.Status);

            if(app == null)
            {
                return NotFound();
            }

            return Ok(app);
        }

        #endregion

    }
}
