using AutoMapper;
using FilmesAPI.Dto;
using FilmesAPI.Models;

namespace FilmesAPI.Profilies
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<Cinema, CinemaDto>();

            CreateMap<CinemaDto, Cinema>();
        }
    }
}
