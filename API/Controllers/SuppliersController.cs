using System.Threading.Tasks;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // api/suppliers
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;


        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        //GET api/suppliers
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var suppliers = await _supplierService.GetAllAsync();

            return Ok(suppliers);
        }
    }
}