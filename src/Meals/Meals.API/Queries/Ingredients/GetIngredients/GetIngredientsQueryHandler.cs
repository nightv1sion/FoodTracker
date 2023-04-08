using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using src.Meals.Meals.API.Entities;
using src.Meals.Meals.API.Queries.Ingredients.DTOs;
using src.Meals.Meals.API.Repository.Contracts;


namespace src.Meals.Meals.API.Queries.Ingredients.GetIngredients
{
    public class GetIngredientsQueryHandler : IRequestHandler<GetIngredientsQuery, IEnumerable<IngredientDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IIngredientRepository _ingredientRepository;
        public GetIngredientsQueryHandler(
            IIngredientRepository ingredientRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _ingredientRepository = ingredientRepository;
        }
        public async Task<IEnumerable<IngredientDTO>> Handle(
            GetIngredientsQuery request, CancellationToken cancellationToken)
        {
            var ingredients = _ingredientRepository.GetIngredients(true)
                .Include(x => x.Meals);
            var dtos = _mapper.Map<IEnumerable<IngredientDTO>>(ingredients);
            return dtos;
        }
    }
}