using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dto
{
    public class CinemaDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Lancamento { get; set; }
    }
}
