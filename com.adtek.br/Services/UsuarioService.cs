using com.adtek.br.Dtos;
using com.adtek.br.Exceptions;
using com.adtek.br.Models;
using com.adtek.br.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Services
{
    public class UsuarioService : Service
    {
        private readonly UsuarioRepository usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public Result<UsuarioDto> Crear(UsuarioDto usuarioDto)
        {
            Result<UsuarioDto> result = new Result<UsuarioDto>();
            try
            {

                List<string> detalles = new List<string>();

                if (string.IsNullOrEmpty(usuarioDto.Nombre))   
                    detalles.Add("El nombre es valido");
                if (string.IsNullOrEmpty(usuarioDto.ApellidoPaterno))
                    detalles.Add("El apellido paterno es requerido");
                if (string.IsNullOrEmpty(usuarioDto.ApellidoMaterno))
                    detalles.Add("El apellido materno es requerido");
                if (string.IsNullOrEmpty(usuarioDto.CorreoElectronico))
                    detalles.Add("El correo electronico es requerido");
                if (string.IsNullOrEmpty(usuarioDto.Contraseña))
                    detalles.Add("La contraseña es requerida");

                if (detalles.Count > 0)
                    throw new BadRequestException("La solicitud es incorrecta", detalles.ToArray());

                Usuario usuario = this.DtoToEntity(usuarioDto); 
                usuario.fechaCreacion = DateTime.Now;
                usuario.UsuarioCreacion = "SISTEMA";
                usuario.fechaActualizacion = DateTime.Now;
                usuario.UsuarioModificacion = "SISTEMA";

                this.usuarioRepository.Insert(usuario);

                usuarioDto.Id = usuario.Id;
                result.Resultado = usuarioDto;
                result.CreacionExitosa();
            }
            catch (Exception ex)
            {

                result = this.GeneraError<UsuarioDto>(ex);
            }

            return result;
        }

        private Usuario DtoToEntity(UsuarioDto usuarioDto)
        {
            Usuario entity = new Usuario
            {
                Id = usuarioDto.Id,
                Nombre = usuarioDto.Nombre,
                ApellidoPaterno = usuarioDto.ApellidoPaterno,
                ApellidoMaterno = usuarioDto.ApellidoMaterno,
                CorreoElectronico = usuarioDto.CorreoElectronico,
                Contraseña = usuarioDto.Contraseña

            };

            return entity;
        }
    }
}
