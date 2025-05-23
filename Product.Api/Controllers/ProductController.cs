using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Commands;
using Product.Application.Queries;

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductRequest request)
        {
            var command = new UpdateProductCommand()
            {
                Id = id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
            };
            var result = await _mediator.Send(command);
            return result ? Ok() : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var query = new GetProductQuery { Id = id };
            var product = await _mediator.Send(query);
            return product != null ? Ok(product) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand { Id = id };
            var result = await _mediator.Send(command);
            return result ? Ok() : NotFound();
        }

        [HttpDelete("all")]
        public async Task<IActionResult> DeleteAllProducts()
        {
            var command = new DeleteAllProductsCommand();
            var result = await _mediator.Send(command);
            return result ? Ok() : BadRequest();
        }
    }
}
