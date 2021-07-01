using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskTest.Web.Users.Command.UpsertUser;

namespace TaskTest.Web.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UsersController :ApiController<UsersController>
    {

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="mediator">MediatR</param>
        /// <param name="logger">Serilog</param>
        public UsersController(IMediator mediator, ILogger<UsersController> logger)
            : base(mediator, logger)
        {
        }


        /// <summary>
        /// Inser or update a user (upsert)
        /// </summary>
        /// <response code="200">UpsertUserVM</response>
        [HttpPost("/users/upsert")]
        [ProducesResponseType(typeof(UpsertUserVM), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostAsync([FromBody] UpserUserCommand model)
        {
            try
            {
                var response = await _mediator.Send(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("");
            }
        }


    }
}
