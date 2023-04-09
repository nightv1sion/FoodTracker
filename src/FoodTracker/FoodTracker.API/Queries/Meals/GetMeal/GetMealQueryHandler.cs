using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using src.FoodTracker.API.Exceptions;
using src.FoodTracker.API.Queries.Meals.DTOs;
using src.FoodTracker.API.Repository.Contracts;

namespace src.FoodTracker.API.Queries.Meals.GetMeal;

public class GetMealQueryHandler : IRequestHandler<GetMealQuery, MealDTO>
{
    private readonly IMealRepository _mealRepository;
    private readonly IMapper _mapper;

    public GetMealQueryHandler(
        IMealRepository mealRepository,
        IMapper mapper)
    {
        _mealRepository = mealRepository;
        _mapper = mapper;
    }
    public async Task<MealDTO> Handle(GetMealQuery request, CancellationToken cancellationToken)
    {
        var meal = await _mealRepository.GetMeals(false)
            .Include(x => x.Ingredients)
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        if (meal == null)
        {
            throw new MealNotFoundException(request.Id);
        }
        var dto = _mapper.Map<MealDTO>(meal);
        return dto;
    }
}