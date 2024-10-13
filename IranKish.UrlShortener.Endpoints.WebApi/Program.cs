using IranKish.UrlShortener.Endpoints.WebApi.Extensions;
using IranKish.UrlShortener.Endpoints.WebApi.Middlewares;
using IranKish.UrlShortener.Persistance.Ef.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.ConfigureServices(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();  
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
