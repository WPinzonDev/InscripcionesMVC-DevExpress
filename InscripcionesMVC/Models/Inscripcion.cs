using System.ComponentModel.DataAnnotations;

namespace InscripcionesMVC.Models
{
    public class Inscripcion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AspiranteId { get; set; }
        public Aspirante Aspirante { get; set; }

        [Required(ErrorMessage = "El tipo de aspirante es obligatorio.")]
        [Display(Name = "Tipo de Aspirante")]
        public int TipoAspiranteId { get; set; }

        [Display(Name = "Tipo de Aspirante")]
        public TipoAspirante TipoAspirante { get; set; }

        [Required(ErrorMessage = "El programa es obligatorio.")]
        [Display(Name = "Programa a Matricular")]
        public int ProgramaId { get; set; }
        public Programa Programa { get; set; }

        [Display(Name = "Fecha de Inscripción")]
        [Required(ErrorMessage = "La fecha de inscripción es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de inscripción no es válida.")]
        public DateTime FechaInscripcion { get; set; }
    }
}
