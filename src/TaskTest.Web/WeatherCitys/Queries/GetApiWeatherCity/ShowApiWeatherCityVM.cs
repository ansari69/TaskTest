using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTest.Web.WeatherCitys.Queries.GetApiWeatherCity
{
    public class ShowApiWeatherCityVM
    {
        public string Name { get; set; }
        public int Cod { get; set; }
        public WindVM Wind { get; set; }

    }



    public class WindVM
    {

        public double Speed { get; set; }

        public int Deg { get; set; }

        

    }

}
