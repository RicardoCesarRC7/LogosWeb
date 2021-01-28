using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosWeb.Models.Repository.Professor
{
    public interface IProfessorRepository
    {
        List<LogosWeb.Models.Professor> GetProfessores();
        List<LogosWeb.Models.Professor> GetProfessoresByCursoId(int cursoId);
    }
}
