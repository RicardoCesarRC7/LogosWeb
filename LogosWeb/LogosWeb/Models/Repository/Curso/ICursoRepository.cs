using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosWeb.Models.Repository.Curso
{
    public interface ICursoRepository
    {
        List<Models.Curso> GetCursos();
        Models.Curso GetCursoById(int cursoId);
        List<Models.Curso> GetCursosByGrau(string grau);
    }
}
