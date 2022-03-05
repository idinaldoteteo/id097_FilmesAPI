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
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private readonly IGerenteService _gerenteService;

        public GerenteController(IGerenteService gerenteService)
        {
            this._gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionarGerente(GerenteDto gerenteDto)
        {
            GerenteDto gerenteDtoReturn = _gerenteService.AdicionarGerente(gerenteDto);

            return CreatedAtAction(nameof(RecuperarGerentePorId), new { gerenteDtoReturn.Id }, gerenteDtoReturn);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarGerentePorId(int id)
        {
            GerenteDto gerenteDto = _gerenteService.RecuperarGerenteById(id);

            if (gerenteDto == null)
            {
                return NotFound();
            }

            return Ok(gerenteDto);
        }

        [HttpGet]
        public List<GerenteDto> RecuperarGerentes()
        {
            return _gerenteService.RecuperarGerentes();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarGerentePorId(int id, [FromBody] GerenteDto gerenteDto)
        {
            GerenteDto gerenteDtoReturn = _gerenteService.AtualizarGerente(id, gerenteDto);
            
            if(gerenteDtoReturn == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id)
        {
            GerenteDto gerenteDto = _gerenteService.DeletarGerente(id);
            
            if(gerenteDto == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
