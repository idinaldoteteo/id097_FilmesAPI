using AutoMapper;
using FilmesAPI.Dto;
using FilmesAPI.Models;

namespace FilmesAPI.Profilies
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<SessaoDto, Sessao>();
            CreateMap<Sessao, SessaoDto>()
                .ForMember(dto => dto.horarioDeInicio, 
                opts => opts.MapFrom(dto => dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao * -1)));
        }
    }
}
