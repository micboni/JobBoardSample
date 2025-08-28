using JobBoardSample.Shared;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardSample.Api.Controllers
{
    [ApiController]
    //https://localhost:7290/api/positions
    [Route("api/[controller]")]
    public class PositionsController : ControllerBase
    {
        //TEMPORANEO PER TEST
        private readonly List<Position> _positions = new()
        {
            new Position { Id = 1, Title = "Backend Developer", Department = "Engineering", Location = "Milano" },
            new Position { Id = 2, Title = "Frontend Developer", Department = "Engineering", Location = "Roma" }
        };


        //https://localhost:7290/api/positions
        [HttpGet]
        public ActionResult<IEnumerable<Position>> GetPosition(
            [FromQuery] string? search, [FromQuery] string? department, 
            [FromQuery] string? location, [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 10)
        {
            //filtri
            return Ok(new List<Position>());

        }

        //https://localhost:7290/api/positions/1
        [HttpGet("{id}")]
        public ActionResult<Position> GetPositionById(int id)
        {
            foreach (Position position in _positions)
            {
                if (position.Id == id)
                {
                    return Ok(position);
                }
            }
            return NotFound();
        }

    }
}
