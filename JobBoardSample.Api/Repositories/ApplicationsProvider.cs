using JobBoardSample.Shared;
using System.Text.Json;

namespace JobBoardSample.Api.Repositories
{
    public class ApplicationsProvider
    {
        private readonly List<Applications> _listApplications;
        
        //leggo file json
        public ApplicationsProvider()
        {
            string jsonPath = Path.Combine(AppContext.BaseDirectory, "Data", "applications.json");

            if (File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath);
                _listApplications = JsonSerializer.Deserialize<List<Applications>>(json) ?? new List<Applications>();
            }
            else
            {
                _listApplications = new List<Applications>();
            }
        }
    }
}
