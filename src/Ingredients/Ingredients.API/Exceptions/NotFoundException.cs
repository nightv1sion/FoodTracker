namespace src.Ingredients.Ingredients.API.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        { }
    }
}
