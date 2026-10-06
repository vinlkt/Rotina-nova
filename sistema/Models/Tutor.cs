using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace sistema.Models
{
    public class Tutor
    {
        public int Id { get; set; }

        [Required, StringLength(120)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string CpfCriptografado { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string Telefone { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(30)]
        public string Email { get; set; } = string.Empty;

        public ICollection<Pet> Pets { get; set; } = new List<Pet>();
        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }
}