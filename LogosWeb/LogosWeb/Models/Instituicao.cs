using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosWeb.Models
{
    public class Instituicao
    {
        public Instituicao() { }

        public string Nome { get; set; }
        public string Missao { get; set; }
        public string Visao { get; set; }
        public List<Valor> Valores { get; set; }
        public string Historia { get; set; }
        public string DeclaracaoDoutrinaria { get; set; }
        public string Endereco { get; set; }
        public List<RedeSocial> RedesSociais { get; set; }
        public string Telefone { get; set; }
        public string Whatsapp { get; set; }
        public string Email { get; set; }
    }
}
