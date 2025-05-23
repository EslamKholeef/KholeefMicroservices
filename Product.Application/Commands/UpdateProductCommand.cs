using MediatR;
using Product.Domain.Entities;
using Product.Domain.Interfaces;

namespace Product.Application.Commands
{
    public class UpdateProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

    public class UpdateProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }


    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _repository;

        public UpdateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductModel
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };
            return await _repository.UpdateAsync(product);
        }
    }
}
