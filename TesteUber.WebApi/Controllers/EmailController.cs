using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteUber.Application.EmailServices.Commands;

namespace TesteUber.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class EmailController : Controller
    {
        private readonly IMediator _mediator;

        public EmailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> SendEmail(EmailCommand command)
        {
            var result = await _mediator.Send(command);

            if(result == System.Net.HttpStatusCode.OK)
            {
                return Ok(result);
            }

            return StatusCode(((int)result));
        }
    }
}