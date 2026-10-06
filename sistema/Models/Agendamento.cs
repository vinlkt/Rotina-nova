using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace sistema.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        [Required]
        public DateTime DataHora { get; set; }
        [Required, StringLength(200)]
        public string Motivo { get; set; } = string.Empty;
        [Required, StringLength(30)]
        public string Status { get; set; } = "Agendado";
        [Required]
        public int TutorId { get; set; }
        public Tutor Tutor { get; set; } = null!;
        [Required]
        public int PetId { get; set; }
        public Pet Pet { get; set; } = null!;
    }
}