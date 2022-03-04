using AutoMapper;
using FilmesAPI.Controllers;
using FilmesAPI.Dto;
using FilmesAPI.Models;
using System.Collections.Generic;

namespace FilmesAPI.Profilies
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<EnderecoDto, Endereco>();
            CreateMap<Endereco, EnderecoDto>();
            CreateMap<List<EnderecoDto>, List<Endereco>>();
        }
    }
}
