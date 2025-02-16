using Application.Commands;
using Application.Queries;
using Core.Entities;
using Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ISender sender) 
        : ControllerBase
    {
        /*private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }*/
        [HttpPost("")]
        public async Task<IActionResult> AddProduct(ProductEntity product)
        {
            var result = await sender.Send(new AddProductCommand(product));
            return Ok(result);
        }
        [HttpGet("AllProducts")]
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await sender.Send(new GetAllProductsQuery());
            return Ok(result);
        }
    }
}
