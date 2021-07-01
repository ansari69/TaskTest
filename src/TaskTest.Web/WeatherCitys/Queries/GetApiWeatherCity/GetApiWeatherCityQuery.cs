using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTest.Web.WeatherCitys.Queries.GetApiWeatherCity
{
    public class GetApiWeatherCityQuery
        : IRequest<bool>
    {
        public string CityName { get; set; }
    }
}
