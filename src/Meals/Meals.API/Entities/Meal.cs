namespace src.Meals.Meals.API.Entities;

public class Meal
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; }
}
