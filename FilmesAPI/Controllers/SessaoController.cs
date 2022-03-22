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
    public class SessaoController : ControllerBase
    {
        private readonly ISessaoService _sessaoService;

        public SessaoController(ISessaoService sessaoService)
        {
            this._sessaoService = sessaoService;
        }

        [HttpGet]
        public IActionResult RecuperarSessoes()
        {
            List<SessaoDto> sessaoDtoList = _sessaoService.RecuperarSessoes();

            if (!sessaoDtoList.Any())
            {
                return NotFound();
            }

            return Ok(sessaoDtoList);
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] SessaoDto sessaoDto)
        {
            SessaoDto sessaoDtoReturn = _sessaoService.AdicionarSessao(sessaoDto);

            return CreatedAtAction(nameof(RecuperarSessaoPorId), new { sessaoDtoReturn.Id }, sessaoDtoReturn);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessaoPorId(int id)
        {
            SessaoDto sessaoDto = _sessaoService.RecuperarSessaoPorId(id);
            
            if(sessaoDto == null)
            {
                return NotFound();
            }

            return Ok(sessaoDto);
        }
    }
}
