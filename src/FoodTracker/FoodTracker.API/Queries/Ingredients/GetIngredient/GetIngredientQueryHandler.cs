using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using src.FoodTracker.API.Exceptions;
using src.FoodTracker.API.Queries.Ingredients.DTOs;
using src.FoodTracker.API.Repository.Contracts;

namespace src.FoodTracker.API.Queries.Ingredients.GetIngredient
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
            var ingredient = await _ingredientRepository.GetIngredients(false)
                .Include(x => x.Meals)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (ingredient == null)
            {
                throw new IngredientNotFoundException(request.Id);
            }

            var dto = _mapper.Map<IngredientDTO>(ingredient);
            return dto;
        }
    }


}