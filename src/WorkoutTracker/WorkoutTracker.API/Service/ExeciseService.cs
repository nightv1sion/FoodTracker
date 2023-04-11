using AutoMapper;
using Microsoft.EntityFrameworkCore;
using src.WorkoutTracker.API.DataTransferObjects.Exercise;
using src.WorkoutTracker.API.Entities;
using src.WorkoutTracker.API.Repository;
using src.WorkoutTracker.API.Service.Contracts;

namespace src.WorkoutTracker.API.Service;
public class ExerciseService : IExerciseService
{
    private readonly RepositoryContext _context;
    private readonly IMapper _mapper;

    public ExerciseService(
        RepositoryContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ExerciseDTO>> GetExercisesAsync(bool trackChanges)
    {
        var entities = await _context.Exercises.ToListAsync();
        var dtos = _mapper.Map<IEnumerable<ExerciseDTO>>(entities);
        return dtos;
    }

    public async Task<ExerciseDTO> GetExerciseAsync(Guid id, bool trackChanges)
    {
        var entity = await _context.Exercises.FirstOrDefaultAsync(x => x.Id == id);
        var dto = _mapper.Map<ExerciseDTO>(entity);
        return dto;
    }
    public async Task<ExerciseDTO> CreateExerciseAsync(CreateExerciseDTO dto)
    {
        var entity = _mapper.Map<Exercise>(dto);
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        var exercise = _mapper.Map<ExerciseDTO>(entity);
        return exercise;
    }
    public async Task<ExerciseDTO> UpdateExerciseAsync(UpdateExerciseDTO dto)
    {
        var entity = _mapper.Map<Exercise>(dto);
        _context.Update(entity);
        await _context.SaveChangesAsync();
        var exercise = _mapper.Map<ExerciseDTO>(entity);
        return exercise;
    }
    public async Task DeleteExerciseAsync(Guid id)
    {
        var entity = _context.Exercises.FirstOrDefaultAsync(x => x.Id == id);
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }
}