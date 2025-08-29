using JobBoardSample.Shared;
using System.Text.Json;

namespace JobBoardSample.Api.Repositories
{
    public class PositionsProvider
    {
        private readonly List<Position> _listPositions;

        //leggo dati json all'avvio
        public PositionsProvider()
        {
            string jsonPath = Path.Combine(AppContext.BaseDirectory, "Data", "positions.json");

            if (File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath);
                _listPositions = JsonSerializer.Deserialize<List<Position>>(json) ?? new List<Position>();
            }
            else
            {
                _listPositions = new List<Position>();
            }
        }

        public IEnumerable<Position> GetAllPositions() 
        { 
            return _listPositions; 
        }

        public Position? GetPositionById(int id) 
        { 
            return _listPositions.FirstOrDefault(p => p.Id == id);
        }

    }
}
