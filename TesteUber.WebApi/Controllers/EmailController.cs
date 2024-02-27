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

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Funcionou");
        }

        [HttpPost]
        public ActionResult SendEmail(EmailCommand command)
        {
            var result = _mediator.Send(command);

            if(result != null && result.IsCompletedSuccessfully)
            {
                return Ok(result);
            }

            return StatusCode(500, result.Exception);
        }
    }
}