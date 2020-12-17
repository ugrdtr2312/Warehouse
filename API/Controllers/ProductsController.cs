using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// <c>ProductsController</c> is a class.
    /// Contains all http methods for working with products.
    /// </summary>
    /// <remarks>
    /// This class can get, create, delete, edit products.
    /// </remarks>
    
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

        
        /// <summary>
        /// This method returns all products
        /// </summary>
        /// <response code="200">Returns all products</response>
        
        //GET api/products
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }
        
        
        /// <summary>
        /// This method returns product that has an inputted Id property
        /// </summary>
        /// <response code="200">Returns product that has an inputted Id property</response>
        /// <response code="404">Returns message that nothing was found, if message wasn't returned than id inputted incorrectly</response>
        
        //GET api/products/{id}
        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);
                return Ok(product);
            }
            catch (DbQueryResultNullException e)
            {
                return NotFound(e.Message);
            }
        }
        
        
        /// <summary>
        /// This method returns product that was created and path to it
        /// </summary>
        /// <response code="201">Returns product that was created and path to it</response>
        /// <response code="400">Returns message why model is invalid</response>
        /// <response code="404">Returns message if something had gone wrong</response>

        //POST api/products 
        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), 201)]
        public async Task<IActionResult> CreateProduct(ProductDto productDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (productDto.Id != 0)
                    return BadRequest("The Id should be empty");
               
                var createdProduct = await _productService.CreateAsync(productDto);
            
                //Fetch the product from data source
                return CreatedAtRoute("GetProductById", new {id = productDto.Id}, createdProduct);
            }
            catch (DbQueryResultNullException e)
            {
                return NotFound(e.Message);
            }
        }
        
        
        /// <summary>
        /// This method changes product
        /// </summary>
        /// <response code="204">Returns nothing, product was successfully changed</response>
        /// <response code="400">Returns message why model is invalid</response>
        /// <response code="404">Returns message that product was not found, if message wasn't returned than id inputted incorrectly</response>
        
        //PUT api/products
        [HttpPut]
        [ProducesResponseType(204)]
        public IActionResult UpdateProduct(ProductDto productDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _productService.Update(productDto);
                return NoContent();
            }
            catch (DbQueryResultNullException e)
            {
                return NotFound(e.Message);
            }
        }
        
        
        /// <summary>
        /// This method deletes product
        /// </summary>
        /// <response code="204">Returns nothing, product was successfully deleted</response>
        /// <response code="404">Returns message that product was not found</response>
        
        //DELETE api/products/{id}
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.Remove(id);
                return NoContent();
            }
            catch (DbQueryResultNullException e)
            {
                return NotFound(e.Message);
            }
        }
        
        
        /// <summary>
        /// This method returns products that have an inputted CategoryId property
        /// </summary>
        /// <response code="200">Returns products that have an inputted CategoryId property</response>
        
        //GET api/products/category/{id}
        [HttpGet("category/{id:int}")]
        public async Task<IActionResult> GetProductByCategoryId(int id)
        {
            var products = await _productService.GetAllByCategoryIdAsync(id);
            return Ok(products);
        }
        
        
        /// <summary>
        /// This method returns products that have an inputted SupplierId property
        /// </summary>
        /// <response code="200">Returns products that have an inputted SupplierId property</response>
        
        //GET api/products/supplier/{id}
        [HttpGet("supplier/{id:int}")]
        public async Task<IActionResult> GetProductBySupplierId(int id)
        {
            var products = await _productService.GetAllBySupplierIdAsync(id);
            return Ok(products);
        }
        
        
        /// <summary>
        /// This method returns products that have an inputted BrandId property
        /// </summary>
        /// <response code="200">Returns products that have an inputted BrandId property</response>
        
        //GET api/products/brand/{id}
        [HttpGet("brand/{id:int}")]
        public async Task<IActionResult> GetProductByBrandId(int id)
        {
            var products = await _productService.GetAllByBrandIdAsync(id);
            return Ok(products);
        }
    }
}