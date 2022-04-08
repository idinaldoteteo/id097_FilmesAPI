using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Dto;
using FilmesAPI.Models;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly AppDbContext _filmeContext;
        private readonly IMapper _mapper;

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

        public Result AtualizarFilme(int id, FilmeDto filmeDto)
        {
            Filme filme = _filmeContext.Filmes.FirstOrDefault(filmeDto => filmeDto.Id == id);
            if (filme == null)
            {
                return Result.Fail("Filme não encontrado.");
            }

            _mapper.Map(filmeDto, filme);
            _filmeContext.SaveChanges();

            return Result.Ok();
        }

        public Result DeletarFilme(int id)
        {
            Filme filme = _filmeContext.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return Result.Fail("Filment não encontrado");
            }

            _filmeContext.Remove(filme);
            _filmeContext.SaveChanges();

            return Result.Ok();
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
