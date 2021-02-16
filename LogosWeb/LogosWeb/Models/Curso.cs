using LogosWeb.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosWeb.Models
{
    public class Curso
    {
        public Curso() { }

        public int CursoID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Horario { get; set; }
        public string Duracao { get; set; }
        public List<EInteresseFormato> Formato { get; set; }
        public string Publico { get; set; }
        public string Categoria { get; set; }
        public string Grau { get; set; }
        public List<int> Professores { get; set; }
        public Grade Grade { get; set; }
        public List<Financeiro> Financeiro { get; set; }
        public string UrlImagemPrincipal { get; set; }
        public List<string> Imagens { get; set; }
    }
}
