using MediatR;

namespace Product.Application.Commands.CreateCommand
{
    public class CreateProductCommand:IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

}
