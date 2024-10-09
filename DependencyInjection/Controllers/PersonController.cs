using DependencyInjection.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _service;   

        public PersonController(ILogger<PersonController> logger, IPersonService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("greeting")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetPerson([FromBody] GetPersonRequest request)
        {
            _logger.LogInformation("GetPerson requested");


            var dateOfBirth = DateOnly.FromDateTime(request.DateOfBirth);

            var response = _service.GetPerson(request.Name, dateOfBirth);
            if (string.IsNullOrEmpty(response))
            {
                return BadRequest("Nothing returned!");
            }

            return Ok(new GetPersonResponse
            {
                Id = Guid.NewGuid(),
                Message = response,
            });
        }
    }
}
