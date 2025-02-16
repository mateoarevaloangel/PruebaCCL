using Core.Entities;
using Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public record GetAllProductsQuery() : IRequest<IEnumerable<ProductEntity>>;
    public class GetAllProductsQueryHandler(IProductRepository productRepository)
        : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductEntity>>
    {
        public async Task<IEnumerable<ProductEntity>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetProducts();
        }
    }
}
