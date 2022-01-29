using Divisores.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Divisores.Processamento;

public static class ProcessamentoServicesExtensions
{
  public static IServiceCollection AddProcessamentoServices(this IServiceCollection services)
  {
    services.AddScoped<IProcessaMultiplicadores, ProcessaMultiplicadores>();
    services.AddScoped<IProcessaNumerosPrimos, ProcessaNumerosPrimos>();
    services.AddScoped<IProcessaDivisores, ProcessaDivisores>();
    return services;
  }
}

