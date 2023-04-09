using MediatR;

namespace src.FoodTracker.API.Commands.Ingredients.DeleteIngredient
{
    public class DeleteIngredientCommand : IRequest
    {
        public DeleteIngredientCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
