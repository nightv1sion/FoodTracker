using src.Meals.Meals.API.Entities;

namespace src.Meals.Meals.API.Repository.Contracts;
public interface IMealRepository
{
    void CreateMeal(Meal meal);
    IQueryable<Meal> GetMeals(bool trackChanges);
    Task<Meal> GetMealAsync(Guid mealId, bool trackChanges);
    void DeleteMeal(Meal meal);
    void UpdateMeal(Meal meal);
    Task SaveChangesAsync();
}