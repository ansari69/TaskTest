using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTest.Web.WeatherCitys.Queries.GetApiWeatherCity
{
    public class GetApiWeatherCityQueryValidation
        : AbstractValidator<GetApiWeatherCityQuery>
    {
        public GetApiWeatherCityQueryValidation()
        {
            RuleFor(m => m.CityName)
              .NotNull()
              .NotEmpty();
        }
    }
}
