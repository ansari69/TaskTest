using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskTest.Web.WeatherCitys.Queries.GetApiWeatherCity;

namespace TaskTest.Web.Controllers
{
    [ApiController]
    public class WeatherCityController : ApiController<WeatherCityController>
    {

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="mediator">MediatR</param>
        /// <param name="logger">Logging</param>
        public WeatherCityController(IMediator mediator, ILogger<WeatherCityController> logger)
            : base(mediator, logger)
        { }

        /// <summary>
        /// Getting  weather city
        /// </summary>
        /// <response code="200">bool</response>    
        [HttpPost("/weather/city")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetApiWeatherCityAsync([FromBody] GetApiWeatherCityQuery model)
        {
            try
            {
                var response = await _mediator.Send(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


    }
}
