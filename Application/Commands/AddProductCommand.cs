using Core.Entities;
using Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public record AddProductCommand(ProductEntity Product) : IRequest<ProductEntity>;

    public class AddProductCommandHandler(IProductRepository productRepository) 
        : IRequestHandler<AddProductCommand, ProductEntity>
    {
        public async Task<ProductEntity> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return await productRepository.AddProduct(request.Product);
        }
    }
}
