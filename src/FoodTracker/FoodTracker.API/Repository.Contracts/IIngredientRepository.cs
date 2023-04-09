using src.FoodTracker.API.Entities;

namespace src.FoodTracker.API.Repository.Contracts
{
    public interface IIngredientRepository
    {
        void CreateIngredient(Ingredient ingredient);
        IQueryable<Ingredient> GetIngredients(bool trackChanges);
        Task<Ingredient> GetIngredientAsync(Guid ingredientId, bool trackChanges);
        void DeleteIngredient(Ingredient ingredient);
        void UpdateIngredient(Ingredient ingredient);
        Task SaveChangesAsync();
    }
}