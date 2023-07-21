using com.adtek.br.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Repository
{
    public class ContenidoRepository
    {
        private readonly AdtekDBContext context;

        public ContenidoRepository(AdtekDBContext context) 
        {
            this.context = context;
        }

        public Contenido? GetByClave(string clave ) 
        {
            return this.context.Contenidos.Where(contenido => contenido.Clave == clave).FirstOrDefault();
        }

    }
}
