using Identity.Application.Commands.LoginCommand;
using Identity.Application.Commands.RegisterCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")] 
    [ApiVersion("1.0")]
    public class IdentityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IdentityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok("User registered successfully") : BadRequest("Registration failed");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Success)
                return Ok(response);
            return Unauthorized(response.Message);
        }
    }
}
