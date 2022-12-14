using System.ComponentModel.DataAnnotations;

namespace OSpital.Models
{
    public class Paciente
    {
        [Key]
        public string? Id { get; set; }
        public string? Dni { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Sexo { get; set; }
        public string? Mail { get; set; }
        public string? CodigoTelefono { get; set; }
        public string? Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime UltimaConsulta { get; set; }
        public string? ObraSocial { get; set; }
        public string? NumeroAfiliadoOS { get; set; }
        public string? Direccion { get; set; }
        public string? Localidad { get; set; }
        public string? ClienteActivo { get; set; }
    }
}
