using Divisores.API.Helpers;

namespace Divisores.API.Extensions;

public static class CorsServiceExtensions
{
  public static string GetCorsPolicyName(this IServiceCollection services) => "MyAllowSpecificOrigins";

  public static IServiceCollection AddCorsService(this IServiceCollection services, IConfiguration config)
  {
    var origensValidas = config
                          .GetSection("CorsConfiguration")
                          .GetChildren()
                          .Select(x => x.Value)
                          .ToArray();
    services.AddCors(options =>
    {
      options.AddPolicy(name: services.GetCorsPolicyName(), builder =>
      {
        builder
          .WithOrigins(origensValidas)
          .AllowAnyHeader()
          .AllowCredentials()
          .AllowAnyMethod();
      });
    });
    return services;
  }
}

