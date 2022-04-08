using FilmesAPI.Dto;
using FluentResults;
using System.Collections.Generic;

namespace FilmesAPI.Services
{
    public interface IGerenteService
    {
        List<GerenteDto> RecuperarGerentes();
        GerenteDto AdicionarGerente(GerenteDto gerenteDto);
        GerenteDto RecuperarGerenteById(int id);
        Result AtualizarGerente(int id, GerenteDto gerenteDto);
        Result DeletarGerente(int id);
    }
}
