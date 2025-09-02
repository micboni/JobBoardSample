using JobBoardSample.Shared;
using Microsoft.AspNetCore.Mvc;
using JobBoardSample.Api.Repositories;
using JobBoardSample.Shared.DTO;

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


            if (!string.IsNullOrEmpty(search))
            {
                positions = positions.Where(p =>
                    p.Title.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(department))
            {
                positions = positions.Where(p =>
                    p.Department.Equals(department, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(location))
            {
                positions = positions.Where(p =>
                    p.Location.Equals(location, StringComparison.OrdinalIgnoreCase));
            }

            var total = positions.Count();

            var items = positions
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

            var response = new PositionsResponse
            {
                Items = items,
                Total = total,
                Page = page,
                PageSize = pageSize
            };

            return Ok(response); //retrun object position response
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
