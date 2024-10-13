using IranKish.UrlShortener.Domain.Entities.UrlEntries;
using IranKish.UrlShortener.Domain.Entities.UrlEntries.Exceptions;
using IranKish.UrlShortener.Persistance.Ef.DbContexts;
using IranKish.UrlShortener.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IranKish.UrlShortener.ServiceImplementations.Services
{
    public class UrlShortenerService : IUrlShortenerService
    {
        private readonly ApplicationDbContext _dbContext;

        public UrlShortenerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> GetOriginalUrlAsync(string shortUrlCode)
        {
            var urlEntry = await _dbContext.Urls.FirstOrDefaultAsync(x => x.ShortUrlCode == shortUrlCode);
            if (urlEntry is not null)
            {
                urlEntry.UpdateAccessCout();
                await _dbContext.SaveChangesAsync();
                return urlEntry.OriginalUrl;
            }
            throw new NotFoundException("The requested short URL does not exist.");

        }

        public async Task<string> ShortenUrlAsync(string originalUrl)
        {
            var newUrlEntry = new UrlEntry
                (
                 originalUrl,
                 GenerateShortCode(),
                 DateTime.Now,
                 0
                );
            _dbContext.Add(newUrlEntry);
            await _dbContext.SaveChangesAsync();
            return newUrlEntry.ShortUrlCode;
        }
        private string GenerateShortCode()
        {
            return Guid.NewGuid().ToString().Substring(0, 6);
        }
    }
}
