using Microsoft.AspNetCore.Mvc;
using cheffy_dotnet.Models;
using cheffy_dotnet.Services;

namespace cheffy_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        //private readonly RecipeContext _context;
        private readonly RecipeService _recipeService;

        public RecipesController(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDTO>>> GetRecipes()
        {
            /*return await _context.Recipes
                .Select(r => RecipeToDTO(r))
                .ToListAsync();*/

            return Ok(await _recipeService.GetAllRecipesAsync());
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDTO>> GetRecipe(int id)
        {
            var recipe = await _recipeService.GetRecipeById(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, RecipeDTO recipeDTO)
        {
            if (id != recipeDTO.Id)
            {
                return BadRequest();
            }

            await _recipeService.InsertRecipeAsync(recipeDTO);

            return NoContent();
        }

        // POST: api/Recipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecipeDTO>> PostRecipe(RecipeDTO recipeDTO)
        {
            /* var recipe = new Recipe
             {
                 Id = recipeDTO.Id,
                 Name = recipeDTO.Name,
                 Description = recipeDTO.Description,
             };

             _context.Recipes.Add(recipe);
             await _context.SaveChangesAsync();

             return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);*/
            await _recipeService.InsertRecipeAsync(recipeDTO);
            return Ok(recipeDTO);

        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            /*var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return NoContent();*/
            await _recipeService.DeleteRecipeAsync(id);
            return NoContent();
        }

        /*private bool RecipeExists(long id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }

        private static RecipeDTO RecipeToDTO(Recipe recipe) =>
            new RecipeDTO
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description
            };*/
    }
}
