using com.adtek.br.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Services
{
    public class MailService
    {
        private readonly AdtekConfigManager adtekConfigManager;
        private SmtpClient smtpClient;
        private string nombreUsuario;
        private string contraseña;

        public MailService(AdtekConfigManager adtekConfigManager) 
        {

            //INICIALIZAR LOS CAMPOS 
            this.adtekConfigManager = adtekConfigManager;

            this.nombreUsuario = "juan.perez@gmail.com";
            this.contraseña = "Passw0rd";

            this.smtpClient = new SmtpClient();
            this.smtpClient.Host = this.adtekConfigManager.Hots;
            this.smtpClient.Port = this.adtekConfigManager.Port;
            this.smtpClient.EnableSsl = this.adtekConfigManager.EnableSsl;
            this.smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            this.smtpClient.UseDefaultCredentials = false;
            this.smtpClient.Credentials = new NetworkCredential(this.adtekConfigManager.UserName, this.adtekConfigManager.Password);
        }

        public void EnviarCorreo(string destinatario, string asunto, string mensaje, bool esHtml = false)
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress(this.adtekConfigManager.UserName);
            email.To.Add(new MailAddress(destinatario));
            email.Subject = asunto;
            email.Body = mensaje;
            email.IsBodyHtml = esHtml;
            smtpClient.Send(email);
        }
    }
}
