using IranKish.UrlShortener.Domain.Entities.UrlEntries.Exceptions;
using IranKish.UrlShortener.Endpoints.WebApi.ApiResponses;
using IranKish.UrlShortener.Services.Dtos;
using IranKish.UrlShortener.Services.Interfaces;
using IranKish.UrlShortener.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace IranKish.UrlShortener.Endpoints.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlShortenerController : ControllerBase
    {
        private readonly IUrlShortenerService _urlShortenerService;

        public UrlShortenerController(IUrlShortenerService urlShortenerService)
        {
            _urlShortenerService = urlShortenerService;
        }

        [HttpPost]
        public async Task<IActionResult> ShortenUrl([FromBody] ShortenUrlRequestDto requestDto)
        { 

                var shortUrl = await _urlShortenerService.ShortenUrlAsync(requestDto);
                return Ok(ApiResponse<ShortenUrlResultDto>.SuccessResponse(shortUrl));
             

        }

        [HttpGet()]
        public async Task<IActionResult> GetOriginalUrl([FromQuery] string shortenedUrl)
        {
                var originalUrl = await _urlShortenerService.GetOriginalUrlAsync(shortenedUrl);
                return Ok(ApiResponse<GetOriginalUrlResponseDto>.SuccessResponse(originalUrl));
            
        }
    }
}
