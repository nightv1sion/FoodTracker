using Microsoft.EntityFrameworkCore;
using src.Ingredients.Ingredients.API.Repository.Contracts;

namespace src.Ingredients.Ingredients.API.Repository
{
    public class IngredientRepository : RepositoryBase<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(RepositoryContext context) : base(context) { }

        public void CreateIngredient(Ingredient ingredient) => Create(ingredient);

        public void DeleteIngredient(Ingredient ingredient) => DeleteIngredient(ingredient);

        public async Task<Ingredient> GetIngredientAsync(Guid ingredientId, bool trackChanges)
            => await FindByCondition(x => x.Id == ingredientId, trackChanges).FirstOrDefaultAsync();

        public async Task<List<Ingredient>> GetIngredientsAsync(bool trackChanges)
            => await FindAll(trackChanges).ToListAsync();

        public void UpdateIngredient(Ingredient ingredient) => Update(ingredient);
    }
}