using AutoMapper;
using FilmesAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using FilmesAPI.Models;
using FilmesAPI.Dto;
using System.Collections;
using FilmesAPI.Services;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            this._enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] EnderecoDto enderecoDto)
        {
            EnderecoDto enderecoDtoReturn = _enderecoService.AdicionarEndereco(enderecoDto);

            return CreatedAtAction(nameof(RecuperarEnderecoById), new {enderecoDtoReturn.Id}, enderecoDtoReturn);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarEnderecoById(int id)
        {
            EnderecoDto enderecoDto = _enderecoService.RecuperarEnderecoById(id);
            
            if (enderecoDto == null)
            {
                return NotFound();
            }

            return Ok(enderecoDto);
        }

        [HttpGet]
        public List<EnderecoDto> RecuperarEnderecos()
        {
            return _enderecoService.RecuperarEnderecos();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] EnderecoDto enderecoDto)
        {
            EnderecoDto enderecoDtoReturn = _enderecoService.AtualizarEndereco(id, enderecoDto);

            if(enderecoDtoReturn == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEndereco(int id)
        {
            EnderecoDto enderecoDto = _enderecoService.DeletarEndereco(id);

            if(enderecoDto == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
