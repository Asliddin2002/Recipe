using Microsoft.EntityFrameworkCore;
using WAD_RecipeBook_12247.Data;
using WAD_RecipeBook_12247.Models;

namespace WAD_RecipeBook_12247.Repository
{
    public class RecipeRepository : IRepository<Recipe>
    {

        private readonly GeneralDBContext _context;

        public RecipeRepository(GeneralDBContext context)
        {
            _context = context;

        }

        // Adding new entity

        public async Task AddAsync(Recipe recipe)
        {
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
        }

        // Delete an entity
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Recipes.FindAsync(id);
            if (entity != null)
            {
                _context.Recipes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        // Retrieve all entity from the database
        public async Task<IEnumerable<Recipe>> GetAllAsync() => await _context.Recipes.ToArrayAsync();

        // Retrieve an entity from database using only an id

        public async Task<Recipe> GetByIDAsync(int id) => await _context.Recipes.FindAsync(id);


        // Update Entity
        public async Task UpdateAsync(Recipe recipe)
        {
            _context.Entry(recipe).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
