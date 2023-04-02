using src.Meals.Meals.API.Entities;

namespace src.Meals.Meals.API.Repository.Contracts
{
    public interface IIngredientRepository
    {
        void CreateIngredient(Ingredient ingredient);
        Task<List<Ingredient>> GetIngredientsAsync(bool trackChanges);
        Task<Ingredient> GetIngredientAsync(Guid ingredientId, bool trackChanges);
        void DeleteIngredient(Ingredient ingredient);
        void UpdateIngredient(Ingredient ingredient);
        Task SaveChangesAsync();
    }
}