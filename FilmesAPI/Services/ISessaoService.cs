using FilmesAPI.Dto;
using System.Collections.Generic;

namespace FilmesAPI.Services
{
    public interface ISessaoService
    {
        List<SessaoDto> RecuperarSessoes();
        SessaoDto AdicionarSessao(SessaoDto sessaoDto);
        SessaoDto RecuperarSessaoPorId(int id);
    }
}
