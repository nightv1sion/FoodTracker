using src.WorkoutTracker.API.Entities;

namespace src.WorkoutTracker.API.Repository.Contracts
{
    public interface ICompletedExerciseRepository
    {
        void CreateCompletedExercise(CompletedExercise completedExercise);
        IQueryable<CompletedExercise> GetCompletedExercises(bool trackChanges);
        Task<CompletedExercise> GetCompletedExerciseAsync(Guid completedExerciseId, bool trackChanges);
        void DeleteCompletedExercise(CompletedExercise completedExercise);
        void UpdateCompletedExercise(CompletedExercise completedExercise);
        Task SaveChangesAsync();
    }
}