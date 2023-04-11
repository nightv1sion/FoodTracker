using Microsoft.EntityFrameworkCore;
using src.WorkoutTracker.API.Entities;
using src.WorkoutTracker.API.Repository.Contracts;

namespace src.WorkoutTracker.API.Repository
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(RepositoryContext context) : base(context) { }

        public void CreateExercise(Exercise exercise) => Create(exercise);

        public void DeleteExercise(Exercise exercise) => Delete(exercise);

        public async Task<Exercise> GetExerciseAsync(Guid exerciseId, bool trackChanges)
            => await FindByCondition(x => x.Id == exerciseId, trackChanges).FirstOrDefaultAsync();

        public IQueryable<Exercise> GetExercises(bool trackChanges)
            => FindAll(trackChanges);

        public void UpdateExercise(Exercise exercise) => Update(exercise);
    }
}