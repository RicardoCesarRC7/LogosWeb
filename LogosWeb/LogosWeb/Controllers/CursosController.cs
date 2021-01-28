using LogosWeb.Models.Repository.Curso;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosWeb.Controllers
{
    public class CursosController : Controller
    {
        private readonly ICursoRepository _cursoRepository;
        
        public CursosController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detalhes(int cursoId)
        {
            return View();
        }
    }
}
