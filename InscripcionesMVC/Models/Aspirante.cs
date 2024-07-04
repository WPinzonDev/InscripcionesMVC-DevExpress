using System.ComponentModel.DataAnnotations;

namespace InscripcionesMVC.Models
{
    public class Aspirante
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tipo de Documento")]
        [Required(ErrorMessage = "El tipo de documento es obligatorio.")]
        public string TipoDocumento { get; set; }

        [Display(Name = "Número de Documento")]
        [Required(ErrorMessage = "El número de documento es obligatorio.")]
        [RegularExpression(@"^[0-9]{6,}$", ErrorMessage = "El número de documento debe tener minimo 6 dígitos.")]
        public string Documento { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [Display(Name = "Apellidos")]
        [StringLength(50, ErrorMessage = "El apellido no puede exceder los 50 caracteres.")]
        public string Apellido { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de nacimiento no es válida.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria.")]
        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }

        [Display(Name = "Dirección de Domicilio")]
        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(100, ErrorMessage = "La dirección no puede exceder los 100 caracteres.")]
        public string Direccion { get; set; }

        [Display(Name = "Número de celular")]
        [Required(ErrorMessage = "El Telefono es obligatorio.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "El número de teléfono debe tener 10 dígitos.")]
        public string Telefono { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string CorreoElectronico { get; set; }
    }
}
