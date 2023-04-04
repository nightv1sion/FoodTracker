using AutoMapper;
using MediatR;
using src.Meals.Meals.API.Commands.Ingredients.DTOs;
using src.Meals.Meals.API.Entities;
using src.Meals.Meals.API.Exceptions;
using src.Meals.Meals.API.Repository.Contracts;

namespace src.Meals.Meals.API.Commands.Ingredients.UpdateIngredient
{
    public class UpdateIngredientCommandHandler : IRequestHandler<UpdateIngredientCommand, IngredientDTO>
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;
        public UpdateIngredientCommandHandler(
            IIngredientRepository ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }
        public async Task<IngredientDTO> Handle(
            UpdateIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.GetIngredientAsync(request.UpdateIngredientDTO.Id, false);
            if (ingredient == null)
            {
                throw new IngredientNotFoundException(request.UpdateIngredientDTO.Id);
            }
            var updatedIngredient = _mapper.Map<Ingredient>(request.UpdateIngredientDTO);
            _ingredientRepository.UpdateIngredient(updatedIngredient);
            await _ingredientRepository.SaveChangesAsync();
            var dto = _mapper.Map<IngredientDTO>(updatedIngredient);
            return dto;
        }
    }
}