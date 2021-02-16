using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosWeb.Models
{
    public class Grade
    {
        public int GradeID { get; set; }
        public List<Semestre> Semestres { get; set; }
        public bool Show { get; set; }
    }
}
