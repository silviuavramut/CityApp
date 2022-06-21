using CityApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Services
{
    public class IncidentService : IncidentRepository
    {
        public IncidentService()
        {
        }

        public async Task<bool> AddIncidentAsync(IncidentModel incidentInfo)
        {
            if(incidentInfo.Id == 0)
            {

                string json = JsonConvert.SerializeObject(incidentInfo);
                StringContent content = new StringContent(json, Encoding.UTF8,"application/json");

                HttpClient client = new HttpClient();
                string url = "http://192.168.1.208:45455/api/Incident/AddIncident";
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.PostAsync("",content);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
            }
            else
            {
                string json = JsonConvert.SerializeObject(incidentInfo);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                string url = "http://192.168.1.208:45455/api/Incident/UpdateIncident?id=" + incidentInfo.Id ;
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.PutAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }

            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteIncidentAsync(int id)
        {

            HttpClient client = new HttpClient();
            string url = "http://192.168.1.208:45455/api/Incident/DeleteIncident?id=" + id;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.DeleteAsync("");

            if (response.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }
            else
            {
                
                return await Task.FromResult(false);
            }
        }

        public async Task<IncidentModel> GetIncidentAsync(int id)
        {
            var incident = new IncidentModel();
            HttpClient client = new HttpClient();
            string url = "http://192.168.1.208:45455/api/Incident/GetIncident?id=" + id;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");

            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                incident= JsonConvert.DeserializeObject<IncidentModel>(content);
            }
            return await Task.FromResult(incident);
        }

        public async Task<List<IncidentModel>> GetIncidentsAsync()
        {
            var incidentList = new List<IncidentModel>();
            HttpClient client = new HttpClient();
            string url = "http://192.168.1.208:45455/api/Incident/GetIncidents";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");

            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                incidentList = JsonConvert.DeserializeObject<List<IncidentModel>>(content);
            }
            return await Task.FromResult(incidentList);
        }
    }
}
