namespace IranKish.UrlShortener.Domain.Entities.UrlEntries;

public class UrlEntry
{
    public UrlEntry(string originalUrl, string shortUrlCode, DateTime createdAt, int accessCount)
    {
        OriginalUrl = originalUrl;
        ShortUrlCode = shortUrlCode;
        CreatedAt = createdAt;
        AccessCount = accessCount;
    }

    public int Id { get; private set; }
    public string OriginalUrl { get; private set; }
    public string ShortUrlCode { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public int AccessCount { get; private set; }
    public void UpdateAccessCout()
    {
        AccessCount = AccessCount + 1;
    }
}
