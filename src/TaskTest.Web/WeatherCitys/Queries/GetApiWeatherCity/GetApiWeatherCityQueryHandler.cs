using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TaskTest.Web.Entities;

namespace TaskTest.Web.WeatherCitys.Queries.GetApiWeatherCity
{
    public class GetApiWeatherCityQueryHandler
        : IRequestHandler<GetApiWeatherCityQuery, bool>
    {


        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetApiWeatherCityQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<bool> Handle(GetApiWeatherCityQuery request, CancellationToken cancellationToken)
        {

            var apiWeatherCity = new ShowApiWeatherCityVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient
                    .GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={request.CityName}&appid=4e213de7b940263814502467def1e0e8"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    string apiResponse1 = await response.Content.ReadAsStringAsync();
                    apiWeatherCity = JsonConvert.DeserializeObject<ShowApiWeatherCityVM>(apiResponse);

                    
                    if (apiWeatherCity.Wind.Deg > 14)
                    {
                        WeatherCity weatherCity = new WeatherCity();

                        weatherCity.WeatherCityID = Guid.NewGuid().ToString();
                        weatherCity.CityName = apiWeatherCity.Name.ToString();
                        weatherCity.Temperatures = apiWeatherCity.Wind.Deg.ToString();

                        _context.WeatherCitys.Add(weatherCity);

                        await _context.SaveChangesAsync();
                    }

                }
            }



            return true;
        }
    }
}
