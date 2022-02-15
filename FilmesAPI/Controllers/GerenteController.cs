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
    public class GerenteController : ControllerBase
    {
        private readonly AppDbContext _contextGerente;
        private readonly IMapper _mapper;

        public GerenteController(AppDbContext contextGerente, IMapper mapper)
        {
            _contextGerente = contextGerente;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarGerente(GerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);

            _contextGerente.Gerentes.Add(gerente);
            _contextGerente.SaveChanges();

            return CreatedAtAction(nameof(RecuperarGerentePorId), new { gerente.Id }, gerente);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarGerentePorId(int id)
        {
            Gerente gerente = _contextGerente.Gerentes.FirstOrDefault(Gerente => Gerente.Id == id);
            if (gerente == null)
            {
                return NotFound();
            }

            GerenteDto gerenteDto = _mapper.Map<GerenteDto>(gerente);
            return Ok(gerenteDto);
        }

        [HttpGet]
        public IEnumerable<Gerente> RecuperarFilmes()
        {
            return _contextGerente.Gerentes;
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarGerentePorId(int id, [FromBody] GerenteDto gerenteDto)
        {

            Gerente gerente = _contextGerente.Gerentes.FirstOrDefault(Gerente => Gerente.Id == id);
            if(gerente == null)
            {
                return NotFound();
            }

            _mapper.Map(gerenteDto, gerente);
            _contextGerente.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id)
        {
            Gerente gerente = _contextGerente.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if(gerente == null)
            {
                return NotFound();
            }

            _contextGerente.Remove(gerente);
            _contextGerente.SaveChanges();

            return NoContent();
        }
    }
}
