using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace sistema.ViewModels
{
    public class TutorFormViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required, Display(Name = "CPF"), RegularExpression(@"\d{11}", ErrorMessage = "CPF deve conter 11 dígitos numéricos.")]
        public string Cpf { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string Telefone { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(200)]
        public string Email { get; set; } = string.Empty;
    }
}