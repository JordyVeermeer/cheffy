using cheffy_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace cheffy_dotnet.Repositories
{
    public class SQLRecipeRepository : IRecipeRepository
    {
        private readonly RecipeContext _recipeContext;

        public SQLRecipeRepository(RecipeContext recipeContext)
        {
            _recipeContext = recipeContext;
        }

        public async Task DeleteRecipeAsync(int id)
        {
            var recipe = _recipeContext.Recipes.Find(id);
            if (recipe != null)
            {
                _recipeContext.Recipes.Remove(recipe);
                await _recipeContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            return await _recipeContext.Recipes.ToListAsync();
        }

        public async Task<Recipe?> GetRecipeByIdAsync(int id)
        {
            return await _recipeContext.Recipes.FindAsync((long) id);
        }

        public async Task InsertRecipeAsync(Recipe recipe)
        {
            _recipeContext.Recipes.Add(recipe);
            await _recipeContext.SaveChangesAsync();
        }

        public Task UpdateRecipeAsync(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
