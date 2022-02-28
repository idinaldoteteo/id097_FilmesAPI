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
    public class SessaoController : ControllerBase
    {
        private readonly AppDbContext _contextSessao;
        private readonly IMapper _mapper;

        public SessaoController(AppDbContext contextSessao, IMapper mapper)
        {
            this._contextSessao = contextSessao;
            this._mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Sessao> RecuperarSessos()
        {
            return _contextSessao.Sessoes;
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] SessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);

            _contextSessao.Sessoes.Add(sessao);
            _contextSessao.SaveChanges();

            return CreatedAtAction(nameof(RecuperarSessaoPorId), new { sessao.Id }, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessaoPorId(int id)
        {
            Sessao sessao = _contextSessao.Sessoes.FirstOrDefault(Sessao => Sessao.Id == id);
            if(sessao == null)
            {
                return NotFound();
            }

            SessaoDto sessaoDto = _mapper.Map<SessaoDto>(sessao);
            return Ok(sessaoDto);
        }
    }
}
