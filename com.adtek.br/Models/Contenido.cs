using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Models
{
    public class Contenido
    {
        public int Id { get; set; }
        public string Clave { get; set; } = string.Empty;
        public string Asunto { get; set; } = string.Empty;
        public string ContenidoHtml { get; set; } = string.Empty;
        public DateTime fechaCreacion { get; set; }
        public string? UsuarioCreacion { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public string? UsuarioModificacion { get; set; }    
    }
}
