using FilmesAPI.Dto;
using FilmesAPI.Models;
using System.Collections.Generic;

namespace FilmesAPI.Services
{
    public interface ICinemaService
    {
        List<CinemaDto> RecuperarCinemas(string nomeDoFilme);
        CinemaDto AdicionarCinema(CinemaDto cinemaDto);
        CinemaDto RecuperarCinemaById(int id);
        CinemaDto AtualizarCinema(int id, CinemaDto cinemaDto);
        CinemaDto DeletarCinema(int id);
    }
}
