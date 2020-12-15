using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // api/tasks
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUoW _uow;
        // private readonly IMapper _mapper;

        //GET api/tasks
        public CategoriesController(IUoW uow) //, IMapper mapper)
        {
            _uow = uow;
            // _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var categories = await _uow.CategoryRepository.GetAllAsync();

            return Ok(categories);
        }

        /*//GET api/tasks/{id}
        [HttpGet("{id}", Name = "GetTaskById")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _uow.TaskRepository.GetByIdAsync(id);

            if (task == null)
                return NotFound();
            
            return Ok(_mapper.Map<TaskDTO>(task));
        }*/

        //POST api/tasks
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] Category category)
        {
            //map
            Console.WriteLine(category.CategoryName);
            await _uow.CategoryRepository.CreateAsync(category);
            await _uow.SaveChangesAsync();

            Console.WriteLine(category.Id);
            //Fetch the task from data source, including the employee
            await _uow.CategoryRepository.GetByIdAsync(category.Id);
            return Ok();
            return CreatedAtRoute("GetTaskById", new {id = category.Id}, category);
        }


        /*//PATCH api/tasks/id
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] JsonPatchDocument<Category> patchDoc)
        {
            Console.Write("loh");
            var taskFromRepo = await _uow.CategoryRepository.GetByIdAsync(id);
            if (taskFromRepo == null)
                return NotFound();
            
            patchDoc.ApplyTo(taskFromRepo, ModelState);
            if (await _uow.SaveChangesAsync())
                return Ok(taskFromRepo);
            else return BadRequest("zalupa");
        }*/

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            var taskFromRepo = await _uow.CategoryRepository.GetByIdAsync(id);
            if (taskFromRepo == null)
                return NotFound();

            _uow.CategoryRepository.Update(category);
            await _uow.SaveChangesAsync();
            return NoContent(); 
        }
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var categoryToDelete = await _uow.CategoryRepository.GetByIdAsync(id);
            if (categoryToDelete == null)
                return NotFound(); 
            
            _uow.CategoryRepository.Remove(categoryToDelete);
            await _uow.SaveChangesAsync();
            
            return NoContent();
        }
    }
}