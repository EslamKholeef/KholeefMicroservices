using AutoMapper;
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
        private readonly IMapper _mapper;
        public CreateProductHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductModel>(request);

            await _repository.AddAsync(product);
            return Unit.Value;
        }
    }

}
