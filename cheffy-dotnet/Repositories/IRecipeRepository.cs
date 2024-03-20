using cheffy_dotnet.Models;

namespace cheffy_dotnet.Repositories
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetAllRecipesAsync();
        Task<Recipe?> GetRecipeByIdAsync(int id);
        Task UpdateRecipeAsync(Recipe recipe);
        Task InsertRecipeAsync(Recipe recipe);
        Task DeleteRecipeAsync(int id);

    }
}
