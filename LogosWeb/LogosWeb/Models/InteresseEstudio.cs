using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace LogosWeb.Models
{
    public class InteresseEstudio
    {
        public InteresseEstudio() { }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Forma { get; set; }
        public string Valor { get; set; }
        public string ValorMensal { get; set; }
        public string Residencial { get; set; }
        public string CPF { get; set; }
        public string Mensagem { get; set; }

        public Result SendEmail()
        {
            Result result = new Result();

            try
            {
                MailMessage message = new MailMessage("logoswebapp@gmail.com", "contato@seminariologos.org.br");
#if DEBUG
                message = new MailMessage("logoswebapp@gmail.com", "musicricardinho@gmail.com");
#endif
                message.Subject = $"Projeto Estúdio: {Nome} quer ajudar!";
                message.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                message.IsBodyHtml = true;
                message.Body = $"<html><head></head><body><h1 style=\"text-align: center; padding-bottom: 15px; font-family: system-ui;\">Respostas do Formulário</h1><table style=\"text-align: left; margin: auto; font-family: monospace; font-size: large; width: 571px;\"><tr><td>Nome</td><td>{Nome}</td></tr><tr><td>Email</td><td>{Email}</td></tr><tr><td>Telefone/Whatsapp</td><td>{Telefone}</td></tr><tr><td>Forma de doação</td><td>{Forma}</td></tr><tr><td>Valor</td><td>{Valor}</td></tr><tr><td>Valor Mensal</td><td>{ValorMensal}</td></tr><tr><td>CEP, Número da residência e Complemento</td><td>{Residencial}</td></tr><tr><td>CPF</td><td>{CPF}</td></tr><tr><td>Mensagem adicional</td><td>{Mensagem}</td></tr></table></body></html>";
                message.BodyEncoding = Encoding.GetEncoding("UTF-8");

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("logoswebapp@gmail.com", "");
                client.EnableSsl = true;

                client.Send(message);

                result.Success = true;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }

            return result;
        }
    }
}
