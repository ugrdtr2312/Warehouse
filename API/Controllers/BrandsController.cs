using System.Threading.Tasks;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // api/brands
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandsService;


        public BrandsController(IBrandService brandsService)
        {
            _brandsService = brandsService;
        }

        //GET api/brands
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var brands = await _brandsService.GetAllAsync();

            return Ok(brands);
        }
    }
}