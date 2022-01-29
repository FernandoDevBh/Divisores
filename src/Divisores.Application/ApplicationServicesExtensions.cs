using MediatR;
using FluentValidation;
using System.Reflection;
using Divisores.Application.Behaviours;
using Microsoft.Extensions.DependencyInjection;

namespace Divisores.Application;

public static class ApplicationServicesExtensions
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services)
  {
    services.AddAutoMapper(Assembly.GetExecutingAssembly());
    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidacaoBehaviour<,>));

    services.AddMediatR(Assembly.GetExecutingAssembly());

    return services;
  }
}

