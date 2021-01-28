using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosWeb.Models
{
    public class Professor
    {
        public int ProfessorID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Area { get; set; }
        public bool IsVisitante { get; set; }
        public string UrlImagem { get; set; }
        public List<RedeSocial> RedesSociais { get; set; }
        public int Grau { get; set; }
    }
}
