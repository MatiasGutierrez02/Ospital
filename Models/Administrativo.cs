using System.ComponentModel.DataAnnotations;

namespace OSpital.Models
{
    public class Administrativo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
