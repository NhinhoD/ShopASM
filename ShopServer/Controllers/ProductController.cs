using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopShareLibrary.Contracts;
using ShopShareLibrary.Models;
using ShopShareLibrary.Reponses;

namespace ShopServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProduct _productService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProduct(bool featuredProducts)
        {
            return Ok(await _productService.GetAllProduct(featuredProducts));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceRepose>> AddProduct(Product model)
        {
            if (model is null)
            {
                return BadRequest("Dữ liệu đang bị rỗng!!!");
            }
            var response = await _productService.AddProduct(model);
            return Ok(response);
        }
    }
}
