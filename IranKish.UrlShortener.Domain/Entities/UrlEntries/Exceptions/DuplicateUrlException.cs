namespace IranKish.UrlShortener.Domain.Entities.UrlEntries.Exceptions
{
    public class DuplicateUrlException : Exception
    {
        public DuplicateUrlException(string message) : base(message)
        {
        }
    }
}
