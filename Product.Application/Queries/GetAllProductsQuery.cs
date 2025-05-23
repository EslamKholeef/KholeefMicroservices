using MediatR;
using Product.Domain.Entities;
using Product.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Queries
{
    public class GetAllProductsQuery : IRequest<List<ProductModel>>
    {
    }

    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductModel>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductsHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
