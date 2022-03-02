using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Dto;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly AppDbContext _filmeContext;
        private readonly IMapper _mapper;

        public FilmeController(AppDbContext filmeContext, IMapper mapper)
        {
            _filmeContext = filmeContext;   
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] FilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

            _filmeContext.Filmes.Add(filme);
            _filmeContext.SaveChanges();
            // this method below return the location of resources
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<Filme> filmes;
            if ( classificacaoEtaria == null)
            {
                filmes = _filmeContext.Filmes.ToList();

            }
            else
            {
                filmes = _filmeContext.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }
            
            if( filmes.Count == 0)
            {
                return NotFound();
            }

            List<FilmeDto> filmesDto = _mapper.Map<List<FilmeDto>>(filmes);

            return Ok(filmesDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id)
        {
            Filme filme = _filmeContext.Filmes.FirstOrDefault(Filme => Filme.Id == id);
            if(filme == null)
            {
                return NotFound();
            }

            FilmeDto filmeDto = _mapper.Map<FilmeDto>(filme);
            return Ok(filmeDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] FilmeDto filmeDto)
        {
            Filme filme = _filmeContext.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }

            _mapper.Map(filmeDto, filme);
            _filmeContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Filme filme = _filmeContext.Filmes.FirstOrDefault(filme => filme.Id == id);
            if( filme == null)
            {
                return NotFound();
            }

            _filmeContext.Remove(filme);
            _filmeContext.SaveChanges();
            return NoContent();
        }

    }
}
