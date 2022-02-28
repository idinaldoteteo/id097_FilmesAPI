using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; internal set; }
        [Required(ErrorMessage = "O campo Título não pode ser vazio")]
        public string Titulo { get; set; }
        [Required]
        public string Diretor { get; set; }
        [Required]
        [Range(1 , 600)]
        public int Duracao { get; set; }
        [StringLength(30)]
        public string Genero { get; set; }
        public int  ClassificacaoEtaria { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}
