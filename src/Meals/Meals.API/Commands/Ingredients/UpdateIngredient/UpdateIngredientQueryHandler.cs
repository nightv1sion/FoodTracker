using AutoMapper;
using MediatR;
using src.Meals.Meals.API.Entities;
using src.Meals.Meals.API.Exceptions;
using src.Meals.Meals.API.Repository.Contracts;

namespace src.Meals.Meals.API.Commands.Ingredients.UpdateIngredient
{
    public class UpdateIngredientQueryHandler : IRequestHandler<UpdateIngredientQuery, Ingredient>
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;
        public UpdateIngredientQueryHandler(
            IIngredientRepository ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }
        public async Task<Ingredient> Handle(
            UpdateIngredientQuery request, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.GetIngredientAsync(request.UpdateIngredientDTO.Id, false);
            if (ingredient == null)
            {
                throw new IngredientNotFoundException(request.UpdateIngredientDTO.Id);
            }
            var updatedIngredient = _mapper.Map<Ingredient>(request.UpdateIngredientDTO);
            _ingredientRepository.UpdateIngredient(updatedIngredient);
            await _ingredientRepository.SaveChangesAsync();
            return updatedIngredient;
        }
    }
}