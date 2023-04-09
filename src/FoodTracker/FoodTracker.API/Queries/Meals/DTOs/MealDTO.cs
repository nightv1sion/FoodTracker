namespace src.FoodTracker.API.Queries.Meals.DTOs;
public class MealDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Guid> IngredientsIds { get; set; }
}