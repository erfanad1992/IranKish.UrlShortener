using IranKish.UrlShortener.ServiceImplementations.Services;
using IranKish.UrlShortener.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IranKish.UrlShortener.ServiceImplementations.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddImplementationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUrlShortenerService, UrlShortenerService>();
        }
    }
}
