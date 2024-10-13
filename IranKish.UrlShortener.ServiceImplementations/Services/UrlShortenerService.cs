using IranKish.UrlShortener.Domain.Entities.UrlEntries;
using IranKish.UrlShortener.Domain.Entities.UrlEntries.Exceptions;
using IranKish.UrlShortener.Persistance.Ef.DbContexts;
using IranKish.UrlShortener.Services.Dtos;
using IranKish.UrlShortener.Services.Interfaces;
using IranKish.UrlShortener.Services.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace IranKish.UrlShortener.ServiceImplementations.Services
{
    public class UrlShortenerService : IUrlShortenerService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private const string NOT_FOUND_EXCEPTIOn_MESSAGE = "آدرس درخواستی یافت نشد";
        private const string DUPLICATE_URL_EXCEPTION_MESSAGE = "آدرس درخواستی تکراری است .";


        public UrlShortenerService(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<GetOriginalUrlResponseDto> GetOriginalUrlAsync(string shortenedUrl)
        {
            var urlEntry = await _dbContext.Urls.FirstOrDefaultAsync(x => x.ShortUrlCode == shortenedUrl);
            if (urlEntry is not null)
            {
                urlEntry.UpdateAccessCout();
                await _dbContext.SaveChangesAsync();
                return new GetOriginalUrlResponseDto
                {
                    MainUrl = urlEntry.OriginalUrl
                };
            }
            throw new NotFoundException(NOT_FOUND_EXCEPTIOn_MESSAGE);

        }

        public async Task<ShortenUrlResultDto> ShortenUrlAsync(ShortenUrlRequestDto requestDto)
        {
            var isExistShortenedUrl = _dbContext.Urls.Any(x => x.OriginalUrl == requestDto.MainUrl);
            if (!isExistShortenedUrl)
            {
                var urlScheme = _configuration.GetSection("UrlScheme").Value;
                var shortenedUrl = urlScheme + GenerateShortCode();
                var newUrlEntry = new UrlEntry
                    (
                     requestDto.MainUrl,
                     shortenedUrl,
                     DateTime.Now,
                     0
                    );
                _dbContext.Add(newUrlEntry);
                await _dbContext.SaveChangesAsync();
                return new ShortenUrlResultDto
                {
                    ShortenedUrl = shortenedUrl,
                };
            }
            throw new DuplicateUrlException(DUPLICATE_URL_EXCEPTION_MESSAGE);

        }
        private string GenerateShortCode()
        {
            return Guid.NewGuid().ToString().Substring(0, 6);
        }
    }
}
