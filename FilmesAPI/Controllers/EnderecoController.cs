using AutoMapper;
using FilmesAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using FilmesAPI.Models;
using FilmesAPI.Dto;
using System.Collections;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private IMapper _mapper;
        private AppDbContext _enderecoContext;

        public EnderecoController(IMapper mapper, AppDbContext enderecoContext)
        {
            this._mapper = mapper;
            this._enderecoContext = enderecoContext;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] EnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _enderecoContext.Enderecos.Add(endereco);
            _enderecoContext.SaveChanges();

            return CreatedAtAction(nameof(RecuperarEnderecoById), new {Id = endereco.Id}, endereco);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarEnderecoById(int id)
        {
           Endereco endereco = _enderecoContext.Enderecos.FirstOrDefault(Endereco => Endereco.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }

            EnderecoDto enderecoDto = _mapper.Map<EnderecoDto>(endereco);
            return Ok(enderecoDto);
        }

        [HttpGet]
        public IEnumerable RecuperarEnderecos()
        {
            return _enderecoContext.Enderecos;
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] EnderecoDto enderecoDto)
        {
            Endereco endereco = _enderecoContext.Enderecos.FirstOrDefault(Endereco => Endereco.Id == id);
            if(endereco == null)
            {
                return NotFound();
            }

            _mapper.Map(enderecoDto, endereco);
            _enderecoContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEndereco(int id)
        {
            Endereco endereco = _enderecoContext.Enderecos.FirstOrDefault(Endereco => Endereco.Id == id);
            if(endereco == null)
            {
                return NotFound();
            }

            _enderecoContext.Remove(endereco);
            _enderecoContext.SaveChanges();

            return NoContent();
        }
    }
}
