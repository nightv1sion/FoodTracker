using AutoMapper;
using Microsoft.EntityFrameworkCore;
using src.WorkoutTracker.API.DataTransferObjects.CompletedExercise;
using src.WorkoutTracker.API.Entities;
using src.WorkoutTracker.API.Exceptions.Contracts;
using src.WorkoutTracker.API.Repository;
using src.WorkoutTracker.API.Repository.Contracts;
using src.WorkoutTracker.API.Service.Contracts;

namespace src.WorkoutTracker.API.Service;
public class CompletedExerciseService : ICompletedExerciseService
{
    private readonly ICompletedExerciseRepository _completedExerciseRepository;
    private readonly IMapper _mapper;

    public CompletedExerciseService(
        IMapper mapper,
        ICompletedExerciseRepository completedExerciseRepository)
    {
        _completedExerciseRepository = completedExerciseRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<CompletedExerciseDTO>> GetCompletedExercisesAsync(bool trackChanges)
    {
        var entities = _completedExerciseRepository.GetCompletedExercises(trackChanges);
        var dtos = _mapper.Map<IEnumerable<CompletedExerciseDTO>>(entities);
        return dtos;
    }

    public async Task<CompletedExerciseDTO> GetCompletedExerciseAsync(Guid id, bool trackChanges)
    {
        var entity = await GetCompletedExerciseAndCheckIfItExistsAsync(id, trackChanges);
        var dto = _mapper.Map<CompletedExerciseDTO>(entity);
        return dto;
    }
    public async Task<CompletedExerciseDTO> CreateCompletedExerciseAsync(CreateCompletedExerciseDTO dto)
    {
        var entity = _mapper.Map<CompletedExercise>(dto);
        _completedExerciseRepository.CreateCompletedExercise(entity);
        await _completedExerciseRepository.SaveChangesAsync();
        var exercise = _mapper.Map<CompletedExerciseDTO>(entity);
        return exercise;
    }
    public async Task<CompletedExerciseDTO> UpdateCompletedExerciseAsync(UpdateCompletedExerciseDTO dto)
    {
        var entity = await GetCompletedExerciseAndCheckIfItExistsAsync(dto.Id, false);
        entity = _mapper.Map<UpdateCompletedExerciseDTO, CompletedExercise>(dto, entity);
        _completedExerciseRepository.UpdateCompletedExercise(entity);
        await _completedExerciseRepository.SaveChangesAsync();
        var exercise = _mapper.Map<CompletedExerciseDTO>(entity);
        return exercise;
    }
    public async Task DeleteCompletedExerciseAsync(Guid id)
    {
        var entity = await GetCompletedExerciseAndCheckIfItExistsAsync(id, false);
        _completedExerciseRepository.DeleteCompletedExercise(entity);
        await _completedExerciseRepository.SaveChangesAsync();
    }

    private async Task<CompletedExercise> GetCompletedExerciseAndCheckIfItExistsAsync(Guid id, bool trackChanges)
    {
        var entity = await _completedExerciseRepository.GetCompletedExerciseAsync(id, trackChanges);
        if (entity == null)
        {
            throw new CompletedExerciseNotFoundException(id);
        }
        return entity;
    }
}