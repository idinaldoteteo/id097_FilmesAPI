using FilmesAPI.Dto;
using FluentResults;
using System.Collections.Generic;

namespace FilmesAPI.Services
{
    public interface IEnderecoService
    {
        List<EnderecoDto> RecuperarEnderecos();
        EnderecoDto AdicionarEndereco(EnderecoDto enderecoDto);
        EnderecoDto RecuperarEnderecoById(int id);
        Result AtualizarEndereco(int id, EnderecoDto enderecoDto);
        Result DeletarEndereco(int id);
    }
}
