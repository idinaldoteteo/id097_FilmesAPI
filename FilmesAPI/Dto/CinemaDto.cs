using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dto
{
    public class CinemaDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Lancamento { get; set; }
        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        public Gerente Gerente { get; set; }
        public int GerenteId { get; set; }
    }
}
