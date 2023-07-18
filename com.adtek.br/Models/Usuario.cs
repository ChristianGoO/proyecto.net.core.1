using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Contraseña { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string? UsuarioCreacion { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public string? UsuarioModificacion { get; set; }
    }
}
