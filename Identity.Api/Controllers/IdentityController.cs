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
        private readonly ILogger<IdentityController> _logger;

        public IdentityController(IMediator mediator, ILogger<IdentityController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            _logger.LogInformation("Processing registration for email: {Email}", command.Email);
            var result = await _mediator.Send(command);
            if (result)
            {
                _logger.LogInformation("User registered successfully: {Email}", command.Email);
                return Ok("User registered successfully");
            }
            _logger.LogWarning("User registration failed for {Email}", command.Email);
            return  BadRequest("Registration failed");
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
