using AutoMapper;
using MediatR;
using src.Meals.Meals.API.Exceptions;
using src.Meals.Meals.API.Queries.Ingredients.DTOs;
using src.Meals.Meals.API.Repository.Contracts;

namespace src.Meals.Meals.API.Queries.Ingredients.GetIngredient
{
    public class GetIngredientQueryHandler : IRequestHandler<GetIngredientQuery, IngredientDTO>
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public GetIngredientQueryHandler(
            IIngredientRepository ingredientRepository,
            IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }
        public async Task<IngredientDTO> Handle(
            GetIngredientQuery request, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.GetIngredientAsync(request.Id, false);
            if (ingredient == null)
            {
                throw new IngredientNotFoundException(request.Id);
            }

            var dto = _mapper.Map<IngredientDTO>(ingredient);
            return dto;
        }
    }


}