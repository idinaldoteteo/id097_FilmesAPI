using FilmesAPI.Dto;
using System.Collections.Generic;

namespace FilmesAPI.Services
{
    public interface IEnderecoService
    {
        List<EnderecoDto> RecuperarEnderecos();
        EnderecoDto AdicionarEndereco(EnderecoDto enderecoDto);
        EnderecoDto RecuperarEnderecoById(int id);
        EnderecoDto AtualizarEndereco(int id, EnderecoDto enderecoDto);
        EnderecoDto DeletarEndereco(int id);
    }
}
