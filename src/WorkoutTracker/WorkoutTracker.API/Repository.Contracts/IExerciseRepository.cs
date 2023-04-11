using src.WorkoutTracker.API.Entities;

namespace src.WorkoutTracker.API.Repository.Contracts
{
    public interface IExerciseRepository
    {
        void CreateExercise(Exercise exercise);
        IQueryable<Exercise> GetExercises(bool trackChanges);
        Task<Exercise> GetExerciseAsync(Guid exerciseId, bool trackChanges);
        void DeleteExercise(Exercise exercise);
        void UpdateExercise(Exercise exercise);
        Task SaveChangesAsync();
    }
}