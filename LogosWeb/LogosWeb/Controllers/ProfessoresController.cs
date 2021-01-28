using LogosWeb.Models.Repository.Professor;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosWeb.Controllers
{
    public class ProfessoresController : Controller
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessoresController(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<LogosWeb.Models.Professor> GetProfessores()
        {
            var professores = _professorRepository.GetProfessores();

            return professores;
        }
    }
}
