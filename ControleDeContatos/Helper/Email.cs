﻿using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;

namespace ControleDeContatos.Helper
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration;

        private readonly ILogger<Email> _logger;
        public Email(IConfiguration configuration, ILogger<Email> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public bool EnviarEmail(string email, string assunto, string mensagem)
        {
            try
            {
                string host = _configuration.GetValue<string>("SMTP:Host");
                string nome = _configuration.GetValue<string>("SMTP:Nome");
                string username = _configuration.GetValue<string>("SMTP:UserName");
                string senha = _configuration.GetValue<string>("SMTP:Senha");
                int porta = _configuration.GetValue<int>("SMTP:Porta");

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(username, nome)
                };
                mail.To.Add(email);
                mail.Subject = assunto;
                mail.Body = mensagem;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(host, porta))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(username, senha);
                    smtp.EnableSsl = true;

                    smtp.Send(mail);
                    _logger.LogInformation("Email enviado com sucesso para {Email}", email);
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                // Logar o erro completo
                _logger.LogError(ex, "Erro ao enviar email para {Email}", email);
                return false;
            }
        }
    }
}
