using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosWeb.Models
{
    public class Postagem
    {
        public Postagem() { }

        public int PostagemID { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Conteudo { get; set; }
        public string Categoria { get; set; }
        public string Autor { get; set; }
        public DateTime Data { get; set; }
        public string Imagem { get; set; }
    }
}
