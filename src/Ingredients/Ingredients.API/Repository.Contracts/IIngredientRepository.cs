using src.Ingredients.Ingredients.API.Entities;

namespace src.Ingredients.Ingredients.API.Repository.Contracts
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