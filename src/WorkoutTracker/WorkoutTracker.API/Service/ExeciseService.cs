using AutoMapper;
using Microsoft.EntityFrameworkCore;
using src.WorkoutTracker.API.DataTransferObjects.Exercise;
using src.WorkoutTracker.API.Entities;
using src.WorkoutTracker.API.Exceptions.Contracts;
using src.WorkoutTracker.API.Repository;
using src.WorkoutTracker.API.Repository.Contracts;
using src.WorkoutTracker.API.Service.Contracts;

namespace src.WorkoutTracker.API.Service;
public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IMapper _mapper;

    public ExerciseService(
        IMapper mapper,
        IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ExerciseDTO>> GetExercisesAsync(bool trackChanges)
    {
        var entities = _exerciseRepository.GetExercises(trackChanges);
        var dtos = _mapper.Map<IEnumerable<ExerciseDTO>>(entities);
        return dtos;
    }

    public async Task<ExerciseDTO> GetExerciseAsync(Guid id, bool trackChanges)
    {
        var entity = await GetExerciseAndCheckIfItExistsAsync(id, trackChanges);
        var dto = _mapper.Map<ExerciseDTO>(entity);
        return dto;
    }
    public async Task<ExerciseDTO> CreateExerciseAsync(CreateExerciseDTO dto)
    {
        var entity = _mapper.Map<Exercise>(dto);
        _exerciseRepository.CreateExercise(entity);
        await _exerciseRepository.SaveChangesAsync();
        var exercise = _mapper.Map<ExerciseDTO>(entity);
        return exercise;
    }
    public async Task<ExerciseDTO> UpdateExerciseAsync(UpdateExerciseDTO dto)
    {
        var entity = await GetExerciseAndCheckIfItExistsAsync(dto.Id, false);
        entity = _mapper.Map<UpdateExerciseDTO, Exercise>(dto, entity);
        _exerciseRepository.UpdateExercise(entity);
        await _exerciseRepository.SaveChangesAsync();
        var exercise = _mapper.Map<ExerciseDTO>(entity);
        return exercise;
    }
    public async Task DeleteExerciseAsync(Guid id)
    {
        var entity = await GetExerciseAndCheckIfItExistsAsync(id, false);
        _exerciseRepository.DeleteExercise(entity);
        await _exerciseRepository.SaveChangesAsync();
    }

    private async Task<Exercise> GetExerciseAndCheckIfItExistsAsync(Guid id, bool trackChanges)
    {
        var entity = await _exerciseRepository.GetExerciseAsync(id, trackChanges);
        if (entity == null)
        {
            throw new ExerciseNotFoundException(id);
        }
        return entity;
    }
}