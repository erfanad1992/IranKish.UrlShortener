using IranKish.UrlShortener.Services.Dtos;
using IranKish.UrlShortener.Services.Models;

namespace IranKish.UrlShortener.Services.Interfaces
{
    public interface IUrlShortenerService
    {
        Task<ShortenUrlResultDto> ShortenUrlAsync(ShortenUrlRequestDto requestDto);
        Task<GetOriginalUrlResponseDto?> GetOriginalUrlAsync(string shortenedUrl);
    }
}
