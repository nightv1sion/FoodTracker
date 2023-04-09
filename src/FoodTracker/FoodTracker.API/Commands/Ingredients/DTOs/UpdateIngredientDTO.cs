namespace src.FoodTracker.API.Commands.Ingredients.DTOs
{
    public class UpdateIngredientDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Calories { get; set; }
        public decimal Proteins { get; set; }
        public decimal Carbs { get; set; }
        public decimal Fats { get; set; }
    }
}