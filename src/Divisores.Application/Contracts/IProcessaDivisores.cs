using Divisores.Domain.Models;

namespace Divisores.Application.Contracts;

public interface IProcessaDivisores
{
  ResultadoDivisores ObterDivisores(int numero);
}
