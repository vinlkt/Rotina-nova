using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace sistema.ViewModels
{
    public class AgendamentoFormViewModel
    {
        public int Id { get; set; }
    [Required, Display(Name = "Data e hora")]
    public DateTime DataHora { get; set; }
    [Required, StringLength(200)]
    public string Motivo { get; set; } = string.Empty;
    [Required, StringLength(30)]
    public string Status { get; set; } = "Agendado";
    [Range(1, int.MaxValue, ErrorMessage = "Selecione um tutor."), Display(Name = "Tutor")]
    public int TutorId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Selecione um pet."), Display(Name = "Pet")]
    public int PetId { get; set; }
    public IEnumerable<SelectListItem> Tutores { get; set; } = [];
    public IEnumerable<SelectListItem> Pets { get; set; } = [];
    }
}