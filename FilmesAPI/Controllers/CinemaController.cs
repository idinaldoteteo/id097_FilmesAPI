using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Dto;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private AppDbContext _cinemaContext;
        private IMapper _mapper;

        public CinemaController(AppDbContext cinemaContext, IMapper autoMapper)
        {
            this._cinemaContext = cinemaContext;
            this._mapper = autoMapper;
        }

        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string nomeDoFilme)
        {
            List<Cinema> cinemas = _cinemaContext.Cinemas.ToList();
            if( cinemas.Count == 0)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessoes.Any(
                                                sessao => sessao.Filme.Titulo.Equals(nomeDoFilme))
                                            select cinema;
                cinemas = query.ToList();
            }

            List<CinemaDto> cinemaDtoList = _mapper.Map<List<CinemaDto>>(cinemas);

            return Ok(cinemaDtoList);
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _cinemaContext.Cinemas.Add(cinema);
            _cinemaContext.SaveChanges();

            return CreatedAtAction(nameof(RecuperarCinemaById), new { Id = cinema.Id }, cinema);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinemaById(int id)
        {
            Cinema cinema = _cinemaContext.Cinemas.FirstOrDefault(Cinema => Cinema.Id == id);
            if( cinema == null)
            {
                return NotFound();
            }

            CinemaDto cinemaDto = _mapper.Map<CinemaDto>(cinema);
            return Ok(cinemaDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] CinemaDto cinemaDto)
        {
            Cinema cinema = _cinemaContext.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if( cinema == null)
            {
                return NotFound();

            }

            _mapper.Map(cinemaDto, cinema);
            _cinemaContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Cinema cinema = _cinemaContext.Cinemas.FirstOrDefault(Cinema => Cinema.Id == id);
            if( cinema == null)
            {
                return NotFound();
            }

            _cinemaContext.Remove(cinema);
            _cinemaContext.SaveChanges();
            return NoContent();
        }
    }
}
