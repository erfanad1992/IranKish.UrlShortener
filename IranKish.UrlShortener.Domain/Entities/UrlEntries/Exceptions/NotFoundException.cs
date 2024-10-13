namespace IranKish.UrlShortener.Domain.Entities.UrlEntries.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
