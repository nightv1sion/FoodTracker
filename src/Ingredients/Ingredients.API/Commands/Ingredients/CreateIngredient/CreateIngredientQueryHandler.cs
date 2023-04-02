using AutoMapper;
using MediatR;
using src.Ingredients.Ingredients.API.Entities;
using src.Ingredients.Ingredients.API.Repository.Contracts;

namespace src.Ingredients.Ingredients.API.Commands.Ingredients.CreateIngredient
{
    public class CreateIngredientQueryHandler : IRequestHandler<CreateIngredientQuery, Ingredient>
    {
        private readonly IMapper _mapper;
        private readonly IIngredientRepository _ingredientRepository;

        public CreateIngredientQueryHandler(IMapper mapper, IIngredientRepository ingredientRepository)
        {
            _mapper = mapper;
            _ingredientRepository = ingredientRepository;
        }
        public async Task<Ingredient> Handle(
            CreateIngredientQuery request, CancellationToken cancellationToken)
        {
            var ingredient = _mapper.Map<Ingredient>(request.CreateIngredientDTO);
            _ingredientRepository.CreateIngredient(ingredient);
            await _ingredientRepository.SaveChangesAsync();
            return ingredient;
        }
    }
}