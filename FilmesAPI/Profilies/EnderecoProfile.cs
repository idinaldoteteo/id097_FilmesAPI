using AutoMapper;
using FilmesAPI.Controllers;
using FilmesAPI.Dto;
using FilmesAPI.Models;

namespace FilmesAPI.Profilies
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<EnderecoDto, Endereco>();
            CreateMap<Endereco, EnderecoDto>();
        }
    }
}
