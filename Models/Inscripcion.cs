using System.ComponentModel.DataAnnotations;

namespace InscripcionesWebApp.Models
{
    public class Inscripcion
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "El nombre es obligatorio") ]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El documento es obligatorio") ]
        public string Documento { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Email no válido") ]
        public string Email { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "El programa es obligatorio") ]
        public string Programa { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de inscripción es obligatoria") ]
        [DataType(DataType.Date)]
        public DateTime FechaInscripcion { get; set; } = DateTime.Today;
    }
}
