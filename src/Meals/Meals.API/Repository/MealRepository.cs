using Microsoft.EntityFrameworkCore;
using src.Meals.Meals.API.Entities;
using src.Meals.Meals.API.Repository.Contracts;

namespace src.Meals.Meals.API.Repository
{
    public class MealRepository : RepositoryBase<Meal>, IMealRepository
    {
        public MealRepository(RepositoryContext context) : base(context) { }

        public void CreateMeal(Meal meal) => Create(meal);

        public void DeleteMeal(Meal meal) => Delete(meal);

        public async Task<Meal> GetMealAsync(Guid mealId, bool trackChanges)
            => await FindByCondition(x => x.Id == mealId, trackChanges).FirstOrDefaultAsync();

        public IQueryable<Meal> GetMeals(bool trackChanges)
            => FindAll(trackChanges);

        public void UpdateMeal(Meal meal) => Update(meal);
    }
}