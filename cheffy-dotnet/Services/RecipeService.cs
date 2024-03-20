using cheffy_dotnet.Models;
using cheffy_dotnet.Repositories;

namespace cheffy_dotnet.Services
{
    public class RecipeService
    {
        private readonly IRecipeRepository _repository;

        public RecipeService(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RecipeDTO>> GetAllRecipesAsync()
        {
            var recipes = await _repository.GetAllRecipesAsync();
            return recipes.Select(r => RecipeToDTO(r));
        }

        public async Task<RecipeDTO?> GetRecipeById(int id)
        {
            var recipe = await _repository.GetRecipeByIdAsync(id);
            if (recipe != null)
            {
                return RecipeToDTO(recipe);
            }
            return null;
        }

        public async Task UpdateRecipeAsync(RecipeDTO recipe)
        {
            await _repository.UpdateRecipeAsync(DTOToRecipe(recipe));
        }

        public async Task InsertRecipeAsync(RecipeDTO recipe)
        {
            await _repository.InsertRecipeAsync(DTOToRecipe(recipe));
        }

        public async Task DeleteRecipeAsync(int id)
        {
            await _repository.DeleteRecipeAsync(id);
        }


        // private methods

        private static Recipe DTOToRecipe(RecipeDTO recipe)
        {
            return new Recipe
            {
                Name = recipe.Name,
                Description = recipe.Description,
                CreatedDate = DateTime.Now
            };
        }

        private static RecipeDTO RecipeToDTO(Recipe recipe)
        {
            return new RecipeDTO
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description
            };
        }
    }
}
