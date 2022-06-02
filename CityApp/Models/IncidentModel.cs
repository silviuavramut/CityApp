using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Models
{
    public class IncidentModel
    {
        public IncidentModel()
        {
        }

        public IncidentModel(string type, string location, string image, string message)
        {
            Type = type;
            Location = location;
            Image = image;
            Message = message;
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        public string Message { get; set; }
    }
}
