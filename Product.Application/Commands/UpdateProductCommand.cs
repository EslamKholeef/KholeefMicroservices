using AutoMapper;
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
        private readonly IMapper _mapper;
        public UpdateProductHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var existingProduct = await _repository.GetByIdAsync(request.Id);
            if (existingProduct == null)
            {
                return false; 
            }

            var product = _mapper.Map<ProductModel>(request);

            return await _repository.UpdateAsync(product);
        }
    }
}
