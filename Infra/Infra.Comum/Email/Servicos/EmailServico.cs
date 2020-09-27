using Infra.Comum.Email.Interfaces;
using Infra.Comum.Email.ValueObjects;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Comum.Email.Servicos
{
    public class EmailServico : IEmailServico
    {
        private readonly EmailSettings _emailSettings;
        public EmailServico(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public  void SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                _ = Execute(email, subject, message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Execute(string email, string subject, string message)
        {
            try
            {
                string toEmail =  email;

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.UsernameEmail, "SmartMechanical")
                };

                mail.To.Add(new MailAddress(toEmail));

                mail.Subject = "SmartMechanical - " + subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;


                using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> HTMLEmailAbertura()
        {
            string html = "";

            var assembly = typeof(EmailServico).GetTypeInfo().Assembly;

            Stream resource = null;
            StreamReader sr = null;

            try
            {
                resource = assembly.GetManifestResourceStream($"Infra.Comum.Email.Template.aberturaOS.html");
                sr = new StreamReader(resource);
                html = await sr.ReadToEndAsync();
            }
            finally
            {
                resource?.Dispose();
                sr?.Dispose();
            }

            return html;
        }
    }
}
