using com.adtek.br.Dtos;
using com.adtek.br.Exceptions;
using com.adtek.br.Models;
using com.adtek.br.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace com.adtek.br.Services
{
    public class UsuarioService : Service
    {
        private readonly UsuarioRepository usuarioRepository;

        private readonly MailService mailService;

        private char[] caracteresEspeciales = new char[] { '!', '0', '#', '$', '%' };
        private string exRegularMail = "^(([\\w-]+\\.)+[\\w-]+|([a-zA-Z]{1}|[\\w-]{2,}))@(([a-zA-Z]+[\\w-]+\\.){1,2} [a-zA-Z]{2,4})$";

        public UsuarioService(UsuarioRepository usuarioRepository, MailService mailService)
        {
            this.usuarioRepository = usuarioRepository;
            this.mailService = mailService;
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

                //VALIDAR FORMATO DE DATOS
                if (usuarioDto.CorreoElectronico != null && !Regex.IsMatch(usuarioDto.CorreoElectronico, exRegularMail))
                    detalles.Add("El correo electronico no es valido");

                //VALIDAR LA CONTRASEÑA
                if (!string.IsNullOrEmpty(usuarioDto.Contraseña))
                {
                    if (usuarioDto.Contraseña.Length < 6)
                        detalles.Add("La contraseña debe tener una longitud minima de 6 caracteres");
                    if (usuarioDto.Contraseña.Length > 8)
                        detalles.Add("La contraseña debe tener una longitud maxima de 8 caracteres");
                    if (!caracteresEspeciales.Any(caracter => usuarioDto.Contraseña.Contains(caracter)))
                        detalles.Add("La contraseña debe tener una longitud minima de 6 caracteres");
                }


                if (detalles.Count > 0)
                    throw new BadRequestException("La solicitud es incorrecta", detalles.ToArray());

                Usuario usuario = this.DtoToEntity(usuarioDto); 
                usuario.fechaCreacion = DateTime.Now;
                usuario.UsuarioCreacion = "SISTEMA";
                usuario.fechaActualizacion = DateTime.Now;
                usuario.UsuarioModificacion = "SISTEMA";

                this.usuarioRepository.Insert(usuario);

                //ENVIO DE CORREO ELECTRONICO
                if(!string.IsNullOrEmpty(usuarioDto.CorreoElectronico))
                    this.mailService.EnviarCorreo(usuarioDto.CorreoElectronico, "Registro y activacion de usuario", "Hola bienvenido al registro", true);

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
