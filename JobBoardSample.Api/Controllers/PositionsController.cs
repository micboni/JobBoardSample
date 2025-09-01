using JobBoardSample.Shared;
using Microsoft.AspNetCore.Mvc;
using JobBoardSample.Api.Repositories;

namespace JobBoardSample.Api.Controllers
{
    [ApiController]
    //https://localhost:7290/api/positions
    [Route("api/[controller]")]
    public class PositionsController : ControllerBase
    {
        private readonly PositionsProvider _repository;

        public PositionsController()
        {
            _repository = new PositionsProvider();
        }

        //https://localhost:7290/api/positions
        [HttpGet]
        public ActionResult<IEnumerable<Position>> GetPosition(
            [FromQuery] string? search, [FromQuery] string? department, 
            [FromQuery] string? location, [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 12)
        {
            var positions = _repository.GetAllPositions();

            var total = positions.Count();
            var items = positions.Skip((page - 1) * pageSize).Take(pageSize);


            return Ok(new {items, total, page, pageSize});

        }

        //https://localhost:7290/api/positions/1
        [HttpGet("{id}")]
        public ActionResult<Position> GetPositionById(int id)
        {

            var position = _repository.GetPositionById(id);

            if (position == null)
            {
                return NotFound();
            }

            return Ok(position);
        }

    }
}
