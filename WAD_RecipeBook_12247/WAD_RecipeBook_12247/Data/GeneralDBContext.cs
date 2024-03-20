using Microsoft.EntityFrameworkCore;
using WAD_RecipeBook_12247.Models;

namespace WAD_RecipeBook_12247.Data
{
    public class GeneralDBContext : DbContext
    {
        public GeneralDBContext(DbContextOptions<GeneralDBContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
    }
}
