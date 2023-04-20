using Microsoft.EntityFrameworkCore;
using src.WorkoutTracker.API.Entities;
using src.WorkoutTracker.API.Repository.Contracts;

namespace src.WorkoutTracker.API.Repository
{
    public class TrainingRepository : RepositoryBase<Training>, ITrainingRepository
    {
        public TrainingRepository(RepositoryContext context) : base(context) { }

        public void CreateTraining(Training training) => Create(training);

        public void DeleteTraining(Training training) => Delete(training);

        public async Task<Training> GetTrainingAsync(Guid trainingId, bool trackChanges)
            => await FindByCondition(x => x.Id == trainingId, trackChanges).FirstOrDefaultAsync();

        public IQueryable<Training> GetTrainings(bool trackChanges)
            => FindAll(trackChanges);

        public void UpdateTraining(Training training) => Update(training);
    }
}