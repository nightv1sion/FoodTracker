using AutoMapper;
using Grpc.Core;
using MediatR;
using src.FoodTracker.API.Commands.Ingredients.CreateIngredient;
using src.FoodTracker.API.Commands.Ingredients.DeleteIngredient;
using src.FoodTracker.API.Commands.Ingredients.DTOs;
using src.FoodTracker.API.Commands.Ingredients.UpdateIngredient;
using src.FoodTracker.API.Queries.Ingredients.GetIngredient;
using src.FoodTracker.API.Queries.Ingredients.GetIngredients;

namespace src.FoodTracker.API.GrpcServices;

public class IngredientsGrpcService : Ingredients.IngredientsBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public IngredientsGrpcService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    public override async Task<GetIngredientsResponse> GetIngredients(GetIngredientsRequest request,
        ServerCallContext context)
    {
        var ingredients = await _mediator.Send(new GetIngredientsQuery());
        var response = new GetIngredientsResponse(new GetIngredientsResponse());
        foreach (var ingredient in ingredients)
        {
            var ingredientProto = _mapper.Map<IngredientProto>(ingredient);
            foreach (var mealId in ingredient.MealsIds)
            {
                ingredientProto.MealsIds.Add(mealId.ToString());
            }
            response.Ingredients.Add(ingredientProto);
        }
        return response;
    }
    public override async Task<GetIngredientResponse> GetIngredient(GetIngredientRequest request,
        ServerCallContext context)
    {
        var id = Guid.Parse(request.Id);
        var ingredient = await _mediator.Send(new GetIngredientQuery(id));
        var ingredientProto = _mapper.Map<IngredientProto>(ingredient);
        foreach (var mealId in ingredient.MealsIds)
        {
            ingredientProto.MealsIds.Add(mealId.ToString());
        }
        var response = new GetIngredientResponse()
        {
            Ingredient = ingredientProto
        };
        return response;
    }
    public override async Task<CreateIngredientResponse> CreateIngredient(CreateIngredientRequest request,
        ServerCallContext context)
    {
        var createIngredientDto = _mapper.Map<CreateIngredientDTO>(request.Ingredient);
        var ingredient = await _mediator.Send(new CreateIngredientCommand(createIngredientDto));
        var ingredientProto = _mapper.Map<IngredientProto>(ingredient);

        foreach (var mealId in ingredient.MealsIds)
        {
            ingredientProto.MealsIds.Add(mealId.ToString());
        }
        var response = new CreateIngredientResponse()
        {
            Ingredient = ingredientProto
        };
        return response;
    }
    public override async Task<UpdateIngredientResponse> UpdateIngredient(UpdateIngredientRequest request,
        ServerCallContext context)
    {
        var createIngredientDto = _mapper.Map<UpdateIngredientDTO>(request.Ingredient);
        var ingredient = await _mediator.Send(new UpdateIngredientCommand(createIngredientDto));
        var ingredientProto = _mapper.Map<IngredientProto>(ingredient);

        foreach (var mealId in ingredient.MealsIds)
        {
            ingredientProto.MealsIds.Add(mealId.ToString());
        }
        var response = new UpdateIngredientResponse()
        {
            Ingredient = ingredientProto
        };
        return response;
    }
    public override async Task<DeleteIngredientResponse> DeleteIngredient(DeleteIngredientRequest request,
        ServerCallContext context)
    {
        var id = Guid.Parse(request.Id);
        await _mediator.Send(new DeleteIngredientCommand(id));
        return new DeleteIngredientResponse();
    }
}