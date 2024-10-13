namespace IranKish.UrlShortener.Services.Interfaces
{
    public interface IUrlShortenerService
    {
        Task<string> ShortenUrlAsync(string originalUrl);
        Task<string?> GetOriginalUrlAsync(string shortUrlCode);
    }
}
