using LogosWeb.Models;
using LogosWeb.Models.Repository.Blog;
using LogosWeb.Models.Repository.Curso;
using LogosWeb.Models.Repository.Instituicao;
using LogosWeb.Models.Repository.Professor;
using LogosWeb.Models.Repository.Testemunho;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosWeb.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IInstituicaoRepository _instituicaoRepository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly ITestemunhoRepository _testemunhoRepository;

        public ServiceController(IProfessorRepository professorRepository, IInstituicaoRepository instituicaoRepository, ICursoRepository cursoRepository, IBlogRepository blogRepository, ITestemunhoRepository testemunhoRepository)
        {
            _professorRepository = professorRepository;
            _instituicaoRepository = instituicaoRepository;
            _cursoRepository = cursoRepository;
            _blogRepository = blogRepository;
            _testemunhoRepository = testemunhoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public Models.Instituicao GetLogosInfo()
        {
            var logosInfo = _instituicaoRepository.GetInstituicaoInfo();

            return logosInfo;
        }

        [HttpGet]
        public Models.Instituicao GetContatoInfo()
        {
            var logosInfo = _instituicaoRepository.GetContatoInfo();

            return logosInfo;
        }

        [HttpGet]
        public Models.Instituicao GetValoresInfo()
        {
            var logosInfo = _instituicaoRepository.GetValoresInfo();

            return logosInfo;
        }

        [HttpGet]
        public List<Models.Curso> GetCursos()
        {
            return _cursoRepository.GetCursos();
        }

        [HttpPost]
        public Models.Curso GetCursoById(int cursoId)
        {
            return _cursoRepository.GetCursoById(cursoId);
        }

        [HttpPost]
        public List<Models.Curso> GetCursosByGrau(string grau)
        {
            return _cursoRepository.GetCursosByGrau(grau);
        }

        [HttpGet]
        public List<Models.Professor> GetProfessores()
        {
            return _professorRepository.GetProfessores();
        }

        [HttpPost]
        public List<Models.Professor> GetProfessoresByCursoId(int cursoId)
        {
            return _professorRepository.GetProfessoresByCursoId(cursoId);
        }

        [HttpGet]
        public Blog GetBlogContent()
        {
            return _blogRepository.GetBlogContent();
        }

        [HttpPost]
        public Result SendInteresseEmail(Interesse formInteresse)
        {
            return formInteresse.SendEmail();
        }

        [HttpPost]
        public Result SendEstudioEmail(InteresseEstudio interesseEstudio)
        {
            return interesseEstudio.SendEmail();
        }

        [HttpGet]
        public List<Models.Testemunho> GetTestemunhos()
        {
            return _testemunhoRepository.GetTestemunhos();
        }

        [HttpPost]
        public Postagem GetPostById(int postId)
        {
            return _blogRepository.GetPostById(postId);
        }
    }
}
