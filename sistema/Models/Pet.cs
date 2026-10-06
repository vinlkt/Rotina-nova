using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace sistema.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Especie { get; set; } = string.Empty;

        [Required, StringLength(80)]
        public string? Raca { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        [Required]
        public int TutorId { get; set; }
        public Tutor Tutor { get; set; } = null!;
        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }
}