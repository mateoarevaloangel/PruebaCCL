using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository(AppDBContext dbContext): IProductRepository
    {
        public async Task<IEnumerable<ProductEntity>> GetProducts()
        {
            return await dbContext.Products.ToListAsync();
        }
        public async Task<ProductEntity> AddProduct(ProductEntity product)
        {
            //product.idproduct = Guid.NewGuid();
            dbContext.Products.Add(product);
            
            return product;
        }
        //create update
    }
}
