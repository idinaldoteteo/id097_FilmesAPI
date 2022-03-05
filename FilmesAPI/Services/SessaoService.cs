using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Dto;
using FilmesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class SessaoService : ISessaoService
    {
        private readonly AppDbContext _contextSessao;
        private readonly IMapper _mapper;

        public SessaoService(AppDbContext contextSessao, IMapper mapper)
        {
            this._contextSessao = contextSessao;
            this._mapper = mapper;
        }

        public SessaoDto AdicionarSessao(SessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);

            _contextSessao.Sessoes.Add(sessao);
            _contextSessao.SaveChanges();

            return _mapper.Map<SessaoDto>(sessao);
        }

        public SessaoDto RecuperarSessaoPorId(int id)
        {
            Sessao sessao = _contextSessao.Sessoes.FirstOrDefault(Sessao => Sessao.Id == id);
            if (sessao == null)
            {
                return null;
            }

            return _mapper.Map<SessaoDto>(sessao);
        }

        public List<SessaoDto> RecuperarSessoes()
        {
            List<Sessao> sessaoList = _contextSessao.Sessoes.ToList();

            return _mapper.Map<List<SessaoDto>>(sessaoList);
        }
    }
}
