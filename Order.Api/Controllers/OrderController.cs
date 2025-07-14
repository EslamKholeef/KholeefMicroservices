using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Commands.CreateCommand;

namespace Order.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IMediator mediator, ILogger<OrderController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            _logger.LogInformation("Processing Order From: {UserId}", command.UserId);
            var orderDto = await _mediator.Send(command);
            return Ok(orderDto);
        }
    }
}
