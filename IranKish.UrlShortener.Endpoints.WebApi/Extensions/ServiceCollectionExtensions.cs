using IranKish.UrlShortener.Persistance.Ef.Extensions;
using IranKish.UrlShortener.ServiceImplementations.Extensions;
using IranKish.UrlShortener.ServiceImplementations.Services;
using IranKish.UrlShortener.Services.Interfaces;

namespace IranKish.UrlShortener.Endpoints.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddPresistanceEFServices(configuration);
            services.AddImplementationServices(configuration);

        }

    }
}
