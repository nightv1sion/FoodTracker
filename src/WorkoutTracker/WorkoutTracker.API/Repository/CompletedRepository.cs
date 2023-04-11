using Microsoft.EntityFrameworkCore;
using src.WorkoutTracker.API.Entities;
using src.WorkoutTracker.API.Repository.Contracts;

namespace src.WorkoutTracker.API.Repository
{
    public class CompletedExerciseRepository : RepositoryBase<CompletedExercise>, ICompletedExerciseRepository
    {
        public CompletedExerciseRepository(RepositoryContext context) : base(context) { }

        public void CreateCompletedExercise(CompletedExercise completedExercise) => Create(completedExercise);

        public void DeleteCompletedExercise(CompletedExercise completedExercise) => Delete(completedExercise);

        public async Task<CompletedExercise> GetCompletedExerciseAsync(Guid completedExerciseId, bool trackChanges)
            => await FindByCondition(x => x.Id == completedExerciseId, trackChanges).FirstOrDefaultAsync();

        public IQueryable<CompletedExercise> GetCompletedExercises(bool trackChanges)
            => FindAll(trackChanges);

        public void UpdateCompletedExercise(CompletedExercise completedExercise) => Update(completedExercise);
    }
}