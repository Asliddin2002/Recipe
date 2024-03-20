using Microsoft.AspNetCore.Mvc;
using WAD_RecipeBook_12247.Models;
using WAD_RecipeBook_12247.Repository;

namespace WAD_RecipeBook_12247.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {

        private readonly IRepository<Ingredients> _repository;
        public IngredientsController(IRepository<Ingredients> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IEnumerable<Ingredients>> GetAll() => await _repository.GetAllAsync();


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Ingredients), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByID(int id)
        {
            var resulted = await _repository.GetByIDAsync(id);
            return resulted == null ? NotFound() : Ok(resulted);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Ingredients items)
        {
            await _repository.AddAsync(items);
            return Ok(items);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Ingredients items)
        {
            await _repository.UpdateAsync(items);
            return NoContent();
        }



        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();

        }
    }
}
