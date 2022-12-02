using System.ComponentModel.DataAnnotations;
using SistemaWebEmpleado.Validations;

namespace SistemaWebEmpleado.Models
{
    public class Empleado
    {

        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        public string DNI { get; set; }
        [Required]
        [CheckLegajo]
        public string Legajo { get; set; }
        [Required]
        public string Titulo { get; set; }

    }
}
