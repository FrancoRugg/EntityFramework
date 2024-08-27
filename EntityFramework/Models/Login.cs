using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Login//Para que ek orm conozca la tabla hay que crear una clase con el contexto de la misma
    {
        public int Id { get; set; }
        public string? Usuario { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? Dni { get; set; }
        public string? Area { get; set; }
        public string? FechaAlta { get; set; }
        public int Rol { get; set; }
        public string? Estado { get; set; }
    }
}
