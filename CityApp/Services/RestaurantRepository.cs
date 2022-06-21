using CityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Services
{
    public interface RestaurantRepository
    {
        Task<bool> AddRestaurantAsync(RestaurantModel restaurantInfo);
        Task<bool> DeleteRestaurantAsync(int id);
        Task<RestaurantModel> GetRestaurantAsync(int id);

        Task<List<RestaurantModel>> GetRestaurantAsync();
    }
}
