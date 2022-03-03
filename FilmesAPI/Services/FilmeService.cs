using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Dto;
using FilmesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly AppDbContext _filmeContext;
        private readonly IMapper _mapper;

        public FilmeService()
        {
        }

        public FilmeService(AppDbContext filmeContext, IMapper mapper)
        {
            _filmeContext = filmeContext;
            _mapper = mapper;
        }

        public FilmeDto AdicionarFilme(FilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

            _filmeContext.Filmes.Add(filme);
            _filmeContext.SaveChanges();

            return _mapper.Map<FilmeDto>(filme);
        }

        public FilmeDto AtualizarFilme(int id, FilmeDto filmeDto)
        {
            Filme filme = _filmeContext.Filmes.FirstOrDefault(filmeDto => filmeDto.Id == id);
            if (filme == null)
            {
                return null;
            }

            _mapper.Map(filmeDto, filme);
            _filmeContext.SaveChanges();

            return _mapper.Map<FilmeDto>(filme);
        }

        public FilmeDto DeletarFilme(int id)
        {
            Filme filme = _filmeContext.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return null;
            }

            _filmeContext.Remove(filme);
            _filmeContext.SaveChanges();

            return _mapper.Map<FilmeDto>(filme);
        }

        public List<FilmeDto> RecupearFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
            {
                filmes = _filmeContext.Filmes.ToList();
            }
            else
            {
                filmes = _filmeContext.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }

            return _mapper.Map<List<FilmeDto>>(filmes);
        }

        public FilmeDto RecuperarFilmePorId(int id)
        {
            Filme filme = _filmeContext.Filmes.FirstOrDefault(Filme => Filme.Id == id);
            if (filme == null)
            {
                return null;
            }

            return _mapper.Map<FilmeDto>(filme);
        }
    }
}
