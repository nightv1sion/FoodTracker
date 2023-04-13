namespace src.WorkoutTracker.API.Exceptions.Contracts
{
    public class CompletedExerciseNotFoundException : NotFoundException
    {
        public CompletedExerciseNotFoundException(Guid id)
            : base($"Competed exercise with id: {id} not found")
        { }
    }
}
