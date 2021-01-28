using LogosWeb.Models;
using LogosWeb.Models.Repository.Instituicao;
using LogosWeb.Models.Repository.Professor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LogosWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProfessorRepository _professorRepository;
        private readonly IInstituicaoRepository _instituicaoRepository;

        public HomeController(ILogger<HomeController> logger, IProfessorRepository professorRepository, IInstituicaoRepository instituicaoRepository)
        {
            _logger = logger;
            _professorRepository = professorRepository;
            _instituicaoRepository = instituicaoRepository;
        }

        public IActionResult Index()
        {
            //GetLogosInfo();

            return View();
        }

        [HttpGet]
        public List<LogosWeb.Models.Professor> GetProfessores()
        {
            var professores = _professorRepository.GetProfessores();

            return professores;
        }

        [HttpGet]
        public Models.Instituicao GetLogosInfo()
        {
            var logosInfo = _instituicaoRepository.GetInstituicaoInfo();

            return logosInfo;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
