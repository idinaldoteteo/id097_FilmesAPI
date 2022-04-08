using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Dto;
using FilmesAPI.Models;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly AppDbContext _enderecoContext;
        private readonly IMapper _mapper;

        public EnderecoService(IMapper mapper, AppDbContext enderecoContext)
        {
            this._mapper = mapper;
            this._enderecoContext = enderecoContext;
        }

        public EnderecoDto AdicionarEndereco(EnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _enderecoContext.Enderecos.Add(endereco);
            _enderecoContext.SaveChanges();

            return _mapper.Map<EnderecoDto>(endereco);
        }

        public Result AtualizarEndereco(int id, EnderecoDto enderecoDto)
        {
            Endereco endereco = _enderecoContext.Enderecos.FirstOrDefault(enderecoDto => enderecoDto.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Endereço não encontrado.");
            }

            _mapper.Map(enderecoDto, endereco);
            _enderecoContext.SaveChanges();

            return Result.Ok();
        }

        public Result DeletarEndereco(int id)
        {
            Endereco endereco = _enderecoContext.Enderecos.FirstOrDefault(Endereco => Endereco.Id == id);

            if (endereco == null)
            {
                return Result.Fail("Endereço não encontrado.");
            }

            _enderecoContext.Remove(endereco);
            _enderecoContext.SaveChanges();

            return Result.Ok();
        }

        public EnderecoDto RecuperarEnderecoById(int id)
        {
            Endereco endereco = _enderecoContext.Enderecos.FirstOrDefault(Endereco => Endereco.Id == id);
            if (endereco == null)
            {
                return null;
            }

            return _mapper.Map<EnderecoDto>(endereco);
        }

        public List<EnderecoDto> RecuperarEnderecos()
        {
            List<Endereco> enderecos = _enderecoContext.Enderecos.ToList();

            return _mapper.Map<List<EnderecoDto>>(enderecos);
        }
    }
}
