using FilmesAPI.Dto;
using FluentResults;
using System.Collections.Generic;

namespace FilmesAPI.Services
{
    public interface IFilmeService
    {
        FilmeDto AdicionarFilme(FilmeDto filmeDto);
        List<FilmeDto> RecupearFilmes(int? classificacaoEtaria);
        FilmeDto RecuperarFilmePorId(int id);
        Result AtualizarFilme(int id, FilmeDto filmeDto);
        Result DeletarFilme(int id);
    }
}
