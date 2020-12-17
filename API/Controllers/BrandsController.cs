using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// <c>BrandsController</c> is a class.
    /// Contains all http methods for working with brands.
    /// </summary>
    /// <remarks>
    /// This class can get, create, delete, edit brands.
    /// </remarks>
    
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
        
        
        /// <summary>
        /// This method returns all brands
        /// </summary>
        /// <response code="200">Returns all brands</response>

        //GET api/brands
        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var brands = await _brandsService.GetAllAsync();
            return Ok(brands);
        }
        
        
        /// <summary>
        /// This method returns brand that has an inputted Id property
        /// </summary>
        /// <response code="200">Returns brand that has an inputted Id property</response>
        /// <response code="404">Returns message that nothing was found, if message wasn't returned than id inputted incorrectly</response>
        
        //GET api/brands/{id}
        [HttpGet("{id:int}", Name = "GetBrandById")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            try
            {
                var brand = await _brandsService.GetByIdAsync(id);
                return Ok(brand);
            }
            catch (DbQueryResultNullException e)
            {
                return NotFound(e.Message);
            }
        }
        
        
        /// <summary>
        /// This method returns brand that was created and path to it
        /// </summary>
        /// <response code="201">Returns brand that was created and path to it</response>
        /// <response code="400">Returns message why model is invalid</response>
        /// <response code="404">Returns message if something had gone wrong</response>

        //POST api/brands 
        [HttpPost]
        [ProducesResponseType(typeof(BrandDto), 201)]
        public async Task<IActionResult> CreateBrand(BrandDto brandDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (brandDto.Id != 0)
                    return BadRequest("The Id should be empty");
               
                var createdBrand = await _brandsService.CreateAsync(brandDto);
            
                //Fetch the brand from data source
                return CreatedAtRoute("GetBrandById", new {id = createdBrand.Id}, createdBrand);
            }
            catch (DbQueryResultNullException e)
            {
                return NotFound(e.Message);
            }
        }
        
        
        /// <summary>
        /// This method changes brand
        /// </summary>
        /// <response code="204">Returns nothing, brand was successfully changed</response>
        /// <response code="400">Returns message why model is invalid</response>
        /// <response code="404">Returns message that brand was not found, if message wasn't returned than id inputted incorrectly</response>
        
        //PUT api/brands
        [HttpPut]
        [ProducesResponseType(204)]
        public IActionResult UpdateBrand(BrandDto brandDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _brandsService.Update(brandDto);
                return NoContent();
            }
            catch (DbQueryResultNullException e)
            {
                return NotFound(e.Message);
            }
        }
        
        
        /// <summary>
        /// This method deletes brand
        /// </summary>
        /// <response code="204">Returns nothing, brand was successfully deleted</response>
        /// <response code="404">Returns message that brand was not found</response>
        
        //DELETE api/brands/{id}
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        public IActionResult DeleteBrand(int id)
        {
            try
            {
                _brandsService.Remove(id);
                return NoContent();
            }
            catch (DbQueryResultNullException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}