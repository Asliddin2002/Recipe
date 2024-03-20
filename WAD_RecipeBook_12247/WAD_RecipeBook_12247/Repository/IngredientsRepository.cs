using Microsoft.EntityFrameworkCore;
using WAD_RecipeBook_12247.Data;
using WAD_RecipeBook_12247.Models;

namespace WAD_RecipeBook_12247.Repository
{
    public class IngredientsRepository : IRepository<Ingredients>
    {
        private readonly GeneralDBContext _context;

        public IngredientsRepository(GeneralDBContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Ingredients ingredients)
        {
            ingredients.Recipe = await _context.Recipes.FindAsync(ingredients.RecipeID.Value);

            await _context.Ingredients.AddAsync(ingredients);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Ingredients.FindAsync(id);
            if (entity != null)
            {
                _context.Ingredients.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Ingredients>> GetAllAsync() => await _context.Ingredients.ToArrayAsync();


        public async Task<Ingredients> GetByIDAsync(int id)
        {
            return await _context.Ingredients.Include(t => t.Recipe).FirstOrDefaultAsync(t => t.ID == id);
        }

        public async Task UpdateAsync(Ingredients entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
