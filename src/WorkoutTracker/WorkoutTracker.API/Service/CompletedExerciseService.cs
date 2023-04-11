using AutoMapper;
using Microsoft.EntityFrameworkCore;
using src.WorkoutTracker.API.DataTransferObjects.CompletedExercise;
using src.WorkoutTracker.API.Entities;
using src.WorkoutTracker.API.Repository;
using src.WorkoutTracker.API.Service.Contracts;

namespace src.WorkoutTracker.API.Service;
public class CompletedExerciseService : ICompletedExerciseService
{
    private readonly RepositoryContext _context;
    private readonly IMapper _mapper;

    public CompletedExerciseService(
        RepositoryContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<CompletedExerciseDTO>> GetCompletedExercisesAsync(bool trackChanges)
    {
        var entities = await _context.CompletedExercises.ToListAsync();
        var dtos = _mapper.Map<IEnumerable<CompletedExerciseDTO>>(entities);
        return dtos;
    }

    public async Task<CompletedExerciseDTO> GetCompletedExerciseAsync(Guid id, bool trackChanges)
    {
        var entity = await _context.CompletedExercises.FirstOrDefaultAsync(x => x.Id == id);
        var dto = _mapper.Map<CompletedExerciseDTO>(entity);
        return dto;
    }
    public async Task<CompletedExerciseDTO> CreateCompletedExerciseAsync(CreateCompletedExerciseDTO dto)
    {
        var entity = _mapper.Map<CompletedExercise>(dto);
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        var exercise = _mapper.Map<CompletedExerciseDTO>(entity);
        return exercise;
    }
    public async Task<CompletedExerciseDTO> UpdateCompletedExerciseAsync(UpdateCompletedExerciseDTO dto)
    {
        var entity = _mapper.Map<CompletedExercise>(dto);
        _context.Update(entity);
        await _context.SaveChangesAsync();
        var exercise = _mapper.Map<CompletedExerciseDTO>(entity);
        return exercise;
    }
    public async Task DeleteCompletedExerciseAsync(Guid id)
    {
        var entity = _context.CompletedExercises.FirstOrDefaultAsync(x => x.Id == id);
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }
}