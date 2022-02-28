using FilmesAPI.Models;
using System;

namespace FilmesAPI.Dto
{
    public class SessaoDto
    {
        public int Id { get; set; }
        public Cinema Cinema { get; set; }
        public int CinemaId { get; set; }
        public Filme Filme { get; set; }
        public int FilmeId { get; set; }
        public DateTime horarioDeEncerramento { get; set; }
        public DateTime horarioDeInicio { get; set; }
    }
}