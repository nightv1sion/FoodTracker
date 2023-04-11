using src.WorkoutTracker.API.Entities;

namespace src.WorkoutTracker.API.Repository.Contracts
{
    public interface ITrainingRepository
    {
        void CreateTraining(Training training);
        IQueryable<Training> GetTrainings(bool trackChanges);
        Task<Training> GetTrainingAsync(Guid trainingId, bool trackChanges);
        void DeleteTraining(Training training);
        void UpdateTraining(Training training);
        Task SaveChangesAsync();
    }
}