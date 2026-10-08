using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace sistema.ViewModels
{
    public class PetFormViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Nome { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Especie { get; set; } = string.Empty;

        [StringLength(80)]
        public string? Raca { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Selecione um tutor."), Display(Name = "Tutor")]
        public int TutorId { get; set; }
    }
}