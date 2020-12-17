using System.Threading.Tasks;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // api/products
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;


        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //GET api/products
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var products = await _productService.GetAllAsync();

            return Ok(products);
        }
    }
}