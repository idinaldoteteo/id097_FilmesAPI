using FilmesAPI.Dto;
using System.Collections.Generic;

namespace FilmesAPI.Services
{
    public interface IFilmeService
    {
        FilmeDto AdicionarFilme(FilmeDto filmeDto);
        List<FilmeDto> RecupearFilmes(int? classificacaoEtaria);
        FilmeDto RecuperarFilmePorId(int id);
        FilmeDto AtualizarFilme(int id, FilmeDto filmeDto);
        FilmeDto DeletarFilme(int id);
    }
}
