using AutoMapper;
using Microsoft.EntityFrameworkCore;
using src.WorkoutTracker.API.DataTransferObjects.Training;
using src.WorkoutTracker.API.Entities;
using src.WorkoutTracker.API.Repository;
using src.WorkoutTracker.API.Service.Contracts;

namespace src.WorkoutTracker.API.Service;
public class TrainingService : ITrainingService
{
    private readonly RepositoryContext _context;
    private readonly IMapper _mapper;

    public TrainingService(
        RepositoryContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<TrainingDTO>> GetTrainingsAsync(bool trackChanges)
    {
        var entities = await _context.Trainings.ToListAsync();
        var dtos = _mapper.Map<IEnumerable<TrainingDTO>>(entities);
        return dtos;
    }

    public async Task<TrainingDTO> GetTrainingAsync(Guid id, bool trackChanges)
    {
        var entity = await _context.Trainings.FirstOrDefaultAsync(x => x.Id == id);
        var dto = _mapper.Map<TrainingDTO>(entity);
        return dto;
    }
    public async Task<TrainingDTO> CreateTrainingAsync(CreateTrainingDTO dto)
    {
        var entity = _mapper.Map<Training>(dto);
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        var exercise = _mapper.Map<TrainingDTO>(entity);
        return exercise;
    }
    public async Task<TrainingDTO> UpdateTrainingAsync(UpdateTrainingDTO dto)
    {
        var entity = _mapper.Map<Training>(dto);
        _context.Update(entity);
        await _context.SaveChangesAsync();
        var exercise = _mapper.Map<TrainingDTO>(entity);
        return exercise;
    }
    public async Task DeleteTrainingAsync(Guid id)
    {
        var entity = _context.Trainings.FirstOrDefaultAsync(x => x.Id == id);
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }
}