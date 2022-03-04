using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Dto;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        public FilmeController(IFilmeService filmeService)
        {
            this._filmeService = filmeService;
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] FilmeDto filmeDto)
        {
            FilmeDto filmeDtoReturn = _filmeService.AdicionarFilme(filmeDto);
            
            // this method below return the location of resources
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { filmeDtoReturn.Id }, filmeDtoReturn);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<FilmeDto> filmeDto = _filmeService.RecupearFilmes(classificacaoEtaria);
            
            if(!filmeDto.Any())
            {
                return NotFound();
            }

            return Ok(filmeDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id)
        {
            FilmeDto filmeDto = _filmeService.RecuperarFilmePorId(id);
            
            if( filmeDto == null)
            {
                return NotFound();
            }

            return Ok(filmeDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] FilmeDto filmeDto)
        {
            FilmeDto filmeDtoReturn = _filmeService.AtualizarFilme(id, filmeDto);
            if( filmeDtoReturn == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            FilmeDto filmeDto = _filmeService.DeletarFilme(id);
            if( filmeDto == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
