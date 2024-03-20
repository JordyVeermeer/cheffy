namespace cheffy_dotnet.Models
{
    public class Recipe
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public IEnumerable<Ingredient>? Ingredients { get; set; }
    }
}
