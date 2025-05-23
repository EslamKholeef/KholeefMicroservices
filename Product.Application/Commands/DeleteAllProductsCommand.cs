using MediatR;
using Product.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Commands
{
    public class DeleteAllProductsCommand : IRequest<bool>
    {
    }

    public class DeleteAllProductsHandler : IRequestHandler<DeleteAllProductsCommand, bool>
    {
        private readonly IProductRepository _repository;

        public DeleteAllProductsHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteAllProductsCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAllAsync();
            return true;
        }
    }
}
