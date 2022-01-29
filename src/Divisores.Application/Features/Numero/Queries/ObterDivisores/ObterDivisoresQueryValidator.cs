using FluentValidation;

namespace Divisores.Application.Features.Numero.Queries.ObterDivisores;

public class ObterDivisoresQueryValidator : AbstractValidator<ObterDivisoresQuery>
{
  public ObterDivisoresQueryValidator()
  {
    RuleFor(c => c.Numero)
        .NotEmpty().WithMessage("{Numero} é Obrigatório.")
        .GreaterThan(0).WithMessage("{Numero} Deve ser maior que zero."); ;
  }
}

