using DependencyInjection.Services;
using DependencyInjection.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DependencyInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly ILogger<OperationController> _logger;
        private readonly IOperationTransient _transientOperation;
        private readonly IOperationSingleton _singletonOperation;
        private readonly IOperationScoped _scopedOperation;


        public OperationController(
            ILogger<OperationController> logger, 
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation)
        {
            _logger = logger;
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;
        }
        
        // Transient objects are always different.The transient OperationId value is different in the IndexModel and in the middleware.
        // Scoped objects are the same for a given request but differ across each new request.
        // Singleton objects are the same for every request.

        [HttpGet]
        [Route("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            _logger.LogInformation("Get operation started");

            string transient = _transientOperation.OperationId;
            string scoped = _scopedOperation.OperationId;
            string singleton = _singletonOperation.OperationId;

            _logger.LogInformation("Get operation ended");

            return Ok(new
            {
                Transient = transient,
                Scoped = scoped,
                Singleton = singleton
            });
        }
    }
}
