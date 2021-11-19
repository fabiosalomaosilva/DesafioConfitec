using DesafioConfitec.Domain.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioConfitec.Services.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }
        public Escolaridade Escolaridade { get; set; }
    }
}