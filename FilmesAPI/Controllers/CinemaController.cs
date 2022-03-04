using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Dto;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaService _cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            this._cinemaService = cinemaService;
        }

        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string nomeDoFilme)
        {
            List<CinemaDto> cinemasList = _cinemaService.RecuperarCinemas(nomeDoFilme);

            if (!cinemasList.Any())
            {
                return NotFound();
            }

            return Ok(cinemasList);
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CinemaDto cinemaDto)
        {
            CinemaDto cinemaDtoReturn = _cinemaService.AdicionarCinema(cinemaDto);

            return CreatedAtAction(nameof(RecuperarCinemaById), new { Id = cinemaDtoReturn.Id }, cinemaDtoReturn);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinemaById(int id)
        {
            CinemaDto cinemaDto = _cinemaService.RecuperarCinemaById(id);

            if (cinemaDto == null)
            {
                return NotFound();

            }

            return Ok(cinemaDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] CinemaDto cinemaDto)
        {
            CinemaDto cinemaDtoReturn = _cinemaService.AtualizarCinema(id, cinemaDto);
            
            if (cinemaDtoReturn == null)
            {
                return NotFound();

            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            CinemaDto cinemaDto = _cinemaService.DeletarCinema(id);

            if (cinemaDto == null)
            {
                return NotFound();

            }

            return NoContent();
        }
    }
}
