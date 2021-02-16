using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosWeb.Models
{
    public class Semestre
    {
        public int SemestreID { get; set; }
        public List<Disciplina> Disciplinas { get; set; }
    }
}
