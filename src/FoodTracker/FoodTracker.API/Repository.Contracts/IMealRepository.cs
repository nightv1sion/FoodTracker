using src.FoodTracker.API.Entities;

namespace src.FoodTracker.API.Repository.Contracts;
public interface IMealRepository
{
    void CreateMeal(Meal meal);
    IQueryable<Meal> GetMeals(bool trackChanges);
    Task<Meal> GetMealAsync(Guid mealId, bool trackChanges);
    void DeleteMeal(Meal meal);
    void UpdateMeal(Meal meal);
    Task SaveChangesAsync();
}