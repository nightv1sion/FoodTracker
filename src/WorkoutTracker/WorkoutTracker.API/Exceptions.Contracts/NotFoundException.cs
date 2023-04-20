namespace src.WorkoutTracker.API.Exceptions.Contracts
{
    public abstract class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        { }
    }
}
