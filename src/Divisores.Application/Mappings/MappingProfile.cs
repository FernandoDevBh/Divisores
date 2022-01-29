using AutoMapper;
using Divisores.Domain.Models;
using Divisores.Application.Features.Numero.Queries.ObterDivisores;

namespace Divisores.API.Mappings;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<ResultadoDivisores, ResultadoDivisoresDto>().ReverseMap();
  }
}

