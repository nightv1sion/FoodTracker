using AutoMapper;
using MediatR;
using src.Meals.Meals.API.Commands.Ingredients.DTOs;
using src.Meals.Meals.API.Entities;
using src.Meals.Meals.API.Repository.Contracts;

namespace src.Meals.Meals.API.Commands.Ingredients.CreateIngredient
{
    public class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand, IngredientDTO>
    {
        private readonly IMapper _mapper;
        private readonly IIngredientRepository _ingredientRepository;

        public CreateIngredientCommandHandler(IMapper mapper, IIngredientRepository ingredientRepository)
        {
            _mapper = mapper;
            _ingredientRepository = ingredientRepository;
        }
        public async Task<IngredientDTO> Handle(
            CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredient = _mapper.Map<Ingredient>(request.CreateIngredientDTO);
            _ingredientRepository.CreateIngredient(ingredient);
            await _ingredientRepository.SaveChangesAsync();
            var dto = _mapper.Map<IngredientDTO>(ingredient);
            return dto;
        }
    }
}