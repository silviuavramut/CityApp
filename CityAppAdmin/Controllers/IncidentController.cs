using CityAppAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CityAppAdmin.Controllers
{
    public class IncidentController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Incidents()
        {
            IEnumerable<IncidentModel> incidents = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.1.208:45455/api/Incident/");
                //HTTP GET
                var responseTask = client.GetAsync("GetIncidents");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<IncidentModel>>();
                    readTask.Wait();

                    incidents = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    incidents = Enumerable.Empty<IncidentModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(incidents);
        }
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.1.208:45455/api/Incident/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("DeleteIncident?id=" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Incidents");
                }
            }

            return RedirectToAction("Incidents");
        }

    }
}
