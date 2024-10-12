namespace IranKish.UrlShortener.Domain.Entities;

public class UrlEntry
{
    public int Id { get; set; }
    public string OriginalUrl { get; set; }
    public string ShortUrlCode { get; set; }
    public DateTime CreatedAt { get; set; }
    public int AccessCount { get; set; }
}
