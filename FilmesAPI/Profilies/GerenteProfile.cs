using AutoMapper;
using FilmesAPI.Dto;
using FilmesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Profilies
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<GerenteDto, Gerente>();
            CreateMap<List<Gerente>, List<GerenteDto>>();
            CreateMap<Gerente, GerenteDto>()
                .ForMember(gerente => gerente.Cinemas, 
                opts => opts.MapFrom(gerente => gerente.Cinemas.Select
                ( cinema => new { cinema.Id, cinema.Nome, cinema.Endereco, cinema.EnderecoId} )));
        }
    }
}
