using src.FoodTracker.API.Entities;

namespace src.FoodTracker.API.Commands.Meals.DTOs;

public class UpdateMealDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Guid> IngredientsIds { get; set; }
}