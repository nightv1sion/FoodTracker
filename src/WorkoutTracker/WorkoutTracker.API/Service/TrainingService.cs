using AutoMapper;
using Microsoft.EntityFrameworkCore;
using src.WorkoutTracker.API.DataTransferObjects.Training;
using src.WorkoutTracker.API.Entities;
using src.WorkoutTracker.API.Exceptions.Contracts;
using src.WorkoutTracker.API.Repository.Contracts;
using src.WorkoutTracker.API.Service.Contracts;

namespace src.WorkoutTracker.API.Service;
public class TrainingService : ITrainingService
{
    private readonly ITrainingRepository _trainingRepository;
    private readonly IMapper _mapper;

    public TrainingService(
        IMapper mapper,
        ITrainingRepository trainingRepository)
    {
        _trainingRepository = trainingRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<TrainingDTO>> GetTrainingsAsync(bool trackChanges)
    {
        var entities = _trainingRepository.GetTrainings(trackChanges)
            .Include(x => x.CompletedExercises);
        var dtos = _mapper.Map<IEnumerable<TrainingDTO>>(entities);
        return dtos;
    }

    public async Task<TrainingDTO> GetTrainingAsync(Guid id, bool trackChanges)
    {
        var entity = await GetTrainingAndCheckIfItExistsAsync(id, trackChanges);
        var dto = _mapper.Map<TrainingDTO>(entity);
        return dto;
    }
    public async Task<TrainingDTO> CreateTrainingAsync(CreateTrainingDTO dto)
    {
        var entity = _mapper.Map<Training>(dto);
        _trainingRepository.CreateTraining(entity);
        await _trainingRepository.SaveChangesAsync();
        var exercise = _mapper.Map<TrainingDTO>(entity);
        return exercise;
    }
    public async Task<TrainingDTO> UpdateTrainingAsync(UpdateTrainingDTO dto)
    {
        var entity = await GetTrainingAndCheckIfItExistsAsync(dto.Id, false);
        entity = _mapper.Map<UpdateTrainingDTO, Training>(dto);
        _trainingRepository.UpdateTraining(entity);
        await _trainingRepository.SaveChangesAsync();
        var exercise = _mapper.Map<TrainingDTO>(entity);
        return exercise;
    }
    public async Task DeleteTrainingAsync(Guid id)
    {
        var entity = await GetTrainingAndCheckIfItExistsAsync(id, false);
        _trainingRepository.DeleteTraining(entity);
        await _trainingRepository.SaveChangesAsync();
    }
    private async Task<Training> GetTrainingAndCheckIfItExistsAsync(Guid id, bool trackChanges)
    {
        var entity = await _trainingRepository.GetTrainingAsync(id, trackChanges);
        if (entity == null)
        {
            throw new TrainingNotFoundException(id);
        }
        return entity;
    }
}