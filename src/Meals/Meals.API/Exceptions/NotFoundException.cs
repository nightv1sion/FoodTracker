namespace src.Meals.Meals.API.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        { }
    }
}
