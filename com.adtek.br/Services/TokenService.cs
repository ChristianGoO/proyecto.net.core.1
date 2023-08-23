using com.adtek.br.Dtos;
using com.adtek.br.Exceptions;
using com.adtek.br.Models;
using com.adtek.br.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Services
{
    public class TokenService : Service
    {
        private readonly IConfiguration configuration;
        private readonly UsuarioRepository usuarioRepository;

        public TokenService(IConfiguration configuration, UsuarioRepository usuarioRepository)
        {
            this.configuration = configuration;
            this.usuarioRepository = usuarioRepository;
        }

        public Result<TokenDto> autho(UserInfo userInfo)
        {
            Result<TokenDto> result = new Result<TokenDto>();

            try
            {
                if (userInfo == null || string.IsNullOrEmpty(userInfo.Email) || string.IsNullOrEmpty(userInfo.Password))
                    throw new BadRequestException("La solicitud es incorrecta", "Credenciales incorrectas");

                Usuario? usuario = this.usuarioRepository.GetByCorreo(userInfo.Email);

                if(usuario == null)
                    throw new BadRequestException("Credenciales incorrectas", "Credenciales incorrectas");

                if(usuario.Bloqueado)
                    throw new ForbiddenException("Usuario blqueado", "El usuario esta bloqueado, contacte al administrador");

                if (usuario.Contraseña.Equals(userInfo.Password))
                {
                    string? subject = this.configuration["Jwt:Subject"];
                    if (subject == null)
                        throw new Exception("Error de configuracion Jet:Subject");

                    string? jwtkey = this.configuration["Jwt:Key"];
                    if (jwtkey == null)
                        throw new Exception("Error de configuracion Jwt:Key");

                    string? jwtIssuer = this.configuration["Jwt:Issuer"];
                    if (jwtIssuer == null)
                        throw new Exception("Error de configuracion Jet:Key");

                    string? JwtAudience = this.configuration["Jwt:Audience"];
                    if (JwtAudience == null)
                        throw new Exception("Error de configuracion Jet:Audience");

                    //create claims details based on the user information
                    var claims = new[] {
                            new Claim(JwtRegisteredClaimNames.Sub, subject),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                            new Claim("UserId", usuario.Id.ToString()),
                            new Claim("DisplayName", $"{usuario.Nombre} {usuario.ApellidoPaterno} {usuario.ApellidoMaterno}"),
                            new Claim("UserName", usuario.CorreoElectronico),
                            new Claim("Email", usuario.CorreoElectronico)
                        };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtkey));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        jwtIssuer,
                        JwtAudience,
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    TokenDto tokenDto = new TokenDto();
                    tokenDto.AccsesToken = new JwtSecurityTokenHandler().WriteToken(token);

                    result.Resultado = tokenDto;
                    result.OperacionExitosa();

                    return result;
                }
                else
                {
                    throw new ForbiddenException("Credenciales incorrectas", "Credenciales incorrectas");
                }
            }
            catch (Exception ex)
            {
                result = this.GeneraError<TokenDto>(ex);
            }

            return result;
        }
    }
}
