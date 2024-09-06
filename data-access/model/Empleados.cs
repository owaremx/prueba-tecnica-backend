using RepoDb.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data_access.model
{
    public class Empleados
    {
        [Key]
        [Identity]
        public int Id { get; set; }
        public string? Fotografia { get; set; }
        public string? Nombre { get; set; } 
        public string? Apellido { get; set; } 

        public int PuestoId { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaContratacion { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? CorreoElectronico { get; set; }
        public int EstadoId { get; set; }

        public string? Puesto {  get; set; }
        public string? Estado {  get; set; }
    }
}
