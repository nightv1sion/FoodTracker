using Microsoft.EntityFrameworkCore;
using src.FoodTracker.API.Entities;
using src.FoodTracker.API.Repository.Contracts;

namespace src.FoodTracker.API.Repository
{
    public class IngredientRepository : RepositoryBase<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(RepositoryContext context) : base(context) { }

        public void CreateIngredient(Ingredient ingredient) => Create(ingredient);

        public void DeleteIngredient(Ingredient ingredient) => Delete(ingredient);

        public async Task<Ingredient> GetIngredientAsync(Guid ingredientId, bool trackChanges)
            => await FindByCondition(x => x.Id == ingredientId, trackChanges).FirstOrDefaultAsync();

        public IQueryable<Ingredient> GetIngredients(bool trackChanges)
            => FindAll(trackChanges);

        public void UpdateIngredient(Ingredient ingredient) => Update(ingredient);
    }
}