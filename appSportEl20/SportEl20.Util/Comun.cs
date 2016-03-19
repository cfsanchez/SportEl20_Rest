using SportEl20.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SportEl20.Util
{
    public class Comun
    {

        public bool Enviar(Email email)
        {
            try
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                var mail = new MailMessage();
                mail.From = new MailAddress("TuEmail@hotmail.com");
                mail.To.Add(email.EmailTo);
                mail.Subject = email.Asunto;
                mail.IsBodyHtml = true;
                mail.Body = email.Cuerpo;
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("TuEmail@hotmail.com", "Tuclave");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception e)
            {
                //throw new WebFaultException(System.Net.HttpStatusCode.NotAcceptable);
                return true;
            }
        }
    }
}
