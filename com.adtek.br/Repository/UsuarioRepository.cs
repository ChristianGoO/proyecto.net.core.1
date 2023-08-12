using com.adtek.br.Models;
using Microsoft.EntityFrameworkCore;
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

        public Usuario? GetByUid(Guid uid) 
        {
            return this.context.Usuarios.Where(usuario => usuario.guid == uid).FirstOrDefault();
        }

        public Usuario? GetByCorreoContraseña(string correoElectronico, string contraseña)
        {
            return this.context.Usuarios.Where(u => u.CorreoElectronico.Equals(correoElectronico) && u.Contraseña.Equals(contraseña)).FirstOrDefault();
        }

        public void Update(Usuario usuario) 
        {
            this.context.Entry(usuario).State = EntityState.Modified;
            this.context.SaveChanges();
        }

    }
}
