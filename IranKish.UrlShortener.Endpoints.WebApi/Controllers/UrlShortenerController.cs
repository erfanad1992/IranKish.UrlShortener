using Microsoft.AspNetCore.Mvc;

namespace IranKish.UrlShortener.Endpoints.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlShortenerController
    {
        [HttpPost]
        public async Task<IActionResult> ShortenUrl([FromBody] string url)
        {
            var shortUrl = await _urlShortenerService.ShortenUrlAsync(url);
            return Ok(new { ShortUrl = $"https://yourdomain.com/{shortUrl}" });
        }

        [HttpGet("{shortUrlCode}")]
        public async Task<IActionResult> RedirectToOriginalUrl(string shortUrlCode)
        {
            var originalUrl = await _urlShortenerService.GetOriginalUrlAsync(shortUrlCode);
            if (originalUrl == null)
                return NotFound();

            return Redirect(originalUrl);
        }
    }
}
