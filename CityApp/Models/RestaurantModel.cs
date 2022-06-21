using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Models
{
    public class RestaurantModel
    {
        public RestaurantModel()
        {
        }

        public RestaurantModel(string name, string address, string link)
        {
            Name = name;
            Address = address;
            Link = link;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Link { get; set; }

    }
}
