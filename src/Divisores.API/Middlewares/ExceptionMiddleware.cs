using System.Net;
using System.Text.Json;
using Divisores.API.Erros;
using Divisores.Application.Excecoes;

namespace Divisores.API.Middlewares;

public class ExceptionMiddleware
{
  private readonly RequestDelegate _next;
  private readonly ILogger<ExceptionMiddleware> _logger;
  private readonly IHostEnvironment _env;

  public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
  {
    _next = next;
    _logger = logger;
    _env = env;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    try
    {
      await _next(context);
    }
    catch (ValidationException ex)
    {
      _logger.LogError(ex, ex.Message);
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

      var options = new JsonSerializerOptions
      {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
      };

      var response = new ApiException(context.Response.StatusCode, ex.Message, ex.GetErros());

      var json = JsonSerializer.Serialize(response, options);

      await context.Response.WriteAsync(json);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, ex.Message);
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

      var response = _env.IsDevelopment() ?
                      new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString()) :
                      new ApiException(context.Response.StatusCode, "Internal Server Error");

      var options = new JsonSerializerOptions
      {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
      };

      var json = JsonSerializer.Serialize(response, options);

      await context.Response.WriteAsync(json);
    }
  }
}

