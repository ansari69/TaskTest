using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TaskTest.Web.Controllers
{
    [ApiController]
    public abstract class ApiController<TEntity> : ControllerBase
    {

        /// <summary>
        /// MediatR design pattern
        /// </summary>
        protected readonly IMediator _mediator;

        /// <summary>
        /// ILogger using Serilog
        /// </summary>
        protected readonly ILogger<TEntity> _logger;

        /// <summary>
        /// Base dependency injection for parent
        /// </summary>
        /// <param name="mediator">MediatR</param>
        /// <param name="logger">Logging(Serilog)</param>
        protected ApiController(IMediator mediator, ILogger<TEntity> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


    }
}
