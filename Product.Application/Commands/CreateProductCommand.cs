using MediatR;
using Product.Domain.Entities;
using Product.Domain.Interfaces;

namespace Product.Application.Commands
{
    public class CreateProductCommand:IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IProductRepository _repository;

        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductModel
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };
            await _repository.AddAsync(product);
            return Unit.Value;
        }
    }

}
