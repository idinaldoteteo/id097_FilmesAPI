using FilmesAPI.Dto;
using FilmesAPI.Models;
using FluentResults;
using System.Collections.Generic;

namespace FilmesAPI.Services
{
    public interface ICinemaService
    {
        List<CinemaDto> RecuperarCinemas(string nomeDoFilme);
        CinemaDto AdicionarCinema(CinemaDto cinemaDto);
        CinemaDto RecuperarCinemaById(int id);
        Result AtualizarCinema(int id, CinemaDto cinemaDto);
        Result DeletarCinema(int id);
    }
}
