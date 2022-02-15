using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Dto;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
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
        public IEnumerable RecuperarFilmes()
        {
            return _cinemaContext.Cinemas;
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _cinemaContext.Cinemas.Add(cinema);
            _cinemaContext.SaveChanges();

            return CreatedAtAction(nameof(RecuperarFilmeById), new { Id = cinema.Id }, cinema);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmeById(int id)
        {
            Cinema cinema = _cinemaContext.Cinemas.FirstOrDefault(Cinema => Cinema.Id == id);
            if( cinema != null)
            {
                CinemaDto cinemaDto = _mapper.Map<CinemaDto>(cinema);
                return Ok(cinemaDto);
            }
            return NotFound();
        }
    }
}
