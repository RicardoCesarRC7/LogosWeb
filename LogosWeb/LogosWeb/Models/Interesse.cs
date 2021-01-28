using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LogosWeb.Models
{
    public class Interesse
    {
        public Interesse() { }

        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public List<string> Area { get; set; }
        public List<string> Curso { get; set; }
        public List<string> Formato { get; set; }
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
                message.Subject = $"Nova resposta ao formulário: {PrimeiroNome} {SegundoNome} têm interesse no Seminário Logos";
                message.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                message.IsBodyHtml = true;
                message.Body = $"<html><head></head><body style=\" \"><h1 style=\"text-align: center; padding-bottom: 15px; font-family: system-ui; \">Respostas do Formulário</h1><table style=\"text-align: left; margin: auto; font-family: monospace; font-size: large; \"><tr><td>Nome</td><td>{PrimeiroNome} {SegundoNome}</td></tr><tr><td>Email</td><td>{Email}</td></tr><tr><td>Telefone/Whatsapp</td><td>{Telefone}</td></tr><tr><td>Área(s) de interesse</td><td>{SetAreas()}</td></tr><tr><td>Curso(s) de interesse</td><td>{SetCursos()}</td></tr><tr><td>Formato(s) de interesse</td><td>{SetFormatos()}</td></tr><tr><td>Mensagem adicional</td><td>{Mensagem}</td></tr></table></body></html>";
                message.BodyEncoding = Encoding.GetEncoding("UTF-8");

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("logoswebapp@gmail.com", "nsibvphyqhorvvar");
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

        private string SetAreas()
        {
            string areas = string.Empty;

            if (Area != null && Area.Count > 0)
            {
                foreach (string area in Area)
                {
                    int index = Area.IndexOf(area);

                    areas += area;

                    if (index != (Area.Count - 1))
                        areas += ", ";
                }
            }

            return areas;
        }

        private string SetCursos()
        {
            string cursos = string.Empty;

            if (Curso != null && Curso.Count > 0)
            {
                foreach (string curso in Curso)
                {
                    int index = Curso.IndexOf(curso);

                    cursos += curso;

                    if (index != (Curso.Count - 1))
                        cursos += ", ";
                }
            }

            return cursos;
        }

        private string SetFormatos()
        {
            string formatos = string.Empty;

            if (Formato != null && Formato.Count > 0)
            {
                foreach (string formato in Formato)
                {
                    int index = Formato.IndexOf(formato);

                    formatos += formato;

                    if (index != (Formato.Count - 1))
                        formatos += ", ";
                }
            }

            return formatos;
        }
    }
}
