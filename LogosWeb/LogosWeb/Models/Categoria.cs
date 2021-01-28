using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosWeb.Models
{
    public class Categoria
    {
        public Categoria() { }

        public int CategoriaID { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }
}
