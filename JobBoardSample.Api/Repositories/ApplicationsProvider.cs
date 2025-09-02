using JobBoardSample.Shared;
using System.Text.Json;
using System.Xml.Linq;

namespace JobBoardSample.Api.Repositories
{
    public class ApplicationsProvider
    {
        private readonly List<Applications> _listApplications;
        private readonly string _jsonPath;

        //leggo file json
        public ApplicationsProvider()
        {
            _jsonPath = Path.Combine(AppContext.BaseDirectory, "Data", "applications.json");

            if (File.Exists(_jsonPath))
            {
                string json = File.ReadAllText(_jsonPath);
                _listApplications = JsonSerializer.Deserialize<List<Applications>>(json) ?? new List<Applications>();
            }
            else
            {
                _listApplications = new List<Applications>();
            }
        }

        //for admin
        public List<Applications> GetAll()
        {
            return _listApplications;
        }

        //Aggiungo la candidatura alla lista in memoria e la salvo nel file JSON
        public Applications Add(Applications application)
        {
            application.Id =_listApplications.Any() ? _listApplications.Max(a => a.Id) + 1: 1;
            
            _listApplications.Add(application);
            Save();

            return application;
        }

        //Serializzo lista in JSON e sovrascrivo il file applications.json
        public void Save()
        {
            string json = JsonSerializer.Serialize(_listApplications );
            File.WriteAllText(_jsonPath, json);
        }
    }
}
