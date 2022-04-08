using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Dto;
using FilmesAPI.Models;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly AppDbContext _cinemaContext;
        private readonly IMapper _mapper;

        public CinemaService(AppDbContext cinemaContext, IMapper autoMapper)
        {
            this._cinemaContext = cinemaContext;
            this._mapper = autoMapper;
        }

        public CinemaDto AdicionarCinema(CinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _cinemaContext.Cinemas.Add(cinema);
            _cinemaContext.SaveChanges();

            return _mapper.Map<CinemaDto>(cinema);
        }

        public Result AtualizarCinema(int id, CinemaDto cinemaDto)
        {
            Cinema cinema = _cinemaContext.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return Result.Fail("Cinema não encontrado.");
            }

            _mapper.Map(cinemaDto, cinema);
            _cinemaContext.SaveChanges();

            return Result.Ok();
        }

        public Result DeletarCinema(int id)
        {
            Cinema cinema = _cinemaContext.Cinemas.FirstOrDefault(Cinema => Cinema.Id == id);
            
            if (cinema == null)
            {
                return Result.Fail("Cinema não encontrado.");
            }

            _cinemaContext.Remove(cinema);
            _cinemaContext.SaveChanges();

            return Result.Ok();
        }

        public CinemaDto RecuperarCinemaById(int id)
        {
            Cinema cinema = _cinemaContext.Cinemas.FirstOrDefault(Cinema => Cinema.Id == id);
            if (cinema == null)
            {
                return null;
            }

            return _mapper.Map<CinemaDto>(cinema);
        }

        public List<CinemaDto> RecuperarCinemas(string nomeDoFilme)
        {
            List<Cinema> cinemas = _cinemaContext.Cinemas.ToList();
            if (!cinemas.Any())
            {
                return new List<CinemaDto>();
            }

            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessoes.Any(
                                                sessao => sessao.Filme.Titulo.Equals(nomeDoFilme))
                                            select cinema;
                cinemas = query.ToList();
            }

            return _mapper.Map<List<CinemaDto>>(cinemas);
        }
    }
}
