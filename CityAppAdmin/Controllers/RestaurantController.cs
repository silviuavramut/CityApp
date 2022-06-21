using CityAppAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CityAppAdmin.Controllers
{
    public class RestaurantController : Controller
    {
        string baseURL = "http://192.168.1.208:45455/";
        public IActionResult Restaurants()
        {
            IEnumerable<RestaurantModel> restaurants = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.1.208:45455/api/Restaurant/");
                //HTTP GET
                var responseTask = client.GetAsync("GetRestaurants");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<RestaurantModel>>();
                    readTask.Wait();

                    restaurants = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    restaurants = Enumerable.Empty<RestaurantModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(restaurants);
        }
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.1.208:45455/api/Restaurant/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("DeleteRestaurant?id=" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Restaurants");
                }
            }

            return RedirectToAction("Restaurants");
        }
        public ActionResult Edit(int id)
        {
            RestaurantModel restaurant = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.1.208:45455/api/Restaurant/");
                //HTTP GET
                var responseTask = client.GetAsync("GetRestaurant?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RestaurantModel>();
                    readTask.Wait();

                    restaurant = readTask.Result;
                }
            }

            return View(restaurant);
        }

        [HttpPost]
        public ActionResult Edit(RestaurantModel restaurant)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.1.208:45455/api/Restaurant/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<RestaurantModel>("UpdateRestaurant?id=" + restaurant.Id, restaurant);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Restaurants");
                }
            }
            return View(restaurant);
        }

        public async Task<ActionResult<String>> AddNewRestaurant(RestaurantModel restaurant)
        {
            RestaurantModel obj = new RestaurantModel()
            {
                Name = restaurant.Name,
                Address = restaurant.Address,
                Link = restaurant.Link,
            };
            if (restaurant.Name != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL + "api/Restaurant/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //HTTP POST
                    HttpResponseMessage postData = await client.PostAsJsonAsync<RestaurantModel>("AddRestaurant", obj);


                    if (postData.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Restaurants","Restaurant");
                    }
                    else
                    {
                        Console.WriteLine("error calling web api");
                    }
                }
            }
            return View(restaurant);
        }
    }
}
