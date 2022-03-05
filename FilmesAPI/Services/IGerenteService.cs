using FilmesAPI.Dto;
using System.Collections.Generic;

namespace FilmesAPI.Services
{
    public interface IGerenteService
    {
        List<GerenteDto> RecuperarGerentes();
        GerenteDto AdicionarGerente(GerenteDto gerenteDto);
        GerenteDto RecuperarGerenteById(int id);
        GerenteDto AtualizarGerente(int id, GerenteDto gerenteDto);
        GerenteDto DeletarGerente(int id);
    }
}
