using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskTest.Web.Account.Commands.Login;

namespace TaskTest.Web.Controllers
{
    [ApiController]
    public class AccountController : ApiController<AccountController>
    {

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="mediator">MediatR</param>
        /// <param name="logger">Logging</param>
        public AccountController(IMediator mediator, ILogger<AccountController> logger)
            : base(mediator, logger)
        { }


        /// <summary>
        /// Login to system by username and password
        /// </summary>
        /// <remarks>Simple login</remarks>
        /// <response code="200">LoginVM</response>
        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand model)
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
