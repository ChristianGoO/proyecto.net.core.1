using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Dtos
{
    public class UsuarioDto
    {
        public int Id {  get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno {  get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Contraseña { get; set; }
    }
}
