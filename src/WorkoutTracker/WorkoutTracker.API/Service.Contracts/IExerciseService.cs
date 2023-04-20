using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using src.WorkoutTracker.API.DataTransferObjects.Exercise;

namespace src.WorkoutTracker.API.Service.Contracts
{
    public interface IExerciseService
    {
        Task<IEnumerable<ExerciseDTO>> GetExercisesAsync(bool trackChanges);
        Task<ExerciseDTO> GetExerciseAsync(Guid id, bool trackChanges);
        Task<ExerciseDTO> CreateExerciseAsync(CreateExerciseDTO dto);
        Task<ExerciseDTO> UpdateExerciseAsync(UpdateExerciseDTO dto);
        Task DeleteExerciseAsync(Guid id);
    }
}