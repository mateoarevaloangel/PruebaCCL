using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetProducts();
        //Task<ProductEntity> GetProductById();
        Task<ProductEntity> AddProduct(ProductEntity product);
    }
}
