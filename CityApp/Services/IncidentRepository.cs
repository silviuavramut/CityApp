using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityApp.Models;

namespace CityApp.Services
{
    public interface IncidentRepository
    {
        Task<bool> AddIncidentAsync(IncidentModel incidentInfo);
        Task<bool> DeleteIncidentAsync(int id);
        Task<IncidentModel> GetIncidentAsync(int id);

        Task<List<IncidentModel>> GetIncidentsAsync();
    }
}
