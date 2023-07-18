using com.adtek.br.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Repository
{
    public class UsuarioRepository
    {
        private readonly AdtekDBContext context;

        public UsuarioRepository(AdtekDBContext context)
        {
            this.context = context;
        }

        public void Insert(Usuario usuario)
        {
            this.context.Usuarios.Add(usuario);
            this.context.SaveChanges();
        }
    }
}
