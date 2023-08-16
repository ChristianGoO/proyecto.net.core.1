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
        public string CorreoElectronico { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
        public Guid guid { get; set; } = Guid.NewGuid();
        public bool Activo { set; get; } = false;
        public bool Bloqueado { get; set; } = false;
        public DateTime fechaCreacion { get; set; }
        public string? UsuarioCreacion { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public string? UsuarioModificacion { get; set; }
    }
}
