using System.Text.Json;
using AutoMapper;
using Grpc.Core;
using MediatR;
using src.FoodTracker.API.Commands.Meals.CreateMeal;
using src.FoodTracker.API.Commands.Meals.DeleteMeal;
using src.FoodTracker.API.Commands.Meals.DTOs;
using src.FoodTracker.API.Commands.Meals.UpdateMeal;
using src.FoodTracker.API.Queries.Meals.GetMeal;
using src.FoodTracker.API.Queries.Meals.GetMeals;

namespace src.FoodTracker.API.GrpcServices;

public class MealsGrpcService : Meals.MealsBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public MealsGrpcService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    public override async Task<GetMealsResponse> GetMeals(GetMealsRequest request,
        ServerCallContext context)
    {
        var meals = await _mediator.Send(new GetMealsQuery());
        var response = new GetMealsResponse(new GetMealsResponse());
        foreach (var meal in meals)
        {
            var mealProto = _mapper.Map<MealProto>(meal);
            foreach (var ingredientsId in meal.IngredientsIds)
            {
                mealProto.IngredientsIds.Add(ingredientsId.ToString());
            }
            response.Meals.Add(mealProto);
        }
        return response;
    }
    public override async Task<GetMealResponse> GetMeal(GetMealRequest request,
        ServerCallContext context)
    {
        var id = Guid.Parse(request.Id);
        var meal = await _mediator.Send(new GetMealQuery(id));
        var mealProto = _mapper.Map<MealProto>(meal);
        foreach (var ingredientsId in meal.IngredientsIds)
        {
            mealProto.IngredientsIds.Add(ingredientsId.ToString());
        }
        var response = new GetMealResponse()
        {
            Meal = mealProto
        };
        return response;
    }
    public override async Task<CreateMealResponse> CreateMeal(CreateMealRequest request,
        ServerCallContext context)
    {
        Console.WriteLine(JsonSerializer.Serialize(request));
        var createMealDto = _mapper.Map<CreateMealDTO>(request.Meal);
        var meal = await _mediator.Send(new CreateMealCommand(createMealDto));
        var mealProto = _mapper.Map<MealProto>(meal);

        foreach (var ingredientsId in meal.IngredientsIds)
        {
            mealProto.IngredientsIds.Add(ingredientsId.ToString());
        }
        var response = new CreateMealResponse()
        {
            Meal = mealProto
        };
        return response;
    }
    public override async Task<UpdateMealResponse> UpdateMeal(UpdateMealRequest request,
        ServerCallContext context)
    {
        var createMealDto = _mapper.Map<UpdateMealDTO>(request.Meal);
        var meal = await _mediator.Send(new UpdateMealCommand(createMealDto));
        var mealProto = _mapper.Map<MealProto>(meal);

        foreach (var ingredientsId in meal.IngredientsIds)
        {
            mealProto.IngredientsIds.Add(ingredientsId.ToString());
        }
        var response = new UpdateMealResponse()
        {
            Meal = mealProto
        };
        return response;
    }
    public override async Task<DeleteMealResponse> DeleteMeal(DeleteMealRequest request,
        ServerCallContext context)
    {
        var id = Guid.Parse(request.Id);
        await _mediator.Send(new DeleteMealCommand(id));
        return new DeleteMealResponse();
    }
}