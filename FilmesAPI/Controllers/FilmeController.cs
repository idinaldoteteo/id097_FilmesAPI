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
        private AppDbContext _filmeContext;
        private IMapper _mapper;

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
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes()
        {
            return _filmeContext.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id)
        {
            Filme filme = _filmeContext.Filmes.FirstOrDefault(Filme => Filme.Id == id);
            if(filme != null)
            {
                FilmeDto filmeDto = _mapper.Map<FilmeDto>(filme);
                return Ok(filmeDto);
            }
            return NotFound();
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
