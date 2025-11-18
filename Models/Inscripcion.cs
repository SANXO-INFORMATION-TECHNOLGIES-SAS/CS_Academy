using System.ComponentModel.DataAnnotations;

namespace InscripcionesWebApp.Models
{
    public class Inscripcion
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Por favor verifica tus datos, el nombre es obligatorio") ]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Por favor verifica tus datos, el documento es obligatorio") ]
        public string Documento { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Por favor verifica tus datos, Email no válido") ]
        public string Email { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "Por favor verifica tus datos, el programa es obligatorio") ]
        public string Programa { get; set; } = string.Empty;

        [Required(ErrorMessage = "Por favor verifica tus datos, la fecha de inscripción es obligatoria") ]
        [DataType(DataType.Date)]
        public DateTime FechaInscripcion { get; set; } = DateTime.Today;
    }
}
