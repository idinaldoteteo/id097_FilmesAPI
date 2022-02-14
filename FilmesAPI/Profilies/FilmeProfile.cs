using AutoMapper;
using FilmesAPI.Dto;
using FilmesAPI.Models;

namespace FilmesAPI.Profilies
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<FilmeDto, Filme>();
            CreateMap<Filme, FilmeDto>();
        }
    }
}
