using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using src.WorkoutTracker.API.DataTransferObjects.CompletedExercise;

namespace src.WorkoutTracker.API.Service.Contracts
{
    public interface ICompletedExerciseService
    {
        Task<IEnumerable<CompletedExerciseDTO>> GetCompletedExercisesAsync(bool trackChanges);
        Task<CompletedExerciseDTO> GetCompletedExerciseAsync(Guid id, bool trackChanges);
        Task<CompletedExerciseDTO> CreateCompletedExerciseAsync(CreateCompletedExerciseDTO dto);
        Task<CompletedExerciseDTO> UpdateCompletedExerciseAsync(UpdateCompletedExerciseDTO dto);
        Task DeleteCompletedExerciseAsync(Guid id);
    }
}