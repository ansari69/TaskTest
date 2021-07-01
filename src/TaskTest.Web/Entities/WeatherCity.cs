using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTest.Web.Entities
{
    public class WeatherCity
    {
        public WeatherCity()
        {
        }

        public string WeatherCityID { get; set; }
        public string CityName { get; set; }
        public string Temperatures { get; set; }

    }
}
