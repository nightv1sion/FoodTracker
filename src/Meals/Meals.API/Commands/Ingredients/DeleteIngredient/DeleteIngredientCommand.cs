using MediatR;

namespace src.Meals.Meals.API.Commands.Ingredients.DeleteIngredient
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
