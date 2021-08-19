using AutoMapper;
using Investimentos.Application.Dtos;
using Investimentos.Domain;

namespace Investimentos.Application.Helpers
{
    public class InvestimentoProfile : Profile
    {
        public InvestimentoProfile()
        {
            CreateMap<Ativo, AtivoDto>().ReverseMap();
            CreateMap<Transacao, TransacaoDto>().ReverseMap();
        }
    }
}