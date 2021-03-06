using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Dto;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
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
        public IActionResult RecuperarGerentes()
        {
            List<GerenteDto> gerenteDtoList = _gerenteService.RecuperarGerentes();

            if (!gerenteDtoList.Any())
            {
                return NotFound();
            }

            return Ok(gerenteDtoList);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarGerentePorId(int id, [FromBody] GerenteDto gerenteDto)
        {
            Result result = _gerenteService.AtualizarGerente(id, gerenteDto);
            
            if(result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id)
        {
            Result result = _gerenteService.DeletarGerente(id);
            
            if(result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
