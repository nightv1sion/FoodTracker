namespace src.Meals.Meals.API.Exceptions
{
    public class IngredientNotFoundException : NotFoundException
    {
        public IngredientNotFoundException(Guid id) : base($"Ingredient with id: {id} not found")
        { }
    }
}
