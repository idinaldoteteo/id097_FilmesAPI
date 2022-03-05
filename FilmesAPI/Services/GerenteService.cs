using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Dto;
using FilmesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class GerenteService : IGerenteService
    {
        private readonly AppDbContext _contextGerente;
        private readonly IMapper _mapper;

        public GerenteService(AppDbContext contextGerente, IMapper mapper)
        {
            _contextGerente = contextGerente;
            _mapper = mapper;
        }

        public GerenteDto AdicionarGerente(GerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);

            _contextGerente.Gerentes.Add(gerente);
            _contextGerente.SaveChanges();

            return _mapper.Map<GerenteDto>(gerente);
        }

        public GerenteDto AtualizarGerente(int id, GerenteDto gerenteDto)
        {
            Gerente gerente = _contextGerente.Gerentes.FirstOrDefault(gerenteDto => gerenteDto.Id == id);
            if (gerente == null)
            {
                return null;
            }

            _mapper.Map(gerenteDto, gerente);
            _contextGerente.SaveChanges();

            return _mapper.Map<GerenteDto>(gerente);
        }

        public GerenteDto DeletarGerente(int id)
        {
            Gerente gerente = _contextGerente.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return null;
            }

            _contextGerente.Remove(gerente);
            _contextGerente.SaveChanges();

            return _mapper.Map<GerenteDto>(gerente);
        }

        public GerenteDto RecuperarGerenteById(int id)
        {
            Gerente gerente = _contextGerente.Gerentes.FirstOrDefault(Gerente => Gerente.Id == id);
            if (gerente == null)
            {
                return null;
            }

            return _mapper.Map<GerenteDto>(gerente);
        }

        public List<GerenteDto> RecuperarGerentes()
        {
            List<Gerente> gerenteList = _contextGerente.Gerentes.ToList();

            return _mapper.Map<List<GerenteDto>>(gerenteList);
        }
    }
}
