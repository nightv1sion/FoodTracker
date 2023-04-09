using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using src.FoodTracker.API.Entities;
using src.FoodTracker.API.Queries.Meals.DTOs;
using src.FoodTracker.API.Repository.Contracts;

namespace src.FoodTracker.API.Queries.Meals.GetMeals;

public class GetMealsQueryHandler
    : IRequestHandler<GetMealsQuery, IEnumerable<MealDTO>>
{
    private readonly IMealRepository _mealRepository;
    private readonly IMapper _mapper;

    public GetMealsQueryHandler(
        IMealRepository mealRepository,
        IMapper mapper)
    {
        _mealRepository = mealRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<MealDTO>> Handle(GetMealsQuery request, CancellationToken cancellationToken)
    {
        var meals = _mealRepository.GetMeals(false).Include(x => x.Ingredients);
        var dtos = _mapper.Map<IEnumerable<MealDTO>>(meals);
        return dtos;
    }
}
