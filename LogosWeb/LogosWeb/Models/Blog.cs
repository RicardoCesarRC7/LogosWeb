using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosWeb.Models
{
    public class Blog
    {
        public Blog() { }

        public List<Postagem> Postagens { get; set; }
        public List<Categoria> Categorias { get; set; }
    }
}
