using MediatR;
using Product.Domain.Entities;
using Product.Domain.Interfaces;

namespace Product.Application.Queries
{
    public class GetProductQuery:IRequest<ProductModel>
    {
        public int Id { get; set; }
    }

    public class GetProductHandler : IRequestHandler<GetProductQuery, ProductModel>
    {
        private readonly IProductRepository _repository;

        public GetProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
