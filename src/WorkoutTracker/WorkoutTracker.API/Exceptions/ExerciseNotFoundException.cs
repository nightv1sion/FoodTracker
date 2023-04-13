namespace src.WorkoutTracker.API.Exceptions.Contracts
{
    public class ExerciseNotFoundException : NotFoundException
    {
        public ExerciseNotFoundException(Guid id)
            : base($"Exercise with id: {id} not found")
        { }
    }
}
