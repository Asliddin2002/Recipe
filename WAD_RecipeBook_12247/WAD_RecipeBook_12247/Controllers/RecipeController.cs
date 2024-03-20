using Microsoft.AspNetCore.Mvc;
using WAD_RecipeBook_12247.Models;
using WAD_RecipeBook_12247.Repository;

namespace WAD_RecipeBook_12247.Controllers
{
    // StudentId 12247

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRepository<Recipe> _repository;
        public RecipeController(IRepository<Recipe> repository)
        {
            _repository = repository;
        }

        // GET: api/<RecipeController>
        [HttpGet]
        public async Task<IEnumerable<Recipe>> Get()
        {
            return await _repository.GetAllAsync();
        }

        // GET api/<RecipeController>/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var resultedRecipe = await _repository.GetByIDAsync(id);
            if (resultedRecipe == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(resultedRecipe);
            }
        }

        // POST api/<RecipeController>
        [HttpPost]
        public async Task<IActionResult> Create(Recipe recipe)
        {
            await _repository.AddAsync(recipe);
            return CreatedAtAction(nameof(GetByID), new { id = recipe.ID }, recipe);
        }

        // PUT api/<RecipeController>/id
        [HttpPut]
        public async Task<IActionResult> Update(Recipe recipe)
        {
            //if(id!=items.ID) return BadRequest();
            await _repository.UpdateAsync(recipe);
            return NoContent();
        }

        // DELETE api/<RecipeController>/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
