using FilmesAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dto
{
    public class FilmeDto
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Diretor { get; set; }
        [Required]
        [Range(1, 600)]
        public int Duracao { get; set; }
        [StringLength(30)]
        public string Genero { get; set; }
        public int ClassificacaoEtaria { get; set; }
    }
}
