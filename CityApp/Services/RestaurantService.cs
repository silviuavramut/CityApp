using CityApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Services
{
    public class RestaurantService : RestaurantRepository
    {
        public async Task<bool> AddRestaurantAsync(RestaurantModel restaurantInfo)
        {
            if (restaurantInfo.Id == 0)
            {

                string json = JsonConvert.SerializeObject(restaurantInfo);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                string url = "http://192.168.1.208:45455/api/Restaurant/AddRestaurant";
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
            }
            else
            {
                string json = JsonConvert.SerializeObject(restaurantInfo);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                string url = "http://192.168.1.208:45455/api/Restaurant/UpdateRestaurant?id=" + restaurantInfo.Id;
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.PutAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }

            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteRestaurantAsync(int id)
        {
            HttpClient client = new HttpClient();
            string url = "http://192.168.1.208:45455/api/Restaurant/DeleteRestaurant?id=" + id;
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

        public async Task<RestaurantModel> GetRestaurantAsync(int id)
        {
            var restaurant = new RestaurantModel();
            HttpClient client = new HttpClient();
            string url = "http://192.168.1.208:45455/api/Restaurant/GetRestaurant?id=" + id;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");

            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                restaurant = JsonConvert.DeserializeObject<RestaurantModel>(content);
            }
            return await Task.FromResult(restaurant);
        }

        public async Task<List<RestaurantModel>> GetRestaurantAsync()
        {
            var restaurantList = new List<RestaurantModel>();
            HttpClient client = new HttpClient();
            string url = "http://192.168.1.208:45455/api/Restaurant/GetRestaurants";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");

            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                restaurantList = JsonConvert.DeserializeObject<List<RestaurantModel>>(content);
            }
            return await Task.FromResult(restaurantList);
        }
    }
}
