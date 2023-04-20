namespace src.WorkoutTracker.API.Exceptions.Contracts
{
    public class TrainingNotFoundException : NotFoundException
    {
        public TrainingNotFoundException(Guid id)
            : base($"Training with id: {id} not found")
        { }
    }
}
